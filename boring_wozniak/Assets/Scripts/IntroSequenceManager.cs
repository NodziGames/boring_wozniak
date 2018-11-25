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

	private int currentPos = 0;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			updateIntroSequence();
		}
	}

	public void updateIntroSequence () {
		if (currentPos < introSequencePanels.Length) {
			Debug.Log(currentPos);
            Animator panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
            if (currentPos == 0)
            {
                playButton.enabled = false;
				quitButton.enabled = false;
                panelAnimator.SetBool("slide_in", true);
            } else {
                panelAnimator = (Animator)introSequencePanels[currentPos - 1].GetComponent("Animator");
                panelAnimator.SetBool("slide_out", true);
                panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
                panelAnimator.SetBool("slide_in", true);
			}   
		} else {
			//just scene transition for now
			SceneManager.LoadScene("Main");
		}
        currentPos++;
	}

	public void QuitGame() {
		Application.Quit();
	}
}
