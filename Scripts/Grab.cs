using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionBehaviour))]
public class Grab : MonoBehaviour {

	private InteractionBehaviour _intObj;

	void Start() {
		_intObj = GetComponent<InteractionBehaviour>();
		_intObj.OnGraspBegin += onGraspBegin;
	}

	void OnDisable() {
		_intObj.OnGraspBegin -= onGraspBegin;
	}

	void Update() {
			//print (_intObj.OnGraspStay);
		//print (_intObj.OnGraspBegin);
		//_intObj.OnGraspBegin() { print("hey"); }
	}

	private void onGraspBegin() {
		//Debug.Log ("hey");
	}
		
}