using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items" )]
public class Item : ScriptableObject
{
    public new string name;
    public double price;
    public Sprite sprite;

}
