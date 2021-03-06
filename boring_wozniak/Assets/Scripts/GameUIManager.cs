﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	public static GameUIManager instance;

	public Text currentScoreText;
	public Text highScoreText;
	public Text currentWaveText;
	public GameObject difficultyUpImage;
	private bool difficultyImageEnabled;
	private float difficultyImageTimePassed;
	public GameObject deathPanel;
	public GameObject deathText;
	public bool isDeathScreen = false;
	public Text newHighScoreText;
	public Text newHighScoreNumText;
	public GameObject trophyImage;
	public GameObject pausePanel;

	private bool isPaused = false;

	// Use this for initialization
	void Start () {
		instance = this;

		highScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			PauseGame();
		}
		
		if (difficultyImageEnabled) {
			difficultyImageTimePassed += Time.deltaTime;
			if (difficultyImageTimePassed > 1f) {
                difficultyUpImage.GetComponent<Animator>().SetBool("drop_out", false);
                difficultyUpImage.SetActive(false);
				difficultyImageEnabled = false;
				difficultyImageTimePassed = 0;
			}
		}
	}

	public void UpdateCurrentScoreText (int currentScore) {
		currentScoreText.text = currentScore.ToString();
	}

	public void UpdateCurrentWaveText (int currentWave) {
		currentWaveText.text = "WAVE " + (currentWave);
		difficultyUpImage.SetActive(true);
		difficultyUpImage.GetComponent<Animator>().SetBool("drop_out", true);
		difficultyImageEnabled = true;
	}

	public void UpdateHighScoreText (int highScore) {
		highScoreText.text = highScore.ToString();
	}

	public void OpenDeathScreen (bool isDead) {
		deathPanel.SetActive(isDead);
		isDeathScreen = true;
	}

	public void AddNewHighScoreText (int highScore) {
		newHighScoreText.text = "NEW HIGHSCORE!";
		newHighScoreNumText.text = highScore.ToString();
		trophyImage.SetActive(true);
	}

	public void CloseDeathText () {
		deathText.SetActive(false);
        newHighScoreText.text = "";
        newHighScoreNumText.text = "";
	}

	public void PauseGame () {
		if (!isPaused)
        {
            Time.timeScale = 0.00001f;
            pausePanel.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            isPaused = false;
        }
	}

	public void QuitGame () {
		Application.Quit();
	}
}
