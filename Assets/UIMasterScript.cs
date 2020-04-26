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

    public TMP_Dropdown dropdown;

    public CustomerList level1;
    public CustomerList level2;
    public CustomerList level3;

    private GameObject startButton;

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

        GameManager.uiScript = this;
        //Toggle Button
        ((GameObject) startButton).SetActive(false);
        this.startButton = ((GameObject)startButton);
        //Start Music
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        Debug.Log(dropdown.value);

        switch (dropdown.value)
        {
            case 0: GameManager.currentLevel.customerList = level1; break;
            case 1: GameManager.currentLevel.customerList = level2; break;
            case 2: GameManager.currentLevel.customerList = level3; break;
        }

        dropdown.gameObject.SetActive(false);
        //Start Game
        GameManager.currentLevel.StartLevel();
    }

    public void NewStart()
    {
        startButton.SetActive(true);
        dropdown.gameObject.SetActive(true);

    }
}