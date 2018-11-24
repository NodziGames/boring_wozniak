using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	private Vector2 direction;
	public float speed;
	// Use this for initialization
	void Start () {

		if (GameObject.Find("Trump"))
		{
			direction = GameManager.instance.GetComponent<GameManager>().trump.transform.position - transform.position;
			direction.Normalize();
		}
		else
		{
			direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			direction.Normalize();
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector2(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime));
	}
}
