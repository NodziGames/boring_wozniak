using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protestor : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer sr;

	public GameObject smallBlood;
	public GameObject largeBlood;
	public GameObject screenShakeSmall;

	public int hitPoints;


	void Start () {

		sr = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {


		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
	}

	public void TakeDamage( int damage)
	{
		hitPoints -= damage;

		Instantiate(smallBlood, transform.position, Quaternion.identity);

		sr.enabled = false;
		Invoke("TurnRendererOnAgain", 0.05f);

		if (hitPoints <= 0)
		{
			Instantiate(largeBlood, transform.position, Quaternion.identity);
			Instantiate(screenShakeSmall, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	void TurnRendererOnAgain()
	{
		sr.enabled = true;
	}
}
