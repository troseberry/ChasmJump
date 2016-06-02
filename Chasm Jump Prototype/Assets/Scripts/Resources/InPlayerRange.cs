using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InPlayerRange : MonoBehaviour 
{
	private ResourceMenu resourceMenu;

	void Start ()
	{
		Debug.Log("Resource Name: " + name);
		resourceMenu = GetComponentInChildren<ResourceMenu>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Resource in Range");
			Crafting.resourceInRange = true;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Resource Out Range");
			Crafting.resourceInRange = false;
			Inventory.currentlyCrafting.Clear();

			if (resourceMenu.interactCanvas.enabled)
			{
				resourceMenu.interactCanvas.enabled = false;
				resourceMenu.ResetInteractCanvas();
			}

			if (PossibleItemsMenu.possibleItemsCanvas.enabled)
			{
				PossibleItemsMenu.possibleItemsCanvas.enabled = false;
				PossibleItemsMenu.ClearItems();
			}
		}
	}
}
