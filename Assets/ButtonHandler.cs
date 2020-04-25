using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
	
	public void ButtonClicked(Object item){
		Cursor.SetCursor(((Item)item).texture, Vector2.zero, CursorMode.Auto);
		GameManager.selectedItem = (Item)item;
	}

}
