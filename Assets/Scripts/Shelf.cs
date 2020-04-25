using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    // Start is called before the first frame update
    public void Shelve(Item item)
    {
        var itemPrefab = item.prefab;
        Instantiate(itemPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
