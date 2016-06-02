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
		{"Wood Logs", 0},
		{"Wood Lashings", 0},
		{"Branches", 0},
		{"Sticks", 0},
		{"Matches", 0},
		{"Sap", 0},
		{"Water", 0},
		{"Dead Birds", 0},
		{"Dead Deer", 0},
		{"Feathers", 0},
		{"Pelts", 0}
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
