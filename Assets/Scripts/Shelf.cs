using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    private Item _shelvedItem;

    private GameObject _itemObject;
    
    public void Shelve(Item item)
    {
        if (_itemObject != null)
        {
            UnShelve();
        }
        _shelvedItem = item;
        var itemPrefab = item.prefab;
        itemPrefab.tag = "Item";
        _itemObject = Instantiate(itemPrefab, transform);
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
