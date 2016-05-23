//Each item has a list of requirements
//player has a "currentlyCrafting" list.
//when player interacts with an environment piece, it adds the env piece name to the currentlyCrafting list
//When they pick a tool, its added to the list
//when they pick an action, its added to the list

//compare the currentlyCrafting list at each stage with all available items' requirements lists
//if they don't contain an ingrediant when it's added to the currentlyCrafting list, remove the item
//from the list of possible output items
//when all things have been added to the currentlyCrafting list, show all possible output items to the player
//they pick one item, it is added to their inventory

//Tool + Environment + Action = Raw Resource
//Tool + Raw Resource = Crafting Item
//Crafting Item + Crafting Item = Component
//Component1 + Component2 +... + Componentn = Apparatus


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item
{
	public string name { get; set; }
	public string itemType { get; set; }
	public List<string> requirements { get; set; }
}