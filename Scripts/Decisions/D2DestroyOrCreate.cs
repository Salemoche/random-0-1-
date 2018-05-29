// Destroys game object when brought too close to the "fire" object


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]
public class D2DestroyOrCreate : MonoBehaviour {

	private InteractionBehaviour _intObj;
	private mqttTest mqtt;

	private Vector3 posObject;
	private Vector3 posFire;
	private Vector3 posNest;
	private float distFire;
	private float distNest;
//	private float startTime;
	private float seconds;
	private float minutes;
	private Timer timer;
	private bool broken;

	public bool preserved = false;
 


	public GameObject fire;
	public GameObject nest;
	public float threshold = 0.5f;

	// Events
	public delegate void Action();
	public static event Action PlayedGod;
	public static event Action DecisionFinished;


	void Start() {

		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspStay += onGraspStay;
		timer = gameObject.GetComponent<Timer> ();
		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();

//		startTime = Time.time;
	}


	void OnDisable() {
		_intObj.OnGraspBegin -= onGraspStay;
	}

	void Update() {


		posObject = transform.position;
		posFire = fire.transform.position;
		posNest = nest.transform.position;
		distFire = Vector3.Distance (posObject, posFire);
		distNest = Vector3.Distance (posObject, posNest);

		if (distNest <= threshold || distFire <= threshold) {
			//Destroy (gameObject);

//			if (PlayedGod != null && broken == false)

			if (distNest <= threshold) {
				preserved = true;
			}

			if (PlayedGod != null)
			{	
				PlayedGod ();
				broken = true;
			}
		}


	}

	private void onGraspStay() {

	}

}

