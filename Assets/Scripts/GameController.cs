using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text scoreLabel;

    private int score;
    float timer;

    // Use this for initialization
    void Start () {
        Initialize();
        timer = 60 * 3;
    }

    // Update is called once per frame
    void Update () {
        scoreLabel.text = score.ToString();
        timer -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        // int mseconds = Mathf.FloorToInt((timer - minutes * 60 - seconds) * 1000);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds /*mseconds*/);

        if (minutes == 0 && seconds == 0)
        {
            Invoke("ReturnToTitle", 1.0f);
        }

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void Initialize()
    {
        score = 0;
    }

    public void AddPoint(int point)
    {
        score = score + point;
    }

    void ReturnToTitle()
    {
        Application.LoadLevel("Title");
    }

}
