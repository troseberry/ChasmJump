using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GatherResource : MonoBehaviour 
{
	public static GatherResource Instance;

	private EventSystem uiEventSystem;
	public static bool resourceInRange;
	public static List<Item> possibleItems = new List<Item>();
	private static List<Item> allItemsCopy;

	public Canvas possibleItemsCanvas;
	public RectTransform possibleItemsButtons;

	private static Canvas craftingMenu;

	void Start () 
	{
		Instance = this;
		uiEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		allItemsCopy= ItemMasterlist.GetAllItems();

		craftingMenu = GameObject.Find("CraftingMenu").GetComponent<Canvas>();
	}
	
	void Update () 
	{
	
	}

	public static void DeterminePossibleItems ()
	{
		//loop thru allItems list, if an item's requiremnts list is the same length and
		//contains the same elements as the currentlyCrafting list
		//add it to possibleItems list
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
					possibleItems.Add(item);
				}
			}
		}
		if(!craftingMenu.enabled)
		{
			ShowPossibleItems();
		}
	}


	public static void ShowPossibleItems ()
	{
		Debug.Log(possibleItems.Count);
		Instance.possibleItemsCanvas.enabled = true;

		foreach(Item item in possibleItems)
		{
			Debug.Log("Possible Item: " + item.name);
			GameObject possilbeItemBtn =  (GameObject)Instantiate(Resources.Load("Items/Buttons/" + item.name));
			possilbeItemBtn.name = item.name;
			possilbeItemBtn.transform.SetParent(Instance.possibleItemsButtons, false);
			possilbeItemBtn.transform.localScale = new Vector2(1,1);

			Button btnComponent = possilbeItemBtn.GetComponent<Button>();
			btnComponent.onClick.AddListener(() => SelectShownItem());
		}		
	}

	public static void SelectShownItem ()
	{
		//based on the item name from the shown button, increment the item count in inventory
		string itemName = Instance.uiEventSystem.currentSelectedGameObject.name;
		Inventory.UpdateResourceCount(itemName, 1);
		Debug.Log("Received Item! Total "+ itemName + " :" + Inventory.GetResourceCount(itemName));

		//after player takes item, clear currentlyCrafting list
		Instance.possibleItemsCanvas.enabled = false;
		ClearPossibleItems();
		Inventory.currentlyCrafting.Clear();
	}

	public static void ClearPossibleItems ()
	{
		possibleItems.Clear();
		if (!craftingMenu.enabled)
		{
			foreach (Transform Child in Instance.possibleItemsButtons)
			{
				Destroy(Child.gameObject);
			}
		}
	}
}
