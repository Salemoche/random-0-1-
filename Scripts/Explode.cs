// Explodes an object
// Takes an exploded version from Blender
// is subscribed to the Removed.ObjectRemoved Event

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	public GameObject explodedVersion;
	public GameObject emergingThing1;
	public GameObject emergingThing2;
	public Vector3 emergingThingVelocity;
	private mqttTest mqtt;

	// Use this for initialization
	void OnEnable () {
//		EventManager.OnKeyDown += ExplodeObject;
		Removed.ObjectRemoved += ExplodeObject;
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

		emergingThingVelocity = new Vector3 (0, 20, 0);

		if (gameObject.GetComponent<D1ChooseLanguage> () != null) {
			D1ChooseLanguage.LanguageChosen += ExplodeObject;
		}

		if (gameObject.GetComponent<D2DestroyOrCreate> () != null) {
			D2DestroyOrCreate.PlayedGod += ExplodeObject;
		}


	}
		
	
	// Update is called once per frame
	void OnDisable () {

//		EventManager.OnKeyDown -= ExplodeObject;
		D1ChooseLanguage.LanguageChosen -= ExplodeObject;
		Removed.ObjectRemoved -= ExplodeObject;
		D2DestroyOrCreate.PlayedGod -= ExplodeObject;

	}

	void ExplodeObject() {
		Instantiate (explodedVersion, transform.position, transform.rotation);

		if (gameObject != null) {
			Destroy (gameObject);

		}

		if (gameObject == GameObject.FindGameObjectWithTag ("egg")) {

			if (mqtt.randPreset1 % 2 == 0) {
				
				if (emergingThing1 != null) {
					Instantiate (emergingThing1, transform.position, emergingThing1.transform.rotation);

					if (emergingThing1.GetComponent<Rigidbody> () != null) {
						emergingThing1.GetComponent<Rigidbody>().AddForce(emergingThingVelocity);
						//emergingThing.GetComponent<AudioSource>().Play();
					}

				}
			} if (mqtt.randPreset1 % 2 == 1) {

				if (emergingThing2 != null) {

					Instantiate (emergingThing1, transform.position, emergingThing1.transform.rotation);

				}
			}
				
		}

	}

}
