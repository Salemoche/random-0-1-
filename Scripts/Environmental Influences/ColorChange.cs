// tilts the object by the value input through the settings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	private mqttTest mqtt;

	public Material changeMaterial;
	private Material baseMaterial;

	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

		baseMaterial = gameObject.GetComponent<MeshRenderer> ().material;
	}

	// Update is called once per frame
	void Update () {
//		if (mqtt.inputSwitch == 1) {
//			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial;
//		} else {
//			gameObject.GetComponent<MeshRenderer> ().material = baseMaterial;
//
//		}
			
	}
}
