// rotates the object by the value input through the settings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour {

	private mqttTest mqtt;

	public float rotation;
	public float pRotation;
	public string type;
	public string number;
	private string sensor;


	public float rate = 0.1f;

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

		sensor = type + number;

		rotation = mqtt.pot1/50f - 1f;

		if (transform.rotation.y >= rotation + 0.1f) {
			transform.Rotate(Vector3.down * rate);

		} else if (transform.rotation.y <= rotation - 0.1f) {
			transform.Rotate(Vector3.down * -rate);
		}

		pRotation = rotation;
	}
}
