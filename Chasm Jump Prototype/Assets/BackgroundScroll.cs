using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{

	public float scrollSpeed;

	void Start () 
	{
	
	}
	

	void Update () 
	{
		Vector2 offset = new Vector2(Time.time * scrollSpeed, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
