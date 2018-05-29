// Adds random Values
// Could be used to take in values from the outside world


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour {

	public int value1;
	public int value2;
	public int value3;
	public int value4;

	// Use this for initialization
	void Start () {

		value1 = Random.Range (0, 100);
		value2 = Random.Range (0, 100);
		value3 = Random.Range (0, 100);
		value4 = Random.Range (0, 100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
