//Need to make this a comprehensive database of the following
// 1) Resources produced from using tools on environment source
// 2) Crafting Items produced from using tools on resouces
// 3) Components produced from using crafing items with crafting items
// 4) Apparatuses produced from using components with components (might store in separate apparatus only script) 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemMasterlist
{

	public static Item branch = new Item ()
	{
		name = "Branch",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "None", "Pull"})
	};

	public static Item cotton = new Item ()
	{
		name = "Cotton",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Cotton Plant", "None", "Search"})
	};

	public static Item deadBird = new Item ()
	{
		name = "Dead Bird",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Bird", "Bow + Arrow", "Shoot"})
	};

	public static Item deadDeer = new Item ()
	{
		name = "Dead Deer",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Deer", "Bow + Arrow", "Shoot"})
	};

	public static Item feathers = new Item ()
	{
		name = "Feathers",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Dead Bird", "Bow + Arrow", "Skin"})
	};

	public static Item matches = new Item ()
	{
		name = "Matches",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Bush", "Magnifying Glass", "Search"})
	};

	public static Item pelt = new Item ()
	{
		name = "Pelt",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Dead Deer", "Bow + Arrow", "Skin"})
	};

	public static Item sap = new Item ()
	{
		name = "Sap",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Spigot", "Tap"})
	};

	public static Item sticks = new Item ()
	{
		name = "Sticks",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Bush", "Magnifying Glass", "Search"})
	};

	public static Item water = new Item ()
	{
		name = "Water",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Spigot", "Tap"})
	};

	public static Item woodLashings = new Item ()
	{
		name = "Wood Lashings",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Knife", "Shread"})
	};

	/*public static Item testItemOne = new Item ()
	{
		name = "Test Item One",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Knife", "Shread"})
	};

	public static Item testItemTwo = new Item ()
	{
		name = "Test Item Two",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Knife", "Shread"})
	};*/

	public static Item woodLogs = new Item () 
	{
		name = "Wood Logs", 
		itemType = "rawResource", 
		requirements = new List<string>(new string[] {"Tree", "Hatchet", "Chop"})
	};


	private static List<Item> allItems = new List<Item>()
	{
		
		branch,
		cotton,
		deadBird,
		deadDeer,
		feathers,
		matches,
		pelt,
		sap,
		sticks,
		water,
		woodLashings,
		woodLogs/*,
		testItemTwo,
		testItemTwo*/
	};


	public static List<Item> GetAllItems ()
	{
		return allItems;
	}

}
