using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceMenu : MonoBehaviour 
{
	private EventSystem uiEventSystem;

	public GameObject toolOptions;
	public string resourceName;				//important to rename resources to exact name (instead of clone) on instantiation
	
	void Start () 
	{
		//toolOptions = RectTransform.Find("Tools");
		uiEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		resourceName = transform.parent.name;
		toolOptions.SetActive(false);
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
		Debug.Log("Current Item Source: " + resourceName);
		//add the above source to the currentlyCrafting list
		Inventory.currentlyCrafting.Add(resourceName);

		Debug.Log("Current Tool: " + uiEventSystem.currentSelectedGameObject.name);
		//add the above current tool to the currentlyCrafting list
		Inventory.currentlyCrafting.Add(uiEventSystem.currentSelectedGameObject.name);
		//hide tools ui btn, show available actions btn

		//AllResources.GainResource(resourceName, uiEventSystem.currentSelectedGameObject.name);
	}


	public void PerformAction ()
	{
		Debug.Log("Current Action: " + uiEventSystem.currentSelectedGameObject.name);
		//add the above current action to the currentlyCrafting list
		Inventory.currentlyCrafting.Add(uiEventSystem.currentSelectedGameObject.name);
		//hide the actions ui btn, show menu that has possible items
	}	
}








