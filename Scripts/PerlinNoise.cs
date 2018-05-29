using UnityEngine;

public class PerlinNoise : MonoBehaviour {

	public int width = 256;
	public int height = 256;

	public float scale = 20f;

	public float offsetX = 100f;
	public float offsetY = 100f;

	// Use this for initialization
	void Start () {
		offsetX = Random.Range (0f, 999999f);
		offsetY = Random.Range (0f, 999999f);
	}
	
	// Update is called once per frame

	void Update () {
		Renderer renderer = GetComponent<Renderer> ();
		renderer.material.mainTexture = GenerateTexture ();
	}

	Texture2D GenerateTexture() {

		Texture2D texture = new Texture2D (width, height);

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Color color = CalculateColor (x, y);
				texture.SetPixel (x, y, color);
			}
		}


		texture.Apply ();
		return texture;
	}




	Color CalculateColor (int x, int y) {

		float xCoord = (float)x / width * scale + offsetX;
		float yCoord = (float)y / height * scale + offsetY;



		float sample = Mathf.PerlinNoise (xCoord, yCoord);

//		float rValue = sample * 255 / 5.4f;
//		float gValue = sample * 255 / 1f;
//		float bValue = sample * 255 / 2.33f;

		//print (rValue + ", " + sample);

		//return new Color (rValue, gValue, bValue);
		return new Color (sample, sample, sample);

	}
}
