// tilts the object by the value input through the settings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeSkybox : MonoBehaviour {

	private mqttTest mqtt;

	public Material changeMaterial;
	private Material baseMaterial;

	private Material skyboxMaterial;

	public Color topColor;
	public Color bottomColor;
	public Color fogColor;

	private float slider1;
	private float slider2;
	private float slider3;

	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

	}

	// Update is called once per frame
	void Update () {
//		if (mqtt.inputSwitch == 1) {
//			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial;
//		} else {
//			gameObject.GetComponent<MeshRenderer> ().material = baseMaterial;
//
//		}


		skyboxMaterial = RenderSettings.skybox;

		slider1 = mqtt.slider1/100f;
		slider2 = mqtt.slider2/100f;
		slider3 = mqtt.slider3/100f;

		topColor.r = 1f - slider1 - 0.3f;
		topColor.g = 1f - slider2 - 0.3f;
		topColor.b = 1f - slider3 - 0.3f;

		bottomColor.r = 1f - slider1;
		bottomColor.g = 1f - slider2;
		bottomColor.b = 1f - slider3;

		fogColor.r = 1f - slider1 + 0.7f;
		fogColor.g = 1f - slider2 + 0.7f;
		fogColor.b = 1f - slider3 + 0.6f;


		skyboxMaterial.SetColor ("_Color1", bottomColor);
		skyboxMaterial.SetColor ("_Color2", topColor);

		RenderSettings.fogColor = fogColor;


			
	}
}
