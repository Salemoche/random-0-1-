using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private Vector3 m_CamForward; 
	public int speed = 1;
	public Transform m_Cam;

	// Use this for initialization
	void Start () {
		m_Cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;


		if (Input.anyKeyDown) {
//			gameObject.transform.Translate (m_CamForward);
			gameObject.transform.Translate (Vector3.down);
			gameObject.GetComponent<Rigidbody> ().freezeRotation = true;;

		}

	}

	public void MoveOneForward() {
		gameObject.transform.Translate (m_CamForward, Space.World);
	}
}
