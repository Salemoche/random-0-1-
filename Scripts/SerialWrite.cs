using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialWrite : MonoBehaviour {

	private SerialPort serial;
	private string[] portNames;
	public bool onoff;



	// Use this for initialization
	void Start () {
		
		portNames = SerialPort.GetPortNames ();


		foreach(string portName in portNames) {
			print("The Port is " + portName);
		}

		serial = new SerialPort ("COM3", 9600);
	}

	// Update is called once per frame
	void Update () {


		if (serial.IsOpen == false) {
			serial.Open ();
		};

//		if (Input.GetKeyDown (KeyCode.O)) {
//			serial.Write ("1,");
//			print ("on");
//			serial.Write ("0,");
//		}

		if (onoff) {
			serial.Write ("1,");

		} else if (!onoff) {

			serial.Write ("0,");
		}

		
	}
}
