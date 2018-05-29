// Decreases Opacity and removes objects if the are too far appart
// Needs the interaction objects to be children of an Empty

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]

public class Removed : MonoBehaviour {

	private Settings settings;
	private InteractionBehaviour _intObj;

	private Color color;
	private Color baseColor;
	private float alpha;
	[Range(1f, 20f)]public float threshold = 10f;

	public GameObject thisOption;
	public GameObject thatOption;

	private Vector3 pos1;
	private Vector3 pos2;
	private float dist;


	// Events
	public delegate void Action();
	public static event Action ObjectRemoved;
	public static event Action Test;

	// Use this for initialization
	void Start () {

		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspStay += onGraspStay;

		baseColor = thatOption.GetComponent<Renderer>().material.color;
		color = baseColor;
		thisOption = gameObject;

		settings = GameObject.FindGameObjectWithTag("Player").GetComponent<Settings> ();

		dist = Vector3.Distance (pos1, pos2);
		threshold = threshold - dist;

	}


	void OnDisable() {
		_intObj.OnGraspBegin -= onGraspStay;
	}

	// Update is called once per frame
	void Update () {

		pos1 = thisOption.transform.position;

		if (thatOption != null) {
			pos2 = thatOption.transform.position;
		}

		dist = Vector3.Distance (pos1, pos2);

		alpha = 1 - 0.1f * dist * threshold;
		color.a = alpha;


		//Debug.Log (choice2.GetComponent<Renderer> ().material.color);



	}

	private void onGraspStay() {
		thatOption.GetComponent<Renderer> ().material.color = color;
		thisOption.GetComponent<Renderer> ().material.color = baseColor;

		if (alpha <= 0 && thatOption != null) {
			Destroy (thatOption);

			if (ObjectRemoved != null)
			{	
				ObjectRemoved ();
				Debug.Log ("removed");
			}
		}
	}


		
}
