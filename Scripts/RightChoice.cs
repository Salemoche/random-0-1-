using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]
public class RightChoice : MonoBehaviour {

	private Settings settings;
	private InteractionBehaviour _intObj;

	private Color color;
	private float alpha;
	[Range(0.1f, 10f)]public float threshold = 1f;

	public GameObject decision;
	private GameObject choice1;
	private GameObject choice2;

	private Vector3 pos1;
	private Vector3 pos2;
	private float dist;

	// Use this for initialization
	void Start () {

		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspBegin += onGraspBegin;

		color = GetComponent<Renderer>().material.color;

		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();

	}


	void OnDisable() {
		_intObj.OnGraspBegin -= onGraspBegin;
	}

	// Update is called once per frame
	void Update () {

		if (settings.decision1 == 1) {
			choice1 = decision.transform.GetChild (0).gameObject;
			choice2 = decision.transform.GetChild (1).gameObject;
		} else {
			choice1 = decision.transform.GetChild (1).gameObject;
			choice2 = decision.transform.GetChild (0).gameObject;
		}

		pos1 = choice1.transform.position;
		pos2 = choice2.transform.position;
		dist = Vector3.Distance (pos1, pos2);

		alpha = 1 - 0.1f * dist * threshold;
		color.a = alpha;
		choice2.GetComponent<Renderer> ().material.color = color;

		//Debug.Log (choice2.GetComponent<Renderer> ().material.color);


		if (alpha <= 0 && choice2 != null) {
			Destroy (choice2);
		}


	}

	void onGraspBegin () {
	}

}
