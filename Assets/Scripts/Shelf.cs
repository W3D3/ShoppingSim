using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    private Item _shelvedItem;

    private GameObject _itemObject;
    
    public int Shelve(Item item)
    {
        int price = 0;
        int shelvedItemPrice = _shelvedItem != null ? _shelvedItem.price : 0;
        price = item.price / 2 - shelvedItemPrice / 2;
        if (price > GameManager.currentMoney) return 0;
        
        if (_itemObject != null)
        {
            UnShelve();
        }
        
        // enough money here, so create the item
        _shelvedItem = item;
        var itemPrefab = item.prefab;
        itemPrefab.tag = "Item";
        _itemObject = Instantiate(itemPrefab, transform);
        return price;
    }
    
    public Item UnShelve()
    {
        if (_itemObject != null)
        {
            Debug.LogWarning(_itemObject);
            Destroy(_itemObject.gameObject);
        }
        return _shelvedItem;
    }
}
