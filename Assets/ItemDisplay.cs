using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemDisplay : MonoBehaviour
{

    public Item item;

    public TextMeshProUGUI nameText;
    public Image itemImage;

	public void SetValues(Item item){
	    nameText.text = item.name;
        itemImage.sprite = item.sprite;
	}

//    // Update is called once per frame
//    void Update()
//    {
//
//    }
}
