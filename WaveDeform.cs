using UnityEngine;
using System.Collections;

public class WaveDeform : MonoBehaviour {

	public float waveheight = 0.5f;
	public float wavelength = 1;
	public float dir = 0;
	public float speed = 1;

	private Mesh mesh;
	private bool animating;

	void Start ()
	{
		mesh = GetComponent<MeshFilter>().mesh;
	}
	
	void Update ()
	{
		Animate();
	}

	public void Animate()
	{
		Vector3[] vertices = mesh.vertices;
		
		float width = Mathf.Sqrt(vertices.GetLength(0));
		int count 	= vertices.Length;
		int index 	= 0;
		int i 		= 0;
		
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < width; y++)
			{
				float sin = Mathf.Sin(Time.time*speed + x + (y * dir)) ;
				vertices[i] = new Vector3(mesh.vertices[i].x, sin * waveheight, mesh.vertices[i].z);
				i++;
			}
		}
		
		mesh.vertices = vertices;
	}
}