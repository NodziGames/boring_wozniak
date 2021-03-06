﻿using System.Collections;
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
	public GameObject charge;

	private GameObject[] boundaries;

	// Update is called once per frame
	void Awake() {
		score = 10;
	}
	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		Invoke("StartMoving", 0f);
		Invoke("StunStart", stunWait);
		boundaries = GameManager.instance.GetComponent<GameManager>().boundaries;
	}
	void Update () {

		if (moving)
		{
			transform.position = new Vector2(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime));
		}

		anim.SetBool("running", moving);

		//Manage boundares
		transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundaries[(int)e_Boundaries.LEFT].transform.position.x, boundaries[(int)e_Boundaries.RIGHT].transform.position.x),
			Mathf.Clamp(transform.position.y, boundaries[(int)e_Boundaries.DOWN].transform.position.y, boundaries[(int)e_Boundaries.UP].transform.position.y));

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
		if (GameObject.Find("Trump"))
		{
			Instantiate(charge, new Vector2(transform.position.x, transform.position.y - 7f), Quaternion.identity, this.transform);
			Invoke("Stun", 1.2f);
			SoundManager.instance.PlayOnce(4);
		}
	}

	void Stun()
	{
		Instantiate(stun, new Vector2(0, 0), Quaternion.identity);
		Invoke("StunStart", stunWait);
	}
}
