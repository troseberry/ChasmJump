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
		{"woodLogs", 0},
		{"woodLashings", 0},
		{"branches", 0},
		{"sticks", 0},
		{"matches", 0},
		{"sap", 0},
		{"water", 0},
		{"deadBirds", 0},
		{"deadDeer", 0},
		{"feathers", 0},
		{"pelts", 0}
	};

	public static void UpdateResourceCount (string resourceName, int updateAmount)
	{
		resources[resourceName] += updateAmount;
	}

	public static int GetResourceCount (string resourceName)
	{
		return resources[resourceName];
	}
}
