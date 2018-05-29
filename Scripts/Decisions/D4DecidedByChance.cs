// Decreases Opacity of an object depending on a random value over time
// Is set on the Empty Parent of the two options



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D4DecidedByChance : MonoBehaviour {
	
	private Settings settings;
	private mqttTest mqtt;

	[Range(0.1f, 10f)]public float threshold = 1f;

	public GameObject headsDoor;
	public GameObject tailsDoor;
	private Animator animHeadsDoor;
	private Animator animTailsDoor;
	public Animation heads;
	public Animation tails;
	private Animator anim;
	private Timer timer;
	private float startTime;
//	private float seconds;
//	private float minutes;

	// Events
	public delegate void Action();
	public static event Action DecisionFinished;
//


	// Use this for initialization
	void Start () {

		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();
		headsDoor = transform.GetChild (0).gameObject;
		tailsDoor = transform.GetChild (1).gameObject;
		animHeadsDoor = headsDoor.GetComponent<Animator> ();
		animTailsDoor = tailsDoor.GetComponent<Animator> ();
//		heads = headsDoor.GetComponent<Animation> ();
//		tails = tailsDoor.GetComponent<Animation> ();

		anim = GetComponent<Animator> ();
		timer = gameObject.GetComponent<Timer> ();
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

//		startTime = Time.time;
	
	}

	void OnEnable() {
		CoinFlip.CoinFlipped += OpenDoor;

	}


	void OnDisable () {

		CoinFlip.CoinFlipped -= OpenDoor;

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

		if (Input.GetKeyDown (KeyCode.Q)) {
			anim.SetTrigger ("heads");
		}

	}

	void OpenDoor() {


		if (settings.decision4 == "heads") {

//			animHeadsDoor.Play ("Open2");
			anim.SetTrigger ("heads");

		} else if (settings.decision4 == "tails") {
//			animTailsDoor.Play ("Open");
			anim.SetTrigger ("tails");

		}

		if (DecisionFinished != null) {
			DecisionFinished ();
		}
	}



}
