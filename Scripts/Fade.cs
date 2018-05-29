using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public float fadeDelay = 0.05f;
	private Renderer rend;
	private GameObject fadeObject;
	private Vector3 fadeObjectPosition;
	private Quaternion fadeObjectRotation;

	// Use this for initialization
	void Start () {


	}

	void OnEnable() {


		if (gameObject.GetComponent<Renderer> () != null) {
			rend = GetComponent<Renderer> ();
			Color c = rend.material.color;
		}

		fadeObject = gameObject;
		fadeObjectPosition = fadeObject.transform.position;
		fadeObjectRotation = fadeObject.transform.rotation;

		if (gameObject.tag == "egg") {
			GameManagement.startScenario2Action += startFadeIn;
		}
	}

	void OnDisable() {

	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.O)) {
			startFadeOut();
		} else if (Input.GetKeyDown (KeyCode.I)) {
			startFadeIn();
		}
	}





	public void startFadeIn() {
		StopCoroutine ("FadeOut");
		StopCoroutine("FadeIn");
		StartCoroutine ("FadeIn");
	}

	public void startFadeOut() {
		StopCoroutine ("FadeOut");
		StopCoroutine ("FadeIn");
		StartCoroutine ("FadeOut");
	}

	IEnumerator FadeIn() {
		
		//Instantiate (fadeObject, fadeObjectPosition, fadeObjectRotation);
		gameObject.GetComponent<Renderer>().enabled = true;
		for (float f = 0f; f <= 1; f += 0.05f) {
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(0.05f);
		}


//		print ("fade in");
	}

	IEnumerator FadeOut() {
		for (float f = 1; f >= 0f; f -= 0.05f) {
			Color c = rend.material.color;
			c.a = f;
			rend.material.color = c;
			yield return new WaitForSeconds(fadeDelay);
		}
		gameObject.GetComponent<Renderer>().enabled = false;
		//Destroy (gameObject);
//		print ("fade out");
	}

}
