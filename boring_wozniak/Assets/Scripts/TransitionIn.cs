﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
	}
}
