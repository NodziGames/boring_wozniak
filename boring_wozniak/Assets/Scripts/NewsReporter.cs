using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsReporter : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer sr;

	public GameObject smallBlood;
	public GameObject largeBlood;
	public GameObject screenShakeSmall;
	public GameObject corpse;
	public float speed;

	private Animator anim;

	private Vector2 direction;

	public int hitPoints;


	void Start () {

		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
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

	public void TakeDamage(int damage)
	{
		hitPoints -= damage;

		Instantiate(smallBlood, transform.position, Quaternion.identity);

		sr.enabled = false;
		Invoke("TurnRendererOnAgain", 0.05f);

		if (hitPoints <= 0)
		{
			Instantiate(largeBlood, transform.position, Quaternion.identity);
			Instantiate(screenShakeSmall, transform.position, Quaternion.identity);
			Instantiate(corpse, transform.position, Quaternion.identity);
			SoundManager.instance.PlayOnceAltered(1);
			Destroy(gameObject);
		}
	}

	void TurnRendererOnAgain()
	{
		sr.enabled = true;
	}
}
