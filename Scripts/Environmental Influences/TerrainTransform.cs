// rotates the object by the value input through the settings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTransform : MonoBehaviour {

	private mqttTest mqtt;
	private PolyMorpher poly;
	private Renderer renderer;



	public Material baseMaterial;
	public Material[] materials;


	public float intensity;
	public float heightSpeed = 0.001f;
	public float height = 0;
	public float heightThreshold = 0f;

	public bool change = false;


	void OnAwake() {
	}


	// Use this for initialization
	void Start () {

		mqtt = GameObject.FindGameObjectWithTag("Player").GetComponent<mqttTest> ();
		poly = GetComponent<PolyMorpher> ();
		renderer = GetComponent<Renderer> ();

		for (int i = 0; i < materials.Length; i++) {
			renderer.materials [i].color = baseMaterial.color;
		}
			
		poly.SetShapeWeight("height", 1f);

		RenderSettings.fog = true;


	}

	void OnEnable () {
		D2DestroyOrCreate.PlayedGod += StartTerrainChange;

	}

	void OnDisable () {
		D2DestroyOrCreate.PlayedGod -= StartTerrainChange;
	}

	// Update is called once per frame
	void Update () {


		if (change == true) {


			ColorChangeTime (0.001f);
			HeightChange ();

			if (RenderSettings.fogDensity >= 0.007f) {
				RenderSettings.fogDensity -= 0.0001f;
			}

		}

		
//		ColorChangeIntensity();


		intensity = mqtt.pot1/133f;

//		poly.SetShapeWeight("water2", intensity);


	}

	void StartTerrainChange() {
		change = true;
	}

	void HeightChange() {

		 

		if (height > heightThreshold) {

			poly.SetShapeWeight("height", height);
			height -= heightSpeed;
		} else {
			change = false;
		}
	}

	void ColorChangeTime(float time) {
		for (int i = 0; i < materials.Length; i++) {

			float rValue = renderer.materials [i].color.r;
			float gValue = renderer.materials [i].color.g;
			float bValue = renderer.materials [i].color.r;

			float goalValueR = materials[i].color.r;
			float goalValueG = materials[i].color.g;
			float goalValueB = materials[i].color.b;


			if ( rValue < goalValueR - 0.01f) {

				rValue += time;
				renderer.materials [i].color = new Color(rValue, renderer.materials [i].color.g, renderer.materials[i].color.b);

			} else if ( rValue > goalValueR + 0.01f) {

				rValue -= time;
				renderer.materials [i].color = new Color(rValue, renderer.materials [i].color.g, renderer.materials[i].color.b);

			}


			if (gValue < goalValueG - 0.01f) {

				gValue += time;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, gValue, renderer.materials[i].color.b);
			} else if (gValue > goalValueG  + 0.01f) {

				gValue -= time;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, gValue, renderer.materials[i].color.b);
			}

			if (bValue < goalValueB + 0.01f) {


				bValue += time;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, renderer.materials[i].color.g, bValue);
			} else if (bValue > goalValueB - 0.01f) {

				bValue -= time;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, renderer.materials[i].color.g, bValue);
			}
		}
	}

	void ColorChangeIntensity() {
		for (int i = 0; i < materials.Length; i++) {

			float rValue = renderer.materials [i].color.r;
			float gValue = renderer.materials [i].color.g;
			float bValue = renderer.materials [i].color.r;

			float goalValueR = materials[i].color.r;
			float goalValueG = materials[i].color.g;
			float goalValueB = materials[i].color.b;

			float goalValueRPercent = goalValueR / 100;
			float goalValueGPercent = goalValueG / 100;
			float goalValueBPercent = goalValueB / 100;

			//			print (gValue);
			//			print (materials [i].color.g);

			if ( rValue < goalValueR - 0.01f) {

				rValue = rValue + (goalValueR - rValue) * goalValueRPercent * mqtt.pot1;
				renderer.materials [i].color = new Color(rValue, renderer.materials [i].color.g, renderer.materials[i].color.b);

			} else if ( rValue > goalValueR + 0.01f) {

				rValue = rValue - (goalValueR - rValue) * goalValueRPercent * mqtt.pot1;
				renderer.materials [i].color = new Color(rValue, renderer.materials [i].color.g, renderer.materials[i].color.b);

			}


			if (gValue < goalValueG - 0.01f) {

				gValue = gValue + (goalValueG - gValue) * goalValueGPercent * mqtt.pot1;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, gValue, renderer.materials[i].color.b);
			} else if (gValue > goalValueG  + 0.01f) {
				
				gValue = gValue - (goalValueG - gValue) * goalValueGPercent * mqtt.pot1;

				renderer.materials [i].color = new Color(renderer.materials [i].color.r, gValue, renderer.materials[i].color.b);
			}

			if (bValue < goalValueB + 0.01f) {


				bValue = bValue + (goalValueB - bValue) * goalValueBPercent * mqtt.pot1;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, renderer.materials[i].color.g, bValue);
			} else if (bValue > goalValueB - 0.01f) {

				bValue = bValue - (goalValueB - bValue) * goalValueBPercent * mqtt.pot1;
				renderer.materials [i].color = new Color(renderer.materials [i].color.r, renderer.materials[i].color.g, bValue);
			}
		}
	}


}
