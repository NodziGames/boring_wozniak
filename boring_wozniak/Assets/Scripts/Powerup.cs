using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	// Use this for initialization
	[SerializeField]
	public float duration = 30f;
	private GameObject trump;

	void Start () {
		trump = GameObject.Find("Trump");
		this.transform.rotation = Random.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(this.transform.position, new Vector3(0,0,0), Time.deltaTime * 15.5f);
	}


}
