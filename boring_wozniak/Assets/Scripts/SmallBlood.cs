using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBlood : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke("DestroyYourself", 0.2f);
		
	}
	
	// Update is called once per frame
	void DestroyYourself()
	{
		Destroy(gameObject);
	}
}
