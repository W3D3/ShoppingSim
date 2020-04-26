using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager _instance;
	public static int gameLength = 90;
	public static int openHour = 7;
	public static int closingHour = 21;

	public static Item selectedItem = null;
    public static int currentMoney;

    public static LevelManager currentLevel;

    private GameManager()
    {
    }

    public static LevelManager CurrentLevel => currentLevel;

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

    public static string IngameSecondsToHourFormat(int seconds)
    {
        int minutesPerGameSecond = ((closingHour - openHour) * 60) / gameLength;
        int hour = openHour + ((seconds * minutesPerGameSecond) / 60);
        string minutes = ""+(seconds * minutesPerGameSecond) % 60;
        if (minutes.Length == 1)
            minutes = "0" + minutes;
        return hour + ":" + minutes;
    }

    public static void GameOver()
    {
        Time.timeScale = 0;
        // TODO show game over screen
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}