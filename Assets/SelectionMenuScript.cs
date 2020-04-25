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
            Debug.Log("Pressed primary button.");

        if (Input.GetMouseButtonDown(1)){
		    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
			GameManager.selectedItem = null;
		}

        if (Input.GetMouseButtonDown(2))
            Debug.Log("Pressed middle click.");
    }
}
