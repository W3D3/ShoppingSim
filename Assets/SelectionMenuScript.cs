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
            Debug.Log("Pressed primary button.");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                
                var shelf = hit.transform.GetComponent<Shelf>();
                if (shelf != null && GameManager.selectedItem != null)
                {
                    Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                    shelf.Shelve(GameManager.selectedItem);
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