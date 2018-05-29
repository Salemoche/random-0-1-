using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]

public class D1ChooseLanguage : MonoBehaviour {

	public bool german;

	private Settings settings;
	private InteractionBehaviour _intObj;
	private mqttTest mqtt;

	private float alpha;
	[Range(0.1f, 2f)]public float threshold = 0.5f;

	private GameObject thisOption;
	public GameObject thatOption;

	private Vector3 pos1;
	private Vector3 pos2;
	private float dist;
	private Timer timer;
	private bool decisionFinished = false;

//	private float startTime;
	public float seconds;
	private float minutes;

	// Events
	public delegate void Action();
	public static event Action LanguageChosen;
	public static event Action DecisionFinished;

	// Use this for initialization
	void Start () {

		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspStay += onGraspStay;

		thisOption = gameObject;

		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();
		timer = gameObject.GetComponent<Timer> ();
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

		dist = Vector3.Distance (pos1, pos2);
		threshold = threshold - dist;
		german = true;

//		startTime = Time.time;

	}



	void OnDisable() {
		_intObj.OnGraspBegin -= onGraspStay;
	}

	// Update is called once per frame
	void Update () {
//		float t = Time.time - startTime;
//
//		string minutesString = ((int)t / 60).ToString ();
//		string secondsString = (t % 60).ToString ("f1");
//		seconds = (t % 60);
//		minutes = (t / 60);
//		float secondsFloat = t % 60;

		pos1 = thisOption.transform.position;

		if (thatOption != null) {
			pos2 = thatOption.transform.position;
		}

		dist = Vector3.Distance (pos1, pos2);

		alpha = 1 - 0.1f * dist * threshold;


		//Debug.Log (choice2.GetComponent<Renderer> ().material.color);

		decisionFinished = true;

//		if (decisionFinished == true && DecisionFinished != null) {
//			print ("sendEvent");
//			DecisionFinished ();
//		}

	}

	private void onGraspStay() {



		if (dist >= threshold) {

			if (gameObject.tag == "german") {
				settings.german = true;
			} else if (gameObject.tag == "english") {
				settings.german = false;
			}

			if (LanguageChosen != null) {
				
				FindObjectOfType<AudioManager>().Play ("D1.1");
				LanguageChosen ();



//				if (settings.german == true) {
//					FindObjectOfType<AudioManager>().Play ("Deutsch--1");
//					FindObjectOfType<AudioManager>().Play ("explosion");
//				} else {
//					FindObjectOfType<AudioManager>().Play ("English--1");
//					FindObjectOfType<AudioManager>().Play ("explosion");
//				}
			}



		}
	}



}

