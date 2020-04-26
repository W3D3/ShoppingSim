using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMasterScript : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI timeText;
    public AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.SetText("Money not initialized.");
        timeText.SetText("Time not initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.SetText("€ " + GameManager.currentMoney / 100 + "." + GameManager.currentMoney % 100);
        timeText.SetText(GameManager.IngameSecondsToHourFormat((int) GameManager.currentLevel.TimePassed));
    }

    public void PressStartButton(Object startButton)
    {
        //Toggle Button
        ((GameObject) startButton).SetActive(false);

        //Start Music
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        //Start Game
        GameManager.currentLevel.StartLevel();
    }
}