using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float time;
    float timerInterval = 1.0f;
    float tick;

    // Use this for initialization
    void Awake()
    {
        time = (int)Time.time;
        tick = timerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = time.ToString();

        // avoir que les seconde
        time = (int)Time.time;

        if(time == tick)
        {
            tick = time + timerInterval;
        }
    }
}
