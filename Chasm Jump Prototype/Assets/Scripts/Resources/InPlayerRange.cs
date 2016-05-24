using UnityEngine;
using System.Collections;

public class InPlayerRange : MonoBehaviour 
{
	public GameObject toolOptions;
	public GameObject hatchetActions;
	public GameObject matchesActions;
	public GameObject knifeActions;

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
			Debug.Log("Resource Out Range");
			GatherResource.resourceInRange = false;
			Inventory.currentlyCrafting.Clear();

			if(toolOptions.activeSelf)
			{
				toolOptions.SetActive(false);
			}
			else if (hatchetActions.activeSelf)
			{
				hatchetActions.SetActive(false);
			}
			else if (matchesActions.activeSelf)
			{
				matchesActions.SetActive(false);
			}
			else if (knifeActions.activeSelf)
			{
				knifeActions.SetActive(false);
			}
		}
	}
}
