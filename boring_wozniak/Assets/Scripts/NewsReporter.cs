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
		transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundaries[(int)e_Boundaries.LEFT].transform.position.x, boundaries[(int)e_Boundaries.RIGHT].transform.position.x),
			Mathf.Clamp(transform.position.y, boundaries[(int)e_Boundaries.DOWN].transform.position.y, boundaries[(int)e_Boundaries.UP].transform.position.y));

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
