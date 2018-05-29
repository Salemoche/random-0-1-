// Decision 3
// Removes Box Collider if removed too far
// takes the decision 3 parameter from the settings;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]
public class D3ExpectTheUnexpected : MonoBehaviour {

	private InteractionBehaviour _intObj;
	private mqttTest mqtt;

	private Settings settings;

	private Vector3 originalPosition;
	private Vector3 currentPosition;
	private float dist;
	private int option;
//	private float startTime;
	private float seconds;
	private float minutes;
	private Timer timer;
	private bool rockTaken = false;

	public GameObject boundingBox;
	public float threshold = 0.5f;



	// Events
	public delegate void Action();
	public static event Action RockTaken;

	void Start() {
		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspStay += onGraspStay;
		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();
		originalPosition = transform.position;
		timer = gameObject.GetComponent<Timer> ();
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

//		startTime = Time.time;
	}


	void OnDisable() {
		_intObj.OnGraspStay -= onGraspStay;
	}

	void Update() {

//		float t = Time.time - startTime;
//
//		string minutesString = ((int)t / 60).ToString ();
//		string secondsString = (t % 60).ToString ("f1");
//		seconds = (t % 60);
//		minutes = (t / 60);
//		float secondsFloat = t % 60;

		currentPosition = transform.position;
		dist = Vector3.Distance (originalPosition, currentPosition);
		option = settings.decision3;

		if (dist >= threshold && rockTaken == false) {
			//Destroy (gameObject);

			if (mqtt.randPreset1 % 2 == 0) {
				
				Destroy (boundingBox);
			} else {
				FindObjectOfType<AudioManager> ().Play ("D3.5-2");
			}

			if (RockTaken != null) {
				RockTaken ();
				rockTaken = true;
			}
		}
	}

	private void onGraspStay() {




	
	}

}

