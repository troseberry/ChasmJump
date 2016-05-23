using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GatherResource : MonoBehaviour 
{

	public static bool resourceInRange;
	public static List<Item> possibleItems = new List<Item>();

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}

	public void DeterminePossileItems ()
	{
		//loop thru allItems list, if an item's requiremnts list is the same length and
		//contains the same elements as the currentlyCrafting list
		//add it to possibleItems list
	}


	public void ShowPossibleItems ()
	{

	}

	public void SelectShownItem ()
	{
		//based on the item name from the shown button, increment the item count in inventory
		//Inventory.UpdateResourceCount(uiEventSystem.currentSelectedGameObject.name, 1);

		//after player takes item, clear currentlyCrafting list
		Inventory.currentlyCrafting.Clear();
	}


	//on trigger enter, enable ability to show that object's interaction menu, and available tool options
	//meaning, look at trigger, get base game object (a resource object) get the child Resource InteractCanvas, 
	

	/*public static void GainResource (string resourceName, string tool)
	{
		if (tool == "Hatchet")
		{
			Inventory.UpdateResourceCount(resourceName, 1);
			Debug.Log("Wood Logs Count: " + Inventory.GetResourceCount(resourceName));
		}	
	}
	*/
}
