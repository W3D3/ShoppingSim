using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform spawn;
    public Checkout checkOut;
    public Transform exit;
    public Customer customerPrefab;

    [HideInInspector]
    public List<ShoppingList> shoppingLists;

    private float _timePassed = 0f;
    private bool _active = false;

    public bool Active
    {
        get => _active;
        set => _active = value;
    }

    public float TimePassed => _timePassed;

    // Update is called once per frame
    void Update()
    {
        if (!_active) return;
        List<ShoppingList> spawnedLists = new List<ShoppingList>();
        Debug.Log("Time passed " + Time.deltaTime);
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
        customerPrefab.exit = exit;
        customerPrefab.checkout = checkOut;
        customerPrefab.shoppingList = shoppingList;
        customerPrefab.name = shoppingList.name;
        // TODO select from a list of prefabs
        var customer = Instantiate(customerPrefab, spawn);
    }
    
    
}