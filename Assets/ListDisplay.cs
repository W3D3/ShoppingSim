using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDisplay : MonoBehaviour
{

	public GameObject itemTemplate;
	public ShoppingList shoppingList;


    // Start is called before the first frame update
    void Start()
    {
		Debug.Log(shoppingList);
		shoppingList.itemList.ForEach(delegate(Item item)
		{
			Debug.Log(item);
			GameObject itemObject = Instantiate(itemTemplate) as GameObject;
			itemObject.GetComponent<ItemDisplay>().SetValues(item);
		}); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
