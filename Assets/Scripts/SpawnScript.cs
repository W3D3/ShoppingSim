using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform spawn;
    public Checkout checkOut;
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
        List<Transform> afterShoppingGoals = new List<Transform>();
        //afterShoppingGoals.Add(checkOut);
        //afterShoppingGoals.Add(exit);

        customerPrefab.afterShoppingTargets = afterShoppingGoals;
        customerPrefab.exit = exit;
        customerPrefab.checkout = checkOut;
        customerPrefab.shoppingList = shoppingList;
        customerPrefab.name = shoppingList.name;
        // TODO select from a list of prefabs
        var customer = Instantiate(customerPrefab, spawn);
    }
}