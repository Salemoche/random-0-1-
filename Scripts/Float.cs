// Sets the Weight of the object to Force (1 in this example)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	public float force = 4.905f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

//		if (Physics.gravity.y <= -4) {
//			transform.GetComponent<Rigidbody> ().AddForce(0,force,0);
//
//		}

		transform.GetComponent<Rigidbody> ().AddForce(0,force,0);

	}
		
}

