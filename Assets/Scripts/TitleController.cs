using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {
    public Text highScoreLabel;

	// Use this for initialization
	public void Start () {
        highScoreLabel.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
	}
	
	// Update is called once per frame
	public void OnStartButtonClicked () {
        Application.LoadLevel("Main");
	}
}
