using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	protected float duration;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool shouldPickupPowerup(GameObject player) {
		if (this.transform.position == player.transform.position) {
			return true;
		}
		return false;
	}
}
