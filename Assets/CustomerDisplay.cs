using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDisplay : MonoBehaviour
{

    public GameObject shoppingListTemplate;
    public CustomerList cList;
   
    void Start()
    {
        int counter = 0;
        cList.shoppingListList.ForEach(delegate (ShoppingList sList)
        {
            Debug.Log("Here: " + sList);
            GameObject slobject = Instantiate(shoppingListTemplate) as GameObject;
            slobject.GetComponent<ListDisplay>().SetValues(sList);
            slobject.SetActive(true);
            slobject.transform.SetParent(shoppingListTemplate.transform.parent);
            slobject.transform.localPosition = new Vector2(0, 340 + counter * -210);
            counter++;

        });
    }
}
