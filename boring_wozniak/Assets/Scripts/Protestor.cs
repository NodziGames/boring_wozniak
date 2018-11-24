using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protestor : Enemy {

	// Use this for initialization
	
	// Update is called once per frame
	void Awake() { 
		this.score = 8;
	}
	void Update () {


		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
	}
}
