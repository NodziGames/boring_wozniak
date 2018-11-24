using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	public GameObject[] enemies;

	public int enemyHp;

	// Use this for initialization
	void Start () {
		Invoke("SpawnEnemy", 2f);
	}
	
	void SpawnEnemy()
	{
		GameObject enemy = enemies[Random.Range(0, enemies.Length)];
		GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);

		switch(newEnemy.gameObject.name)
		{
			case "Journalist(Clone)":
				newEnemy.GetComponent<Journalist>().hitPoints = enemyHp;
				break;
			case "Protestor(Clone)":
				newEnemy.GetComponent<Protestor>().hitPoints = enemyHp;
				break;
			case "NewsReporter(Clone)":
				newEnemy.GetComponent<NewsReporter>().hitPoints = enemyHp;
				break;
		}
		Destroy(gameObject);
	}
}
