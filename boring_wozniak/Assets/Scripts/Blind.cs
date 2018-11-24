using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke("DestroyItself", 1.9f);
		
	}
	
	void DestroyItself()
	{
		Destroy(gameObject);
	}
}
