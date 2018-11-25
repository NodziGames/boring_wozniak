using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization

    public static GameManager instance = null;
	public GameObject trump;
	public GameObject cameraObj;
	public GameObject portal;
	public float spawnTime;
	public int spawnHP;
	public GameObject[] boundaries;

	//Tiane (Draw out score on GUI)
	public int score;

	public int wave;
	public float waveLength;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
    }

	private void Start()
	{
		Invoke("SpawnEnemy", spawnTime);
		Invoke("NextWave", waveLength);
	}

	void SpawnEnemy()
	{
		if (GameObject.Find("Trump") && !GameUIManager.instance.isDeathScreen)
		{
			GameObject newPortal = Instantiate(portal, new Vector3(Random.Range(boundaries[2].transform.position.x, boundaries[0].transform.position.x), Random.Range(boundaries[1].transform.position.y, boundaries[3].transform.position.y), 0f), Quaternion.identity);
			Portal portalComponent = newPortal.GetComponent<Portal>();
			portalComponent.enemyHp = spawnHP + (wave * 3);
			Invoke("SpawnEnemy", Mathf.Max(spawnTime - (wave / 2), 2));
		}
	}

	void NextWave()
	{
		if (GameObject.Find("Trump"))
		{
			//Tiane (Next wave effect GUI)
			SoundManager.instance.PlayOnce(5);
			wave += 1;
			GameUIManager.instance.UpdateCurrentWaveText(wave);
			Invoke("NextWave", waveLength);
		}
	}

	public void AddScore(int newscore)
	{
		score += newscore;
		GameUIManager.instance.UpdateCurrentScoreText(score);
	}

}
