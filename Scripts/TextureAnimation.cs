using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour {

	private Renderer renderer;
	private float randomValue;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		randomValue = Random.Range (-2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time/500;
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offset * randomValue, offset * randomValue * (randomValue /2)));
	}
}
