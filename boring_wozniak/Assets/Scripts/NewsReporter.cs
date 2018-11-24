using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsReporter : Enemy {

	public float speed;
	private Vector2 direction;

	private GameObject[] boundaries;

	// Update is called once per frame
	void Awake() {
		score = 5;
		boundaries = GameManager.instance.GetComponent<GameManager>().boundaries;
	}
	void Update () {

		//FollowPlayer
		if (GameObject.Find("Trump"))
		{
			direction = GameManager.instance.GetComponent<GameManager>().trump.transform.position - transform.position;
			direction.Normalize();
			if (direction.x != 0f || direction.y != 0f)
				transform.position = new Vector2(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime));
		}
		else
			anim.SetBool("moving", false);

		//Manage boundares
		if (transform.position.x > boundaries[0].transform.position.x)
		{
			transform.position = new Vector2(boundaries[0].transform.position.x, transform.position.y);
		}
		else if (transform.position.x < boundaries[2].transform.position.x)
		{
			transform.position = new Vector2(boundaries[2].transform.position.x, transform.position.y);
		}

		if (transform.position.y < boundaries[1].transform.position.y)
		{
			transform.position = new Vector2(transform.position.x, boundaries[1].transform.position.y);
		}
		else if (transform.position.y > boundaries[3].transform.position.y)
		{
			transform.position = new Vector2(transform.position.x, boundaries[3].transform.position.y);
		}

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
