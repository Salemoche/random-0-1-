using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

	private mqttTest mqtt;

	private Animator anim;



	void OnEnable() {
//		D1ChooseLanguage.LanguageChosen += randomAction;
	}

	void OnDisable() {

//		D1ChooseLanguage.LanguageChosen -= randomAction;
	}

	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();
		anim = gameObject.GetComponent<Animator> ();


	}

	// Update is called once per frame
	void Update () {

		bool walk = false;



		if (Input.GetKeyDown(KeyCode.V)) {

			anim.SetTrigger("flap");

		} else if (Input.GetKeyDown(KeyCode.B)) {

			anim.SetTrigger("shake");
		} else if (Input.GetKeyDown(KeyCode.N)) {

			anim.SetTrigger("blow");

		} else if (Input.GetKeyDown(KeyCode.M)) {

			walk = !walk;

			anim.SetTrigger("walkT");

			if (walk == true) {

				anim.SetBool("walk", true);
				anim.SetBool("move", true);

			} else {

				anim.SetBool("walk", false);
				anim.SetBool("move", true);

			}

		}
	}
}

