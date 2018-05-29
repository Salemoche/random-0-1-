using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour {

	public GameObject[] newElements;
	public GameObject bottomRock;
	public GameObject topRock;
	//private Vector3 randPos;

	void Start() {

		//randPos = transform.position;

		for (int i = 0; i <= 200; i++) {
//
//			randPos.x = Random.Range (-1, 1);
//			randPos.y = Random.Range (-1, 1);
//			randPos.z = Random.Range (-1, 1);
			//StartCoroutine("spawn");

			//Instantiate (newElement, randPos, transform.rotation);


		}
		StartCoroutine("spawn");

	}

	void OnEnable () {
//		EventManager.OnKeyDown += SpawnObject;



	}


	// Update is called once per frame
	void OnDisable () {

//		EventManager.OnKeyDown -= SpawnObject;

	}

	void SpawnObject() {

		int randNumber = Random.Range (0, 5);

		Instantiate (newElements[randNumber], transform.position, transform.rotation);
	}

	IEnumerator spawn() {
		
		bottomRock.SetActive(true);

		for (int i = 0; i <= 150; i++) {

			int randNumber = Random.Range (0, 5);
			float randSize = Random.Range (2f, 3f);

			GameObject newObject = Instantiate (newElements[randNumber], transform.position, transform.rotation) as GameObject;
			newObject.transform.localScale = new Vector3(randSize, randSize, randSize);
			yield return new WaitForSeconds (0.05f);

		}

		topRock.SetActive(true);
	}
}
