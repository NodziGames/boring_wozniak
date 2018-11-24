using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsReporter : Enemy {

	// Use this for initialization
	private SpriteRenderer sr;

	public GameObject smallBlood;
	public GameObject largeBlood;
	public GameObject screenShakeSmall;
	public GameObject corpse;
	public float speed;

	private Vector2 direction;


	void Start () {

		sr = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {

		//FollowPlayer
		direction = GameManager.instance.GetComponent<GameManager>().trump.transform.position - transform.position;
		direction.Normalize();
		transform.position = new Vector2(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime));

		if (direction.x < 0)
		{
			sr.flipX = true;
		}
		else
		{
			sr.flipX = false;
		}


		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
	}

}
