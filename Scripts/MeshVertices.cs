using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshVertices : MonoBehaviour {

	[Range(1, 10)]public float rate=2f;

	void Update() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		int i = 0;
		while (i < vertices.Length) {
			//vertices[i] += Vector3.up * Time.deltaTime;
			vertices[i] += Vector3.up / rate;
			Debug.Log (i);
			i+=2;
		}
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
	}
		
//	public Vector3[] newVertices;
//	public Vector2[] newUV;
//	public int[] newTriangles;
//	void Start() {
//		Mesh mesh = new Mesh();
//		GetComponent<MeshFilter>().mesh = mesh;
//		mesh.vertices = newVertices;
//		mesh.uv = newUV;
//		mesh.triangles = newTriangles;
//	}
//
//	void Update() {
//		Mesh mesh = GetComponent<MeshFilter>().mesh;
//		Vector3[] vertices = mesh.vertices;
//		Vector3[] normals = mesh.normals;
//		int i = 0;
//		while (i < vertices.Length) {
//			vertices[i] += normals[i] * Mathf.Sin(Time.time);
//			i++;
//		}
//		mesh.vertices = vertices;
//	}

}