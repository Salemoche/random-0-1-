using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static event ActionHappened OnKeyDown; // event variable
	public delegate void ActionHappened(); // method that subscribes to the event

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
//			Instantiate (explodedVersion, transform.position, transform.rotation);
//			Destroy (gameObject);
			if (OnKeyDown != null) {
				OnKeyDown();
			}
		}
	}
}
