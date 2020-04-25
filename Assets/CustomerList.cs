using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CustomerList", menuName = "CustomerLists")]
public class CustomerList: ScriptableObject
{
    public List<ShoppingList> shoppingListList = new List<ShoppingList>();
}
