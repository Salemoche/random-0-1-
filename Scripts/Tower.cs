//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//
//using Leap.Unity.Interaction;
//
//[RequireComponent(typeof(InteractionBehaviour))]
//
//public class Tower : MonoBehaviour {
//
//	public GameObject thisChoice;
//	public GameObject thatChoice;
//	public bool fall = true;
//
//	private Vector3 pos1;
//	private InteractionBehaviour _intObj;
//	private string tag;
//	private GameObject[] bricks;
//
//	// Use this for initialization
//	void Start () {
//
//		_intObj = GetComponent<InteractionBehaviour>();
//		_intObj.OnGraspBegin += onGraspBegin;
//		//_intObj.GetGraspPoint += getGraspPoint;
//
//		//choice1 = this;
//		tag = gameObject.tag;
//		bricks = GameObject.FindGameObjectsWithTag ("prop");
//
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//		pos1 = transform.position;
//
//
//	}
//
//	private void onGraspBegin() {
//
//		if (fall) {
//			foreach (GameObject brick in bricks) {
//				//brick.GetComponent<Rigidbody>().useGravity = true;
//			}
//		} else {
//			foreach (GameObject brick in bricks) {
//				//brick.GetComponent<Rigidbody>().useGravity = false;
//				//Destroy (brick.GetComponent<InteractionBehaviour>());
//				Destroy (brick.GetComponent<BoxCollider>());
//				Destroy (brick.GetComponent<Rigidbody>());
//			}
//		}
//
//		Destroy (thatChoice);
//
//		//Debug.Log (choice1.GetComponent<Renderer>().material.color);
//	}
//
//}
