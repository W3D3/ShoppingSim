using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerDisplay : MonoBehaviour
{

    public GameObject shoppingListTemplate;
    public CustomerList cList;


    void Start()
    {
        //int counter = 0;
        List<ShoppingList> sortedList = cList.shoppingListList.OrderBy(o => o.spawnDelay).ToList();


        //If the elements in the list are not destroyed after the customer has finished - check for hide or other property that shows that the customer is done and ignore said customer
        for (int i = 0; i < sortedList.Count && i < 4; i++) // Loop through List with for
        {
            GameObject slobject = Instantiate(shoppingListTemplate) as GameObject;
            slobject.GetComponent<ListDisplay>().SetValues(sortedList[i]);
            slobject.SetActive(true);
            slobject.transform.SetParent(shoppingListTemplate.transform.parent);
            slobject.transform.localPosition = new Vector2(0, 310 + i * -260);
        }


        /*
        sortedList.ForEach(delegate (ShoppingList sList)
        {
            Debug.Log("Here: " + sList);
            GameObject slobject = Instantiate(shoppingListTemplate) as GameObject;
            slobject.GetComponent<ListDisplay>().SetValues(sList);
            slobject.SetActive(true);
            slobject.transform.SetParent(shoppingListTemplate.transform.parent);
            slobject.transform.localPosition = new Vector2(0, 340 + counter * -210);
            counter++;
            if(counter>3)
                break;

        });
        */
    }
}
