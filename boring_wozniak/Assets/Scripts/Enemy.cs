using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	protected SpriteRenderer sr;
	protected int score;
	[SerializeField]
	protected float dropPercentage = 100;

	public GameObject smallBlood;
	public GameObject largeBlood;
	public GameObject screenShakeSmall;
	public GameObject corpse;
	public GameObject[] powerup;
	protected Animator anim;

	public int hitPoints;
	protected GameManager gameManager;


	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		gameManager = GameManager.instance.GetComponent<GameManager>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(int damage)
	{
		hitPoints -= damage;

		Instantiate(smallBlood, transform.position, Quaternion.identity);

		sr.enabled = false;
		Invoke("TurnRendererOnAgain", 0.05f);

		if (hitPoints <= 0)
		{
			this.spawnPowerupOnDeath();
			
			Instantiate(largeBlood, transform.position, Quaternion.identity);
			Instantiate(screenShakeSmall, transform.position, Quaternion.identity);
			Instantiate(corpse, transform.position, Quaternion.identity);
			gameManager.score += this.score;
			SoundManager.instance.PlayOnceAltered(1);
			Destroy(gameObject);
		}
	}

	void TurnRendererOnAgain()
	{
		sr.enabled = true;
	}

	void spawnPowerupOnDeath() {
		int dropInt = Random.Range(0, 100);
		if (dropInt < dropPercentage) {
			int randomType = Random.Range(0, powerup.Length);
			Instantiate(powerup[randomType], this.transform.position, this.transform.rotation);
		}
	}
}
