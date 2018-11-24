using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke("DestroyItself", 1f);
		
	}
	
	void DestroyItself()
	{
		Destroy(gameObject);
	}
}
