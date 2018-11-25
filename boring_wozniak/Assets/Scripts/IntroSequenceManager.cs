using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequenceManager : MonoBehaviour {

	public static IntroSequenceManager instance;

	public GameObject[] introSequencePanels;
	public Button playButton;
	public Button quitButton;
	public Button resetHighscoreButton;
	public GameObject fadeIn;

	private int currentPos = 0;

	public bool introStarted = false;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && introStarted) {
			updateIntroSequence();
		}
	}

	public void updateIntroSequence () {
		if (currentPos < introSequencePanels.Length) {
			Debug.Log(currentPos);
            Animator panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
            if (currentPos == 0)
            {
				introStarted = true;
                playButton.enabled = false;
				quitButton.enabled = false;
				resetHighscoreButton.enabled = false;
                panelAnimator.SetBool("slide_in", true);
            } else {
                panelAnimator = (Animator)introSequencePanels[currentPos - 1].GetComponent("Animator");
                panelAnimator.SetBool("slide_out", true);
                panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
                panelAnimator.SetBool("slide_in", true);
			}   
		} else {
			//just scene transition for now
			Instantiate(fadeIn, new Vector3(0f, 0f, 0f), Quaternion.identity, Camera.main.transform);
			Invoke("NextScene", 1f);
		}
        currentPos++;
	}

	public void QuitGame() {
		Application.Quit();
	}

	void NextScene()
	{
		SceneManager.LoadScene("Main");
	}

	public void ResetHighScore() {
		PlayerPrefs.SetInt("highscore", 0);
	}
}
