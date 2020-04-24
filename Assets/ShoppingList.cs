using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShoppingList", menuName = "ShoppingLists" )]
public class ShoppingList : ScriptableObject
{

	public int spawnDelay;
    public string debugField;
    public List<Item> itemList = new List<Item>();
    public bool isInfected;
}
