using UnityEngine;
using System.Collections;

public class TalkToArduino : MonoBehaviour
{
	//connect class
	public ArduinoConnect arduinoConnect;

	//call sensor readings on Arduino
	string[] sensorChars = { "A", "B", "C" };
	int sensorIndex = 0;

	const float Frequency = 0.02f;

	[HideInInspector]
	public bool GotHandShake = false;

	public void StartTalkingToArduino ()
	{
		ArduinoConnectController.Current.ArduinoIsConnected ();
		arduinoConnect.Open (PortData.Current.USBportName);
		InvokeRepeating ("SendSensorIndexToArduino", Frequency, Frequency);
	}

	public void SendSensorIndexToArduino ()
	{
		arduinoConnect.WriteToArduino (sensorChars [UpdateSensorIndex ()]);

		StartCoroutine
		(
			arduinoConnect.AsynchronousReadFromArduino
			((string s) => CheckCallback (s),     // Callback
				Frequency	                      // Timeout (seconds)
			)
		);
	}

	public IEnumerator SendHandshake ()
	{
		Debug.Log ("<color=green>" + "handshake sent... waiting for reply" + "</color>\n");
		arduinoConnect.WriteToArduino ("H");

		yield return StartCoroutine
		(
			arduinoConnect.AsynchronousReadFromArduino
			((string s) => CheckHandshake (s),     // Callback
				Frequency	                      // Timeout (seconds)
			)
		);
	}

	int UpdateSensorIndex ()
	{
		sensorIndex++;
		if (sensorIndex >= sensorChars.Length) {
			sensorIndex = 0;
		}
		return sensorIndex;
	}

	void CheckHandshake (string str)
	{
		Debug.Log (str);
		if (str [0].ToString () == "H") {
			Debug.Log ("H it is...");
			GotHandShake = true;
		}
	}

	void CheckCallback (string str)
	{
		char sensorReading = str [0];

		int result = -1;
		int.TryParse (str.Substring (1), out result);

		//if garbage - return
		if (result == -1) {
			return;
		}

		//clean up data
		if (result < 0) {
			Debug.Log ("<color=red>" + "Data not clean" + "</color>\n");
			result = 0;
		}

		if (result > 1024) {
			Debug.Log ("<color=red>" + "Data not clean" + "</color>\n");
			result = 1024;
		}

		switch (sensorReading) {

		case 'A':
			Debug.Log ("<color=red>" + "A: " + result + "</color>\n");
			break;
		
		case 'B':
			Debug.Log ("<color=orange>" + "B: " + result + "</color>\n");
			break;
		
		case 'C':
			Debug.Log ("<color=yellow>" + "C: " + result + "</color>\n");
			break;
		
		case 'H':
			Debug.Log ("<color=grey>" + "Cathed a spare handshake " + "</color>\n");
			break;

		default:
			Debug.LogError ("Case not found: " + sensorReading);
			break;
		}

	}
}
