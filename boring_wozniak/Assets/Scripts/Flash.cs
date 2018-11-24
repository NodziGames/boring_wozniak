using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Invoke("DestroySelfLol", 0.15f);
		
	}
	
	void DestroySelfLol()
	{
		Destroy(gameObject);
	}
}
