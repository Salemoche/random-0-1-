using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTerrain : MonoBehaviour {
	
	private float position;
	public Vector3 pos0;

	// Use this for initialization
	void Start () {
		position = transform.position.y;
		pos0 = new Vector3 (transform.position.x, -position, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = pos0;
//		print (position);
	}
}
