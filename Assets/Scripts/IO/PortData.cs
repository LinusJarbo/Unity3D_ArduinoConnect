using UnityEngine;

public class PortData : MonoBehaviour
{
	public static PortData Current;
	[HideInInspector]
	public string USBportName;
	[HideInInspector]
	public int baudrate = 57600;

	void Awake ()
	{
		Current = this;
	}
}
