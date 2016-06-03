using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory
{

	/*private static int woodLogs;
	private static int woodLashings;
	private static int branches;
	private static int sticks;
	private static int matches;
	private static int sap;
	private static int water;
	private static int deadBirds;
	private static int deadDeer;
	private static int feathers;
	private static int pelts;
	*/

	public static List<string> currentlyCrafting = new List<string>(); //add and clear in other scripts
	

	private static Dictionary<string, int> resources = new Dictionary<string, int>()
	{
		//Tools
		{"Bow + Arrow", 1},
		{"Hatchet", 1},
		{"Knife", 1},
		{"Magnifying Glass", 1},

		{"Matches", 0},

		//Raw Resources
		{"Bark", 0},
		{"Branch", 0},
		{"Cotton", 0},
		{"Dead Bird", 0},
		{"Dead Deer", 0},
		{"Sap", 0},
		{"Sticks", 0},
		{"Water", 0},
		{"Wood Logs", 0},

		//Crafting Items
		{"Cordage", 0},
		{"Feathers", 0},
		{"Pelt", 0},
		{"Shaved Branch", 0},
		{"Thread", 0},
		{"Wood Planks", 0},

		//Components
		{"Rope", 0}
	};

	public static void UpdateResourceCount (string resourceName, int updateAmount)
	{
		Item toUpdate = ItemMasterlist.GetItem(resourceName);
		if(toUpdate.itemType != "tool") resources[resourceName] += updateAmount;
	}

	public static int GetResourceCount (string resourceName)
	{
		return resources[resourceName];
	}
}
