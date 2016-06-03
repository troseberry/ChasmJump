using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PossibleItemsMenu : MonoBehaviour 
{
	public static PossibleItemsMenu Instance;

	public static Canvas possibleItemsCanvas;
	private static RectTransform possibleItemsButtons;


	void Start () 
	{
		Instance = this;
	
		possibleItemsCanvas = GetComponent<Canvas>();
		possibleItemsButtons = (RectTransform)transform.Find("Buttons");
	}

	public static void ShowItems ()
	{
		Debug.Log(Crafting.possibleItems.Count);
		possibleItemsCanvas.enabled = true;

		foreach(Item item in Crafting.possibleItems)
		{
			Debug.Log("Possible Item: " + item.name);
			
			GameObject possilbeItemBtn =  (GameObject)Instantiate(Resources.Load("Items/Buttons/" + item.name));
			
			possilbeItemBtn.name = item.name;
			possilbeItemBtn.transform.SetParent(possibleItemsButtons, false);
			possilbeItemBtn.transform.localScale = new Vector2(1,1);

			Button btnComponent = possilbeItemBtn.GetComponent<Button>();
			btnComponent.onClick.AddListener(() => SelectShownItem());
		}		
	}

	public static void ClearItems ()
	{
		Crafting.possibleItems.Clear();
		foreach (Transform Child in possibleItemsButtons)
		{
			Destroy(Child.gameObject);
		}
	}

	public static void SelectShownItem ()
	{
		//based on the item name from the shown button, increment the item count in inventory
		string itemName = Crafting.uiEventSystem.currentSelectedGameObject.name;
		Inventory.UpdateResourceCount(itemName, 1);
		Debug.Log("Received Item! Total "+ itemName + " :" + Inventory.GetResourceCount(itemName));

		//after player takes item, clear currentlyCrafting list
		possibleItemsCanvas.enabled = false;
		ClearItems();
		Inventory.currentlyCrafting.Clear();
	}
}