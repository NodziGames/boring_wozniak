using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float offsetAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp_trump = GameManager.instance.trump.transform.position;

		Vector2 cursorPos = GameManager.instance.trump.GetComponent<Trump>().cursorPos;


		transform.position = Vector3.Lerp(transform.position, new Vector3(temp_trump.x - (((temp_trump.x - cursorPos.x) / 2) * offsetAmount), temp_trump.y - (((temp_trump.y - cursorPos.y) / 2) * (offsetAmount * 1.77f)), -10f), 0.1f);
	}

	public void GunKick(float amount)
	{
		float dir = 0f;
		if (GameManager.instance.trump.GetComponent<SpriteRenderer>().flipX)
			dir = -1f;
		else
			dir = 1f;
		transform.position = new Vector3(transform.position.x + (amount * dir), transform.position.y, -10f);
	}
}
