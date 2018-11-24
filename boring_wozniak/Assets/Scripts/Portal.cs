using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		Invoke("SpawnEnemy", 2f);
	}
	
	void SpawnEnemy()
	{
		GameObject enemy = enemies[Random.Range(0, enemies.Length)];
		Instantiate(enemy, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
