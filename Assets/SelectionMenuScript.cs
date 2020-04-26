using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                var shelf = hit.transform.GetComponent<Shelf>();
                if (shelf != null)
                {
                    if (GameManager.selectedItem != null)
                    {
                        Debug.Log("Placing item on " + hit.transform.name); // ensure you picked right object
                        int paid = shelf.Shelve(GameManager.selectedItem);
                        GameManager.currentMoney -= paid;
                    }
                    else
                    {
                        Debug.Log("Removing item from " + hit.transform.name); // ensure you picked right object
                        var unShelved = shelf.UnShelve();
                        GameManager.currentMoney += unShelved.price / 2;
                    }
                    
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            GameManager.selectedItem = null;
        }

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }
}