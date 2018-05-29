//Checks the Rotation of the flipped object to heads or tails

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]

public class CoinFlip : MonoBehaviour {


	private InteractionBehaviour _intObj;

	public string face = "not flipped yet";
	private float rotation;
	private float velocity;
	private float highestVelocity;
	public bool wasFlipped = false;
	public float velocityThreshold = 2f;
	private bool touched = false;

	// Events
	public delegate void Action();
	public static event Action CoinFlipped;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspBegin += onGraspBegin;
		_intObj.OnGraspEnd += onGraspEnd;
	}

	void OnDisable() {
		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspBegin -= onGraspBegin;
		_intObj.OnGraspEnd -= onGraspEnd;
	}

	// Update is called once per frame
	void Update () {

		rotation = gameObject.transform.up.y;
		velocity = gameObject.GetComponent<Rigidbody>().velocity.y;

		if (highestVelocity < velocityThreshold) {

			if (highestVelocity <= velocity) {
				highestVelocity = velocity;
			}

		} else if(highestVelocity > velocityThreshold) {
			
			wasFlipped = true;

			highestVelocity = velocityThreshold;

		}

		if (wasFlipped == true && velocity <= 0.2 && velocity >= -0.2 && gameObject.GetComponent<Rigidbody>().velocity.x <= 0.2 && gameObject.GetComponent<Rigidbody>().velocity.x >= -0.2 && gameObject.GetComponent<Rigidbody>().velocity.z <= 0.2 && gameObject.GetComponent<Rigidbody>().velocity.z >= -0.2 && touched == false) {
			

			if (CoinFlipped != null)
			{	
				CoinFlipped ();
			}


			wasFlipped = false;
		}

		if (velocity <= 0.05) {
			if (rotation >= 0) {

				face = "heads";
			} else {
				face = "tails";
			}
		}




		//Debug.Log (velocity);

	}

	void onGraspBegin() {
		touched = true;
	}

	void onGraspEnd() {
		touched = false;
	}
}
