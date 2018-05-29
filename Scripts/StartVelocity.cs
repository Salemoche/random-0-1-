using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVelocity : MonoBehaviour {

	public float force = .3f;

	// Use this for initialization
	void Start () {

		float xforce = Random.Range (-force, force);
		float yforce = Random.Range (-force, force);
		float zforce = Random.Range (-force, force);

		Vector3 totalForce = new Vector3 (xforce, yforce, zforce);
		GetComponent<Rigidbody> ().velocity = totalForce;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
