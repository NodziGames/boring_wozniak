using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {

	private SpriteRenderer sr;
	private float speed = 200f;
	private float friction = 4f;

	private Vector2 direction;

	// Use this for initialization
	void Start () {

		sr = GetComponent<SpriteRenderer>();

		direction = transform.position - GameManager.instance.GetComponent<GameManager>().trump.transform.position;
		direction.Normalize();

		if (direction.x < 0)
		{
			sr.flipX = false;
		}
		else
		{
			sr.flipX = true;
		}

	}
	
	// Update is called once per frame
	void Update () {

		speed -= friction;

		transform.position = new Vector2(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime));

		sr.sortingOrder = (Mathf.RoundToInt(transform.position.y) + 12) * -1;

		if (speed <= 0f)
		{
			if (friction != 0f)
			{
				speed = 0f;
				friction = 0f;
				Invoke("DestroyItself", 10f);
			}
		}

	}

	void DestroyItself()
	{
		Destroy(gameObject);
	}
}
