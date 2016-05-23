using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceMenu : MonoBehaviour 
{
	private EventSystem uiEventSystem;

	public GameObject toolOptions;
	public GameObject hatchetActions;
	public string resourceName;				//important to rename resources to exact name (instead of clone) on instantiation
	
	void Start () 
	{
		//toolOptions = RectTransform.Find("Tools");
		uiEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		resourceName = transform.parent.name;
		toolOptions.SetActive(false);
		hatchetActions.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ToggleToolOptions()
	{
		if (GatherResource.resourceInRange)
		{
			Debug.Log("Toggle Available Tool Options");
			toolOptions.SetActive(!toolOptions.activeSelf);
		}

	}

	public void UseTool ()
	{
		//Debug.Log("Current Item Source: " + resourceName);
		//add the above source to the currentlyCrafting list
		Inventory.currentlyCrafting.Add(resourceName);

		string currentTool = uiEventSystem.currentSelectedGameObject.name;
		//Debug.Log("Current Tool: " + uiEventSystem.currentSelectedGameObject.name);
		Inventory.currentlyCrafting.Add(currentTool);
		//hide tools ui btn, show available actions btn

		if (currentTool == "Hatchet")
		{
			ToggleToolOptions();
			hatchetActions.SetActive(true);
		}
	}


	public void PerformAction ()
	{
		string currentAction = uiEventSystem.currentSelectedGameObject.name;
		//Debug.Log("Current Action: " + currentAction);
		Inventory.currentlyCrafting.Add(currentAction);
		//hide the actions ui btn, show menu that has possible items

		foreach (string req in Inventory.currentlyCrafting)
		{
			//Debug.Log("Crafting List: " + req);
		}

		GatherResource.DeterminePossibleItems();
		Debug.Log("Determining Possible Items");
	}	
}








