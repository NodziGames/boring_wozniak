using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journalist : Enemy {

	// Use this for initialization

	
	// Update is called once per frame
	void Awake() {
		score = 10;
	}
	void Update () {


		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
	}
}
