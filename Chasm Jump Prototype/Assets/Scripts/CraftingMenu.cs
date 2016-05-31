// PLayer selects buttons from tools, raw resources, crafting items, and components.
// Button of selection is outlined to indicate the item is selected
// Item is added to currently crafting
// Item name is added to the text box above the results outline so the player can see all
// items that are selected.
// If the combination of selections makes an item, the item icon will appear in the results
// outline as a  button. If the player presses the button, they will gain that item
// and their inventory will be updated (item additions and subtractions)


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class CraftingMenu : MonoBehaviour 
{
	public static CraftingMenu Instance;

	private EventSystem uiEventSystem;
	private Canvas craftingMenu;
	public Text selections;

	private GameObject lastHovered;

	public List<string> currentlyCrafting;		//treating like a read only version of Inventory.currentlycrafting

	private int currentPage = 0;
	public GameObject[] pages = new GameObject[3];

	public RectTransform currentResult;


	void Start () 
	{
		Instance = this;

		uiEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		craftingMenu = GetComponent<Canvas>(); 
		craftingMenu.enabled = false;

		Inventory.currentlyCrafting.Clear();
	}
	
	void Update () 
	{
		currentlyCrafting = Inventory.currentlyCrafting;

		if (Input.GetKeyDown(KeyCode.C))
		{
			craftingMenu.enabled = !craftingMenu.enabled;
		}
	}

	public void EditSelections ()
	{
		GameObject currentSelection = uiEventSystem.currentSelectedGameObject;


		if (!currentlyCrafting.Contains(currentSelection.name))
		{
			if (currentlyCrafting.Count < 7)
			{
				Inventory.currentlyCrafting.Add(currentSelection.name);
				currentSelection.GetComponentInChildren<RawImage>().enabled = true;
			}
		}
		else
		{
			Inventory.currentlyCrafting.Remove(currentSelection.name);
			currentSelection.GetComponentInChildren<RawImage>().enabled = false;
		}

		selections.text = "";
		foreach (string item in currentlyCrafting)
		{
			selections.text += (item + "\n");
		}



		//change the currentResult
		ClearResults();

		GatherResource.DeterminePossibleItems();
		ShowResult();
		/*foreach (string item in GatherResource.possibleItems)
		{
			//compare to the buttons that are already being displayed.
			//if not already present, create the button
		}*/
	}

	public static void ShowResult ()
	{
		foreach (Item item in GatherResource.possibleItems)
		{
			//compare to the buttons that are already being displayed.
			//if not already present, create the button
			Debug.Log("Result Item: " + item.name);
			GameObject resultButton =  (GameObject)Instantiate(Resources.Load("Items/Buttons/" + item.name));
			resultButton.name = item.name;
			resultButton.transform.SetParent(Instance.currentResult, false);
			resultButton.transform.localScale = new Vector2(3,3);

			Debug.Log("Adding Button Function");
			Button btnComponent = resultButton.GetComponent<Button>();
			btnComponent.onClick.AddListener(() => SelectResultItem());
			Debug.Log("Button Function Added");
		}		
	}

	public static void SelectResultItem ()
	{
		//based on the item name from the shown button, increment the item count in inventory
		string itemName = Instance.uiEventSystem.currentSelectedGameObject.name;
		Inventory.UpdateResourceCount(itemName, 1);
		Debug.Log("Received Item! Total "+ itemName + " :" + Inventory.GetResourceCount(itemName));

		//after player takes item, clear currentlyCrafting list
		ClearResults();
		Inventory.currentlyCrafting.Clear();
	}

	public static void ClearResults ()
	{
		GatherResource.possibleItems.Clear();
		foreach (Transform Child in Instance.currentResult)
		{
			Destroy(Child.gameObject);
		}
	}





	public void HoverOutlineOn (BaseEventData hover)
	{
		PointerEventData pedHover = (PointerEventData)hover;

		if(pedHover.pointerEnter.tag == "CraftingButton")
		{
			GameObject currentHover = pedHover.pointerEnter;
			Debug.Log("Current Hover: " + currentHover.name);

			if (!currentHover.GetComponent<Button>())
			{
				currentHover = currentHover.transform.parent.gameObject;
				Debug.Log("New Current Hover: " + currentHover);
			}


			if (!currentlyCrafting.Contains(currentHover.name))
			{
				currentHover.GetComponentInChildren<RawImage>().enabled = true;
				lastHovered = currentHover;
			}
		}
	}

	public void HoverOutlineOff ()
	{
		Debug.Log("Last Hovered: " + lastHovered.name);
		if (!currentlyCrafting.Contains(lastHovered.name))
		{
			lastHovered.GetComponentInChildren<RawImage>().enabled = false;
		}
	}

	public void SwitchPage ()
	{
		string currentArrow = uiEventSystem.currentSelectedGameObject.name;

		if (currentArrow == "LeftArrow")
		{
			Debug.Log("Going left");
			currentPage = (currentPage + 2) % pages.Length;
		}
		else
		{
			currentPage = (currentPage + 1) % pages.Length;
		}

		Debug.Log("Current Page #: " + currentPage);

		for (int i = 0; i < pages.Length; i++)
		{
			if (i == currentPage)
			{
				pages[i].SetActive(true);
			}
			else
			{
				pages[i].SetActive(false);
			}
		}
	}

	public void CraftItem ()
	{
		GatherResource.DeterminePossibleItems();
	}
}
