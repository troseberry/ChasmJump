using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Crafting 
{
	public static bool resourceInRange = false;

	public static List<Item> possibleItems = new List<Item>();
	private static List<Item> allItemsCopy = ItemMasterlist.GetAllItems();

	public static EventSystem uiEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();



	public static void DeterminePossibleItems (bool craftingMenuOpen)
	{
		//loop thru allItems list, if an item's requiremnts list is the same length and
		//contains the same elements as the currentlyCrafting list add it to possibleItems list

		foreach (Item item in allItemsCopy)
		{
			Debug.Log("currently crafting length: " + Inventory.currentlyCrafting.Count);
			if (Inventory.currentlyCrafting.Count == item.requirements.Count)
			{
				bool noMatch = false;
				foreach (string req in Inventory.currentlyCrafting)
				{
					Debug.Log("Current Craft: " + req + " present? " + item.requirements.Contains(req));
					if (!item.requirements.Contains(req))
					{
						noMatch = true;
					}
				}

				if (!noMatch)
				{
					if(!Crafting.possibleItems.Contains(item)) Crafting.possibleItems.Add(item);
				}
			}
		}

		Debug.Log("Current Possible Items: " + possibleItems.Count);

		if(!craftingMenuOpen)
		{
			PossibleItemsMenu.ShowItems();
		}
		else
		{
			CraftingMenu.ShowResults();
		}
	}
}
