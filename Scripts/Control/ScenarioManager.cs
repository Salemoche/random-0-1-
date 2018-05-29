// Manages the different scenarios randomly created in mqttTtest


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour {


	private mqttTest mqtt;

	public Component[] environmentScripts;
	public GameObject environment;
	public GameObject[] objects;
	public Component[] scripts;
	public int currentScenario;

	public GameObject weather;


	void OnEnable() {
		D1ChooseLanguage.LanguageChosen += randomAction;
		D2DestroyOrCreate.PlayedGod += randomAction;
		D3ExpectTheUnexpected.RockTaken += randomAction;
	}

	void OnDisable() {

		D1ChooseLanguage.LanguageChosen -= randomAction;
		D2DestroyOrCreate.PlayedGod -= randomAction;
		D3ExpectTheUnexpected.RockTaken -= randomAction;
	}

	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

	}

	// Update is called once per frame
	void Update () {



		currentScenario = mqtt.randPreset1;


		//testing and yet to store

		if (currentScenario % 2 == 1) {
			Physics.gravity = new Vector3 (0.0f, -4.9f, 0.0f); // little gravity

//			print ("Case 1");

		} else {

			Physics.gravity = new Vector3 (0.0f, -0.2f, 0.0f); // normal gravity

//			print ("Case 2");
		}


		// random actions
//		if (mqtt.switch1 == 1) {
//			Physics.gravity = Vector3.zero; // zero gravity
//			Physics.gravity = new Vector3 (0.0f, -0.3f, 0.0f); // little gravity

//		} else {
//
//			Physics.gravity = new Vector3 (0.0f, -4.9f, 0.0f); // normal gravity
//		}



	}




	public void randomAction() {

		if (mqtt.randPreset1 == 1) {

			weather.SetActive (true);

//			environmentScripts = environment.GetComponents (typeof(MonoBehaviour));

			if (environment.GetComponent<EnvironmentTilt> () != false) {
				environment.GetComponent<EnvironmentTilt> ().enabled = false;
				Debug.Log (environmentScripts);
			}

		} else if (mqtt.randPreset1 == 2) {

			weather.SetActive (false);

			if (environment.GetComponent<EnvironmentTilt> () != false) {
				environment.GetComponent<EnvironmentTilt> ().enabled = false;
				Debug.Log (environmentScripts);
			}

		}  else if (mqtt.randPreset1 == 3) {


			if (environment.GetComponent<EnvironmentTilt> () != false) {
				environment.GetComponent<EnvironmentTilt> ().enabled = false;
				Debug.Log (environmentScripts);
			}

		}   else if (mqtt.randPreset1 == 4) {



		}  else if (mqtt.randPreset1 == 5) {



		}  else if (mqtt.randPreset1 == 6) {



		}  else if (mqtt.randPreset1 == 7) {

		

		}  else if (mqtt.randPreset1 == 8) {

		

		} 


		// defaults

		else {
			if (environment.GetComponent<EnvironmentTilt> () != false) {
				environment.GetComponent<EnvironmentTilt> ().enabled = true;
				//				Debug.Log (environmentScripts);
			}
		}
	}
}
