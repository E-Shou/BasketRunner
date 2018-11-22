using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    Text timeText;
    float timer;

    void Start()
    {
        timeText = this.GetComponent<Text>();
        timer = 60 *3;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
       // int mseconds = Mathf.FloorToInt((timer - minutes * 60 - seconds) * 1000);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds /*mseconds*/);

        timeText.text = niceTime;

    }
}
