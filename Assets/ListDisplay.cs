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
		int counter = 0;
		Debug.Log(shoppingList);
		shoppingList.itemList.ForEach(delegate(Item item)
		{
			Debug.Log(item);
			GameObject itemObject = Instantiate(itemTemplate) as GameObject;
			itemObject.GetComponent<ItemDisplay>().SetValues(item);
			itemObject.SetActive(true);
			itemObject.transform.SetParent(itemTemplate.transform.parent);
			itemObject.transform.localPosition = new Vector2(10,-30 - counter*35);
			counter++;

		}); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
