using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	public Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		Invoke("DestroyFunc", 0.25f);
	}
	
	void DestroyFunc()
	{
		Destroy(gameObject);
	}
}
