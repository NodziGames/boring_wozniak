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
        DontDestroyOnLoad(gameObject);
    }

	private void Start()
	{
		Invoke("SpawnEnemy", spawnTime);
		Invoke("NextWave", waveLength);
	}

	void SpawnEnemy()
	{
		if (GameObject.Find("Trump"))
		{
			GameObject newPortal = Instantiate(portal, new Vector3(0f, 0f, 0f), Quaternion.identity);
			Portal portalComponent = newPortal.GetComponent<Portal>();
			portalComponent.enemyHp = spawnHP + (wave * 5);
			Invoke("SpawnEnemy", Mathf.Max(spawnTime - (wave / 2), 2));
		}
	}

	void NextWave()
	{
		//Tiane (Next wave effect GUI)
		wave += 1;
		Invoke("NextWave", waveLength);
	}

	public void AddScore(int newscore)
	{
		score += newscore;
	}

}
