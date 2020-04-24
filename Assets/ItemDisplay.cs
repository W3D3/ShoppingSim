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


    // Start is called before the first frame update
    void Start()
    {
		nameText.text = item.name;
        itemImage.sprite = item.sprite;
    }

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
