// Decision 3
// Removes Box Collider if removed too far
// takes the decision 3 parameter from the settings;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D35MoveOn : MonoBehaviour {

	private mqttTest mqtt;
	private Settings settings;
	private GameManagement gameManager;

	private Animator anim;

//	private float startTime;
	private float seconds;
	private float minutes;
	private Timer timer;
	private bool rockTaken = false;
	private GameObject camera;
	private Vector3 camPos;

	public float threshold = 0.5f;




	// Events
	public delegate void Action();
	public static event Action SatDown;

	void Start() {
		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();
		timer = gameObject.GetComponent<Timer> ();
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();
		anim = gameObject.GetComponent<Animator> ();
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		gameManager = GameObject.FindGameObjectWithTag("Player").GetComponent<GameManagement> ();



//		startTime = Time.time;
	}


	void OnDisable() {
	}

	void Update() {

//		float t = Time.time - startTime;
//
//		string minutesString = ((int)t / 60).ToString ();
//		string secondsString = (t % 60).ToString ("f1");
//		seconds = (t % 60);
//		minutes = (t / 60);
//		float secondsFloat = t % 60;

		camPos = camera.transform.position;


		if (Input.GetKeyDown(KeyCode.Space)) {


//			anim.SetBool("move--1", true);
//			StartCoroutine ("timeManager35");
//
//		} else if (Input.GetKeyDown(KeyCode.Alpha2)) {
//			anim.SetBool("move--2", true);
//			StartCoroutine ("timeManager35");
//
////			if (SatDown != null) {
////				SatDown ();
////				rockTaken = true;
////				print (camera.transform.position);
////			}
////			camera.transform.position = camPos;
//		} else if (Input.GetKeyDown(KeyCode.Alpha3)) {
//			Debug.Log("animate!");
//
//			anim.SetBool("move--3", true);
//			StartCoroutine ("timeManager35");

			StartCoroutine ("timeManager35");

		}
	}

	IEnumerator timeManager35() {

		yield return new WaitForSeconds(gameManager.DelayTimeD41);
		FindObjectOfType<AudioManager> ().Play ("D3-full");
		yield return new WaitForSeconds(gameManager.DelayTimeD42);

		if (mqtt.randPreset1 % 2 == 0) {
			anim.SetBool("move--1", true);
		} else {
			anim.SetBool("move--2", true);
		}


		if (SatDown != null) {
			SatDown ();
			rockTaken = true;
//			print (camera.transform.position);
		}
	}
		

}

