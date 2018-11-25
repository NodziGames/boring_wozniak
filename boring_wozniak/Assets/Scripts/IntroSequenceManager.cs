using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequenceManager : MonoBehaviour {

	public static IntroSequenceManager instance;

	public GameObject[] introSequencePanels;
	public Button playButton;

	private int currentPos = 0;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			updateIntroSequence();
		}
	}

	public void updateIntroSequence () {

		if (currentPos == 0) {
			playButton.enabled = false;
		}
		
		if (currentPos < introSequencePanels.Length - 1) {
			Animator panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
            panelAnimator.SetBool("slide_out", true);
			currentPos++;
			panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
			panelAnimator.SetBool("slide_in", true);
		} else {
			//just scene transition for now
			SceneManager.LoadScene("Main");
		}
	}
}
