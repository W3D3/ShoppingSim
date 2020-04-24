using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform spawn;
    public Transform checkOut;
    public Transform exit;
    public Customer customerPrefab;

    public List<ShoppingList> shoppingLists;

    private float _timePassed = 0f;

    // Update is called once per frame
    void Update()
    {
        List<ShoppingList> spawnedLists = new List<ShoppingList>();
        _timePassed += Time.deltaTime;
        foreach (var shoppingList in shoppingLists)
        {
            if (shoppingList.spawnDelay <= _timePassed)
            {
                SpawnCustomerWithShoppingList(shoppingList);
                spawnedLists.Add(shoppingList);
            }
        }

        shoppingLists.RemoveAll(spawnedLists.Contains);
    }

    private void SpawnCustomerWithShoppingList(ShoppingList shoppingList)
    {
        List<Transform> goals = new List<Transform>();
        foreach (var item in shoppingList.itemList)
        {
            int goalCount = goals.Count;
            foreach (var levelItem in GameObject.FindGameObjectsWithTag("Item"))
            {
                /*
                * TODO currently we get the first i.e. a random item with the same name,
                * change this to something like closest?
                */
                if (levelItem.name == item.name)
                {
                    if (!goals.Contains(levelItem.transform))
                    {
                        goals.Add(levelItem.transform);
                        break;
                    }
                }
            }
            if (goals.Count == goalCount) // no item found
            {
                // TODO Frustrate customer when no element can be found?
                Debug.Log("Cannot find a proper item to pick up for " + item.name);
            }
        }
        goals.Add(checkOut);
        goals.Add(exit);

        customerPrefab.goals = goals;
        // TODO select from a list of prefabs
        var customer = Instantiate(customerPrefab, spawn);
    }
}