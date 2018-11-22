using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreLabel;

    private int score;


	// Use this for initialization
	void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        scoreLabel.text = score.ToString();
	}

    private void Initialize()
    {
        score = 0;
    }

    public void AddPoint (int point)
    {
        score = score + point;
    }

}
