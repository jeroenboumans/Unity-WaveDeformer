using UnityEngine;
using System.Collections;

public class WaveDeform : MonoBehaviour {

	public float waveheight = 0.5f;
	public float wavelength = 1;
	public float dir = 0;
	public float speed = 1;

	private Mesh mesh;
	bool animating;
	private IEnumerator coroutine;
	void Start ()
	{
		coroutine = FadeLogoTo();
		mesh = GetComponent<MeshFilter>().mesh;
		HumanDetector.startAnimations += ToggleFade;
	}
	
	// Update is called once per frame
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

	public void ToggleFade(){
		Debug.Log("toggle");
		if(animating)
		{
			StopCoroutine(coroutine);
			animating = !animating;
			coroutine = FadeLogoTo();
			StartCoroutine(coroutine);
		}
		else
			StartCoroutine(coroutine);
	}

	public IEnumerator FadeLogoTo()
	{
		animating = true;
		Color startColor = this.GetComponent<Renderer>().material.GetColor("_TintColor");
		float from = startColor.a;
		float time = 0;

		float to = (from > 0) ? 0 : 0.73f;

		while(from < to )
		{
			time += Time.deltaTime;
			this.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0.73f, 0.73f, 0.73f, Mathf.Lerp(from, to, time/5)));
			yield return null;
		}

		ToggleFade();
	}
}
