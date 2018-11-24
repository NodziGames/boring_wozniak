using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public GameObject explosion;
	public GameObject flash;
	private Vector3 lastPosition;
	public float accuracy;

	// Use this for initialization
	void Start () {

		lastPosition = transform.position;

		rb = GetComponent<Rigidbody2D>();

		Vector2 direction = GameManager.instance.trump.GetComponent<Trump>().cursorPos - new Vector2(transform.position.x, transform.position.y);
		direction = new Vector2(direction.x + Random.Range(accuracy, -accuracy), direction.y + Random.Range(accuracy, -accuracy));
		direction.Normalize();
		rb.velocity = direction * speed;
		transform.up = direction;

		Instantiate(flash, transform.position + new Vector3(rb.velocity.x / 300f, rb.velocity.y / 300f, 0f), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		Vector2 direction = transform.position - lastPosition;
		RaycastHit2D hit = Physics2D.Raycast(lastPosition, direction);

		if (hit.collider != null)
		{
			if (hit.collider.tag == "HitBox")
			{
				Instantiate(explosion, lastPosition, Quaternion.identity);
				Destroy(gameObject);
			}

			if (hit.collider.tag == "Enemy")
			{
				Debug.Log("Ouch Fuck!");
				Instantiate(explosion, lastPosition, Quaternion.identity);
				Destroy(gameObject);

			}
		}

		lastPosition = transform.position;
	}
}
