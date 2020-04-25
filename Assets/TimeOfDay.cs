using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentLevelTimePassed = GameManager.currentLevel.TimePassed;
        var angle = map(currentLevelTimePassed, 0, GameManager.gameLength, 0, 180);
        //Debug.Log(angle);
        var eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3(
            angle,
            100,
            0
        );
        transform.eulerAngles = eulerAngles;
        //this.transform.rotation = transform.rotation * angleAxis;
    }
    
    private float map(float x, long in_min, long in_max, long out_min, long out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
