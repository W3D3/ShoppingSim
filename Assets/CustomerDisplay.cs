using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerDisplay : MonoBehaviour
{

    public GameObject shoppingListTemplate;
    public CustomerList cList;


    private List<GameObject> spawnedObjects;
    
    void Start()
    {
        spawnedObjects = new List<GameObject>();
    }

    void Update()
    {
        //RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }
        //int counter = 0;
        List<ShoppingList> sortedList = cList.shoppingListList.OrderBy(o => o.spawnDelay).ToList();

        //If the elements in the list are not destroyed after the customer has finished - check for hide or other property that shows that the customer is done and ignore said customer
        for (int i = 0; i < sortedList.Count && i < 4; i++) // Loop through List with for
        {
            if (sortedList[i].isFinished)
                continue;
            GameObject slobject = Instantiate(shoppingListTemplate) as GameObject;
            slobject.GetComponent<ListDisplay>().SetValues(sortedList[i]);
            slobject.SetActive(true);
            slobject.transform.SetParent(shoppingListTemplate.transform.parent);
            slobject.transform.localPosition = new Vector2(0, 310 + i * -260);
            spawnedObjects.Add(slobject);
        }
    }
}
