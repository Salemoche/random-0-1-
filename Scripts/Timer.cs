// A timer with minutes and seconds

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float startTime;
	public float seconds;
	public float minutes;

	public float scenarioTime;
	public float scenarioSeconds;
	public float scenarioMinutes;

	// Use this for initialization
	void OnEnable () {
		startTime = Time.time;
		scenarioTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;

		string minutesString = ((int)t / 60).ToString ();
		string secondsString = (t % 60).ToString ("f1");
		seconds = (t % 60);
		minutes = (t / 60);
		float secondsFloat = t % 60;

		float sT = Time.time - scenarioTime;

		scenarioSeconds = (sT % 60);
		scenarioMinutes = (sT / 60);
	}
}
