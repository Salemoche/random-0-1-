// rotates the object by the value input through the settings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

	private mqttTest mqtt;

	public float speed = 0.1f;


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

//		transform.rotation = Quaternion.Euler (0, 0, environmentTilt);

		transform.Rotate(Vector3.down * speed);
	}
}
