using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMasterScript : MonoBehaviour
{

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI timeText;

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
        moneyText.SetText("€ " + GameManager.currentMoney);
        timeText.SetText(GameManager.IngameSecondsToHourFormat((int)_timePassed));

    }
}
