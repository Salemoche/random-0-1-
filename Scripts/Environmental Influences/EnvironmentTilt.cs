// tilts the object by the value input through the settings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTilt : MonoBehaviour {

	private mqttTest mqtt;

	public float environmentTilt = 0f;
	public float threshold = 1f;
	private float environmentRotation = 0;

	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();
	}

	// Update is called once per frame
	void Update () {
//		environmentTilt = mqtt.tiltY * threshold;
//		environmentTilt += 1;
//
//		gameObject.transform.Rotate(1, 0, environmentTilt);
//		//environmentTilt = 0;

		environmentTilt = mqtt.slider1/50f - 1f;

		transform.rotation = Quaternion.Euler (0, 0, environmentTilt  * threshold);
	}
}
