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

	public static Item bark = new Item ()
	{
		name = "Bark",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Knife", "Shread"})
	};

	public static Item branch = new Item ()
	{
		name = "Branch",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "None", "Pull"})
	};

	public static Item cordage = new Item ()
	{
		name = "Cordage",
		itemType = "craftingItem",
		requirements = new List<string>(new string[] {"Bark"})
	};

	public static Item cotton = new Item ()
	{
		name = "Cotton",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Cotton Plant", "Magnifying Glass", "Search"})
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
		itemType = "craftingItem",
		requirements = new List<string>(new string[] {"Dead Bird", "Knife"})
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
		itemType = "craftingItem",
		requirements = new List<string>(new string[] {"Dead Deer", "Knife"})
	};

	public static Item rope = new Item ()
	{
		name = "Rope",
		itemType = "component",
		requirements = new List<string>(new string[] {"Cordage"})
	};

	public static Item sap = new Item ()
	{
		name = "Sap",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Spigot", "Tap"})
	};

	public static Item shavedBranch = new Item ()
	{
		name = "Shaved Branch",
		itemType = "craftingItem",
		requirements = new List<string>(new string[] {"Branch", "Knife"})
	};

	public static Item sticks = new Item ()
	{
		name = "Sticks",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Bush", "Magnifying Glass", "Search"})
	};

	public static Item thread = new Item ()
	{
		name = "Thread",
		itemType = "craftingItem",
		requirements = new List<string>(new string[] {"Cotton"})
	};

	public static Item water = new Item ()
	{
		name = "Water",
		itemType = "rawResource",
		requirements = new List<string>(new string[] {"Tree", "Spigot", "Tap"})
	};

	public static Item woodLogs = new Item () 
	{
		name = "Wood Logs", 
		itemType = "rawResource", 
		requirements = new List<string>(new string[] {"Tree", "Hatchet", "Chop"})
	};

	public static Item woodPlanks = new Item ()
	{
		name = "Wood Planks",
		itemType = "craftingItem",
		requirements = new List<string>(new string[] {"Wood Logs", "Hatchet"})
	};


	//TOOLS
	public static Item bowArrow = new Item ()
	{
		name = "Bow + Arrow",
		itemType = "tool",
		requirements = new List<string>(new string[] {})
	};

	public static Item hatchet = new Item ()
	{
		name = "Hatchet",
		itemType = "tool",
		requirements = new List<string>(new string[] {})
	};

	public static Item knife = new Item ()
	{
		name = "Knife",
		itemType = "tool",
		requirements = new List<string>(new string[] {})
	};

	public static Item magnifyingGlass = new Item ()
	{
		name = "Magnifying Glass",
		itemType = "tool",
		requirements = new List<string>(new string[] {})
	};


	private static List<Item> allItems = new List<Item>()
	{
		
		bark,
		branch,
		cordage,
		cotton,
		deadBird,
		deadDeer,
		feathers,
		matches,
		pelt,
		rope,
		sap,
		shavedBranch,
		sticks,
		thread,
		water,
		woodLogs,
		woodPlanks,

		//Tools
		bowArrow,
		hatchet,
		knife,
		magnifyingGlass
	};


	public static List<Item> GetAllItems ()
	{
		return allItems;
	}

	public static Item GetItem (string itemName)
	{
		return allItems.Find(item => item.name == itemName);
	}
}
