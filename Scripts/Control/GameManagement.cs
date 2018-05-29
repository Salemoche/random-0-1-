using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour {


	public Timer timer;
	public GameObject scenario1;
	public GameObject scenario2;
	public GameObject scenario3;
	public GameObject scenario4;
	public GameObject credits;
	private bool timePast;
	public float DelayTimeD11 = 5f;
	public float DelayTimeD12 = 5f;
	public float DelayTimeD13 = 5f;
	public float DelayTimeD21 = 5f;
	public float DelayTimeD22 = 5f;
	public float DelayTimeD23 = 5f;
	public float DelayTimeD31 = 5f;
	public float DelayTimeD41 = 5f;
	public float DelayTimeD42 = 5f;
	public float DelayTimeD43 = 5f;

	private Settings settings;
	private mqttTest mqtt;

	// Events
	public delegate void Action();
	public static event Action startScenario2Action;


	void OnEnable() {
		timer = gameObject.GetComponent<Timer> ();
		D1ChooseLanguage.LanguageChosen += startScenario2;
		D2DestroyOrCreate.PlayedGod += startScenario3;
//		D3ExpectTheUnexpected.RockTaken += startScenario4;
//		D35MoveOn.SatDown += startScenario4;
		DestroyOutsideCollider.Arrived += startScenario4;

		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

		RenderSettings.fogColor = Color.white;

//		print ("playing");
	}

	void OnDisable() {

		D1ChooseLanguage.LanguageChosen -= startScenario2;
		D2DestroyOrCreate.PlayedGod -= startScenario3;
//		D3ExpectTheUnexpected.RockTaken -= startScenario4;
//		D35MoveOn.SatDown -= startScenario4;
		DestroyOutsideCollider.Arrived -= startScenario4;

	}

	void Start () {
		
		FindObjectOfType<AudioManager> ().Play ("BGM");

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene("First Interaction");
		}
			
	}
		

	void startScenario2() {
		print ("Scenario 2 Start");

		timer.scenarioTime = Time.time;

		StartCoroutine ("timeManager1");


		if (startScenario2Action != null) {
			startScenario2Action ();
		}
	}

	void startScenario3() {
		print ("Scenario 3 Start");

		timer.scenarioTime = Time.time;


		StartCoroutine ("timeManager2");
	}

	void startScenario4() {
		print ("Scenario 4 Start");

		timer.scenarioTime = Time.time;

		StartCoroutine ("timeManager4");
		Physics.gravity = new Vector3 (0.0f, -4.9f, 0.0f); // little gravity
	}


	IEnumerator timeManager1() {

		yield return new WaitForSeconds(DelayTimeD11);
		FindObjectOfType<AudioManager> ().Play ("D1-full");
		yield return new WaitForSeconds(DelayTimeD12);
		scenario2.SetActive(true);
		yield return new WaitForSeconds(DelayTimeD13);
		FindObjectOfType<AudioManager> ().Play ("D2-full");

	}

	IEnumerator timeManager2() {

		yield return new WaitForSeconds(DelayTimeD21);
		scenario3.SetActive(true);
		yield return new WaitForSeconds(DelayTimeD22);
		FindObjectOfType<AudioManager> ().Play ("D3.5-1");
		yield return new WaitForSeconds(DelayTimeD23);
		gameObject.GetComponent<ColorChangeSkybox>().enabled = true;

	}

//	IEnumerator timeManager3() {
//
//		yield return new WaitForSeconds(DelayTimeD31);
////		FindObjectOfType<AudioManager> ().Play ("D3-full");
//		yield return new WaitForSeconds(DelayTimeD31);
//		scenario4.SetActive(true);
//
//	}

	IEnumerator timeManager4() {

		yield return new WaitForSeconds(DelayTimeD41);
		FindObjectOfType<AudioManager> ().Play ("D4-full");
		yield return new WaitForSeconds(DelayTimeD42);
		scenario4.SetActive(true);
		if (settings.preserved == true) {
			mqtt.Eject ();
		}
		yield return new WaitForSeconds(DelayTimeD43);


		credits.SetActive (true);

	}



}
