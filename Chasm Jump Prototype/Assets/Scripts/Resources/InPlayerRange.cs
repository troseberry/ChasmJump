using UnityEngine;
using System.Collections;

public class InPlayerRange : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Resource in Range");
			GatherResource.resourceInRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Resource in Range");
			GatherResource.resourceInRange = false;
		}
	}
}
