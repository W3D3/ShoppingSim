using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items" )]
public class Item : ScriptableObject
{
    public new string name;
    public int price;
    public Sprite sprite;
	public Texture2D texture;
	public GameObject prefab;
}
