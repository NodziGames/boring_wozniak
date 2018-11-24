using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeBlood : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("DestroyItself", 0.35f);
	}
	
	// Update is called once per frame
	void DestroyItself() {
		Destroy(gameObject);
	}
}
