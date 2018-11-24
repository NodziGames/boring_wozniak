using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protestor : Enemy {

	// Use this for initialization
	private float waitTime = 3f;
	private float walkTime = 3f;
	private float throwTime = 5f;
	public float speed;
	private Vector2 direction;
	private bool moving = false;
	public GameObject rock;

	// Update is called once per frame
	void Awake() { 
		this.score = 8;
	}
	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		Invoke("StartMoving", 0f);
		Invoke("ThrowRock", throwTime + Random.Range(-1f, 1f));
	}

	void Update () {

		if (moving)
		{
			transform.position = new Vector2(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime));
		}

		anim.SetBool("running", moving);

		if (GameObject.Find("Trump"))
		{
			if (GameManager.instance.GetComponent<GameManager>().trump.transform.position.x > transform.position.x)
			{
				sr.flipX = false;
			}
			else
			{
				sr.flipX = true;
			}
		}

		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
	}

	void TurnRendererOnAgain()
	{
		sr.enabled = true;
	}

	void StartMoving()
	{
		moving = true;
		direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		direction.Normalize();

		Invoke("StopMoving", walkTime + Random.Range(-1f, 1f));
	}

	void StopMoving()
	{
		moving = false;
		Invoke("StartMoving", waitTime + Random.Range(-1f, 1f));
	}

	void ThrowRock()
	{
		Instantiate(rock, transform.position, Quaternion.identity);
		SoundManager.instance.PlayOnceAltered(3);
		Invoke("ThrowRock", throwTime + Random.Range(-1f, 1f));
	}
}
