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

    private float _timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.SetText("Money not initialized.");
        timeText.SetText("Time not initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        _timePassed += Time.deltaTime;
        moneyText.SetText("€ " + GameManager.currentMoney/100 + "." + GameManager.currentMoney%100);
        timeText.SetText(GameManager.IngameSecondsToHourFormat((int)_timePassed));

    }

    public void PressStartButton(Object startButton)
    {
        //Toggle Button
        ((GameObject)startButton).SetActive(false);

        //Start Music
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        //Start Game
    }
}
