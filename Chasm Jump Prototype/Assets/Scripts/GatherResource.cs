using UnityEngine;
using System.Collections;

public class GatherResource : MonoBehaviour {

	public static bool resourceInRange;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void ShowResourceMenu ()
	{
		
	}

	//on trigger enter, enable ability to show that object's interaction menu, and available tool options
	//meaning, look at trigger, get base game object (a resource object) get the child Resource InteractCanvas, 
	

	public static void GainResource (string resourceName, string tool)
	{
		if (tool == "Hatchet")
		{
			Inventory.UpdateResourceCount(resourceName, 1);
			Debug.Log("Wood Logs Count: " + Inventory.GetResourceCount(resourceName));
		}	
	}
}
