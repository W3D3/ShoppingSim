using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListDisplay : MonoBehaviour
{

	public GameObject itemTemplate;
	public ShoppingList shoppingList;
	public TextMeshProUGUI timeArrivalText;


    // Start is called before the first frame update
    void Start()
    {
		shoppingList.CalculateTimeOfArrival();
		timeArrivalText.SetText("Arrival: " +shoppingList.timeOfArrival);
		int counter = 0;
		shoppingList.itemList.ForEach(delegate(Item item)
		{
			GameObject itemObject = Instantiate(itemTemplate) as GameObject;
			itemObject.GetComponent<ItemDisplay>().SetValues(item);
			itemObject.SetActive(true);
			itemObject.transform.SetParent(itemTemplate.transform.parent);
			itemObject.transform.localPosition = new Vector2(110,-30 -counter*40);
			counter++;

		}); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValues(ShoppingList shoppingList)
    {
        this.shoppingList = shoppingList;
    }
}
