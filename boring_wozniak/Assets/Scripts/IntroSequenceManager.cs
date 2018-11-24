using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequenceManager : MonoBehaviour {

	public static IntroSequenceManager instance;

	public GameObject[] introSequencePanels;

	private int currentPos = 0;

	// Use this for initialization
	void Start () {
		instance = this;

        Animator panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
        panelAnimator.SetBool("slide_in", true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			updateIntroSequence();
		}
	}

	void updateIntroSequence () {
		if (currentPos < introSequencePanels.Length - 1) {
			Animator panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
            panelAnimator.SetBool("slide_out", true);
			currentPos++;
			panelAnimator = (Animator)introSequencePanels[currentPos].GetComponent("Animator");
			panelAnimator.SetBool("slide_in", true);
		}
	}
}
