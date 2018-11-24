using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journalist : Enemy {

	// Use this for initialization

	private float waitTime = 3f;
	private float walkTime = 3f;
	private float stunWait = 4f;
	public GameObject stun;
	public float speed;
	private Vector2 direction;
	private bool moving = false;

	// Update is called once per frame
	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		Invoke("StartMoving", Random.Range(waitTime - 1f, waitTime + 1f));
		Invoke("StunStart", stunWait);
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

	void StunStart()
	{
		Invoke("Stun", 1.2f);
		SoundManager.instance.PlayOnceAltered(4);
	}

	void Stun()
	{
		Instantiate(stun, new Vector2(0, 0), Quaternion.identity);
		Invoke("StunStart", stunWait);
	}
}
