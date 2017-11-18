using UnityEngine;

public class MainController : MonoBehaviour
{
	public static MainController Current;
	public ScanPorts scanPorts;

	void Start ()
	{
		Current = this;
		ScanForArduino ();
	}

	public void ScanForArduino ()
	{
		Debug.Log ("<color=green>" + "Started scanning for arduino" + "</color>\n");
		scanPorts.StartScan ();
	}

	//found arduino, stop scanning and start
	public void StopScanningForArduino ()
	{
		Debug.Log ("<color=green>" + "Stopped scanning for arduino" + "</color>\n");
		scanPorts.StopScan ();
	}

	//AutoCheck if Arduino connected
	public void ArduinoIsConnected ()
	{
		Debug.Log ("<color=green>" + "Arduino is connected" + "</color>\n");
		Camera.main.GetComponent <Camera> ().backgroundColor = Color.green;
	}
}
