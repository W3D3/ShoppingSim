using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;
	public static int gameLength = 90;
	public static int openHour = 7;
	public static int closingHour = 21;

    private GameManager()
    {
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    public static List<Transform> getAllItemTransforms()
    {
        var items = new List<Transform>();
        foreach (var o in GameObject.FindGameObjectsWithTag("Item"))
        {
            Transform transform = o.GetComponent<Transform>();
            if (transform != null) items.Add(transform);
        }

        return items;
    }
}