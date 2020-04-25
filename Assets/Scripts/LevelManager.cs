﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CustomerList customerList;

    public CustomerDisplay display;

    private SpawnScript _spawner;

    public float TimePassed
    {
        get { return _spawner.TimePassed; }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentLevel = this;
        _spawner = GetComponent<SpawnScript>();
        if (_spawner == null) Debug.LogError("No spawner on LevelManager!");

        Debug.Log("Starting game with " + customerList.shoppingListList.Count + " customers.");
        display.cList = customerList;
        _spawner.shoppingLists = new List<ShoppingList>(customerList.shoppingListList);
        // TODO do via button
        StartLevel();
    }

    public void StartLevel()
    {
        _spawner.Active = true;
    }
}