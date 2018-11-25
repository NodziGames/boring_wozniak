using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SlideTrump : MonoBehaviour {

	private SpriteRenderer sr;
	public GameObject fadeIn;
	private float speed = 100f;
	private float friction = 4f;

	private Vector2 direction;
	private GameObject[] boundaries;

	// Use this for initialization
	void Start()
	{

		sr = GetComponent<SpriteRenderer>();

		boundaries = GameManager.instance.GetComponent<GameManager>().boundaries;
		direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
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
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space) && Trump.isDead) {
			Trump.isDead = false;
			Instantiate(fadeIn, new Vector3(0f, 0f, 0f), Quaternion.identity, Camera.main.transform);
			Invoke("invokeSceneChange", 1.0f);
			GameUIManager.instance.CloseDeathText();
		}

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
			}
		}

	}

	void invokeSceneChange() {
		SceneManager.LoadScene("Main");
	}
}
