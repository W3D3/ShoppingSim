using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShoppingList", menuName = "ShoppingLists" )]
public class ShoppingList : ScriptableObject
{

	public int spawnDelay;
    public List<Item> itemList = new List<Item>();
    public bool isInfected;
	public string timeOfArrival;

    public bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        CalculateTimeOfArrival();
	}

    public void CalculateTimeOfArrival()
    {
        timeOfArrival = GameManager.IngameSecondsToHourFormat(spawnDelay);
    }
}



