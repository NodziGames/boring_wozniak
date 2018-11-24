using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {

	private SpriteRenderer sr;
	private float speed = 200f;
	private float friction = 4f;
	private GameObject[] boundaries;

	private Vector2 direction;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();

		boundaries = GameManager.instance.GetComponent<GameManager>().boundaries;

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundaries[(int)e_Boundaries.LEFT].transform.position.x, boundaries[(int)e_Boundaries.RIGHT].transform.position.x),
			Mathf.Clamp(transform.position.y, boundaries[(int)e_Boundaries.DOWN].transform.position.y, boundaries[(int)e_Boundaries.UP].transform.position.y));

		if (GameObject.Find("Trump"))
		{
			direction = transform.position - GameManager.instance.GetComponent<GameManager>().trump.transform.position;
			direction.Normalize();
		}

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

		transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundaries[(int)e_Boundaries.LEFT].transform.position.x, boundaries[(int)e_Boundaries.RIGHT].transform.position.x),
			Mathf.Clamp(transform.position.y, boundaries[(int)e_Boundaries.DOWN].transform.position.y, boundaries[(int)e_Boundaries.UP].transform.position.y));
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
