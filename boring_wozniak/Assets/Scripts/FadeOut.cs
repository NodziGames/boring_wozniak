using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.localScale.x > 0)
		{
			transform.localScale = new Vector2(transform.localScale.x - 0.1f, transform.localScale.y -0.1f);
		}
		else
			Destroy(gameObject);
		
	}
}
