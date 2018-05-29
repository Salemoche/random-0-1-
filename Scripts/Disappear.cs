// Decreases Opacity of an object depending on a random value over time
// Is set on the Empty Parent of the two options



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {
	
	private Settings settings;

	private Color color;
	private Color baseColor1;
	private Color baseColor2;
	private float alpha = 1;
	[Range(0.1f, 10f)]public float threshold = 1f;

	private GameObject choice1;
	private GameObject choice2;

	public float timerMinutes = 0f;
	public float timerSeconds = 20f;
	private float minutes = 0f;
	private float seconds = 20f;


	// Use this for initialization
	void Start () {

		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();
		choice1 = transform.GetChild (0).gameObject;
		choice2 = transform.GetChild (1).gameObject;
		baseColor1 = choice1.GetComponent<Renderer>().material.color;
		baseColor2 = choice2.GetComponent<Renderer>().material.color;
	
	}


	void OnDisable() {
	}
	
	// Update is called once per frame
	void Update () {

		minutes = settings.minutes;
		seconds = settings.seconds;

		if (choice1 != null) {
			color = choice1.GetComponent<Renderer>().material.color;
		}


		if (minutes >= timerMinutes && seconds >= timerSeconds && alpha >= 0 && choice1 != null & choice2 != null) {
			
			if (settings.decision1 == 1) {
				alpha -= 0.0005f;
				color.a = alpha;
				choice1.GetComponent<Renderer> ().material.color = color;

				if (alpha < 0.001) {
					Destroy (choice1);
				}
			} else if (settings.decision1 == 2) {
				alpha -= 0.0005f;
				color.a = alpha;
				choice2.GetComponent<Renderer> ().material.color = color;

				if (alpha < 0.001) {
					Destroy (choice2);
				}
			}

		}



		color.a = alpha;

		if (choice1 != null) {
			choice1.GetComponent<Renderer> ().material.color = color;
		}
		//Debug.Log (choice2.GetComponent<Renderer> ().material.color);


		if (alpha <= 0 && choice2 != null) {
			//Destroy (choice2);
		}


	}


}
