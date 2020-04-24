using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShoppingList", menuName = "ShoppingLists" )]
public class ShoppingList : ScriptableObject
{

	public int spawnDelay;
    public string debugField;
    public List<Item> itemList = new List<Item>();
    public bool isInfected;
	public string timeOfArrival;

    // Start is called before the first frame update
    void Start()
    {
		CalculateTimeOfArrival();
	}

	public void CalculateTimeOfArrival(){
		Debug.Log("Calc TimeOfArrival: " +timeOfArrival);
		int minutesPerGameSecond = ((GameManager.closingHour - GameManager.openHour)*60)/GameManager.gameLength;
		int hour = GameManager.openHour + ((spawnDelay*minutesPerGameSecond)/60);
		int minutes = (spawnDelay*minutesPerGameSecond) % 60;
		timeOfArrival = hour + ":" + minutes;
		Debug.Log("Calc2 TimeOfArrival: " +timeOfArrival);


	}


}



