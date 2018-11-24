using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journalist : Enemy {

	// Use this for initialization
	
	void Start () {

		sr = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {


		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
	}
}
