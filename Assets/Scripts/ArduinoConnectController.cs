using UnityEngine;

public class ArduinoConnectController : MonoBehaviour
{
	public static ArduinoConnectController Current;
	public ScanPorts scanPorts;

	//start scanning on Start
	void Start ()
	{
		Current = this;
		ScanForArduino ();
	}

	//start scanning for arduino
	public void ScanForArduino ()
	{
		Debug.Log ("<color=green>" + "Started scanning for arduino" + "</color>\n");
		scanPorts.StartScan ();
	}

	//found arduino, stop scanning and start your project, or cancel scanning and continue without arduino.
	public void StopScanningForArduino ()
	{
		Debug.Log ("<color=green>" + "Stopped scanning for arduino" + "</color>\n");
		scanPorts.StopScan ();
	}

	//callback from TalkToArduino, the arduino is connected.
	public void ArduinoIsConnected ()
	{
		Debug.Log ("<color=green>" + "Arduino is connected" + "</color>\n");
		Camera.main.GetComponent <Camera> ().backgroundColor = Color.green;
	}
}
