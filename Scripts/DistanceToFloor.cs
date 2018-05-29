using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToFloor : MonoBehaviour {

	public GameObject ground;
	public GameObject floor;
	public float dist = 1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay (transform.position, Vector3.down * dist);

//		RaycastHit hit;
//		if (Physics.Raycast (transform.position, Vector3.down, out hit, dist)) {
//
//			if (hit.collider == ground.GetComponent<MeshCollider> ()) {
//				print ("Too close");
//				ground.transform.Translate (Vector3.back);
//			}
//		} else {
//			ground.transform.Translate (Vector3.forward);
//		}
		Vector3 closestPoint = floor.GetComponent<Collider> ().ClosestPointOnBounds(transform.position);
		float distance = Vector3.Distance (closestPoint, transform.position);

//		if (distance <= 4.5) {
//			print ("Too close");
//			transform.Translate (0, 0, -0.1f);
//		} 
//		else if (distance <= 5.5) {
//			print ("Too far");
//			transform.Translate (0, 0, +0.1f);
//		}

		print (distance);
	}
}
