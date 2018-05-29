using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutsideCollider : MonoBehaviour {

	public GameObject collider;
	public GameObject colliderPrefab;

	public delegate void Action();
	public static event Action Arrived;

	// Use this for initialization
	// Update is called once per frame
	void Update () {
		
	}

	void destroy() {
		collider.SetActive (false);


	}

	void create() {
		collider.SetActive (true);

		if (Arrived != null) {
			Arrived ();
		}

	}
}
