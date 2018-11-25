﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	public static GameUIManager instance;

	public Text currentScoreText;
	public Text highScoreText;
	public Text currentWaveText;
	public GameObject deathPanel;
	public GameObject deathText;

	// Use this for initialization
	void Start () {
		instance = this;

		highScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateCurrentScoreText (int currentScore) {
		currentScoreText.text = currentScore.ToString();
	}

	public void UpdateCurrentWaveText (int currentWave) {
		currentWaveText.text = "WAVE " + (currentWave + 1);
	}

	public void UpdateHighScoreText (int highScore) {
		highScoreText.text = highScore.ToString();
	}

	public void OpenDeathScreen (bool isDead) {
		deathPanel.SetActive(isDead);
	}

	public void CloseDeathText () {
		deathText.SetActive(false);
	}
}
