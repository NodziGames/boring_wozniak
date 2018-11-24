using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trump : MonoBehaviour {

	// Use this for initialization
	public float speed;

	private Animator ac;

	public Vector2 cursorPos;

	private SpriteRenderer sr;

	public GameObject deporter;
	public SpriteRenderer deporterSr;
	public Vector2 direction;
	public GameObject bullet;
	public GameObject corpse;
	public GameObject bloodLarge;
	public GameObject screenShakeLarge;

	//Gun stuff
	public float fireRate;
	public float accuracy;
	public bool doubleShot;
	public int damage;

	private bool shotReady;
	
	private Rigidbody2D rb;

	void Start () {

		ac = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		deporterSr = deporter.gameObject.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		shotReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		bool up_key = Input.GetKey(KeyCode.W);
		bool down_key = Input.GetKey(KeyCode.S);
		bool left_key = Input.GetKey(KeyCode.A);
		bool right_key = Input.GetKey(KeyCode.D);

		float vspeed = 0f;
		float hspeed = 0f;

		if (up_key)
		{
			vspeed += 1f;
		}

		if (down_key)
		{
			vspeed -= 1f;
		}

		if (left_key)
		{
			hspeed -= 1f;
		}

		if (right_key)
		{
			hspeed += 1f;
		}

		//Shooting
		if (Input.GetMouseButton(0) && shotReady)
		{
			shotReady = false;
			Invoke("ResetShot", fireRate);
			GameManager.instance.cameraObj.GetComponent<CameraControl>().GunKick(2.5f);

			if (doubleShot == false)
			{
				GameObject newBullet = Instantiate(bullet, deporter.transform.position, Quaternion.identity);
				Bullet component = newBullet.GetComponent<Bullet>();
				component.accuracy = accuracy;
				component.damage = damage;
			}
			else
			{
				GameObject newBullet = Instantiate(bullet, deporter.transform.position, Quaternion.identity);
				Bullet component = newBullet.GetComponent<Bullet>();
				component.accuracy = accuracy * 2;
				component.damage = damage;
				newBullet = Instantiate(bullet, deporter.transform.position, Quaternion.identity);
				component = newBullet.GetComponent<Bullet>();
				component.accuracy = accuracy * 2;
				component.damage = damage;
			}
			
			SoundManager.instance.PlayOnceAltered(0);
		}

		//Normalize to prevent faster diagonal movement

		Vector2 move = new Vector2(hspeed, vspeed);

		move = move.normalized * Time.deltaTime * speed;

		//transform.position = new Vector2(transform.position.x + move.x, transform.position.y + move.y);
		rb.velocity = move;

		//Handle Animations

		if (hspeed != 0.0f || vspeed != 0.0f)
		{
			ac.SetBool("running", true);
		}
		else
		{
			ac.SetBool("running", false);
		}

		//Find Cursos Pos
		cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


		//Update orientation
		if (transform.position.x < cursorPos.x)
		{
			sr.flipX = false;
		}
		else
		{
			sr.flipX = true;
		}

		//Update rendering depth
		sr.sortingOrder = Mathf.RoundToInt(transform.position.y) * -1;
		deporterSr.sortingOrder = sr.sortingOrder + 1;
		deporterSr.flipX = sr.flipX;

		if (deporterSr.flipX)
		{
			deporter.transform.localPosition = new Vector2(-5.0f, deporter.transform.localPosition.y);
		}
		else
		{
			deporter.transform.localPosition = new Vector2(5.0f, deporter.transform.localPosition.y);
		}

		direction = new Vector2(cursorPos.x - transform.position.x, cursorPos.y - transform.position.y);
		deporter.transform.up = direction;


		
	}

	void ResetShot()
	{
		shotReady = true;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Enemy" || collision.transform.tag == "Rock")
		{
			Instantiate(corpse, transform.position, Quaternion.identity);
			Instantiate(bloodLarge, transform.position, Quaternion.identity);
			Instantiate(screenShakeLarge, transform.position, Quaternion.identity);
			SoundManager.instance.PlayOnceAltered(2);
			Destroy(gameObject);
		}
	}
}
