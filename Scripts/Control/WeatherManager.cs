// Manages the different scenarios randomly created in mqttTtest


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour {


	private mqttTest mqtt;
	private float humidity;
	private float temperature;
	private float pressure;

	private int humidityThreshold;
	private int temperatureThreshold;



	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();
	}

	// Update is called once per frame
	void Update () {

		humidity = (mqtt.humidity - 15f) * 7;
		temperature = (mqtt.temperature - 20f) * 5 ;
		pressure = mqtt.pressure;

		if (humidity >= humidityThreshold) {

		}



	}


}
