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
	public int score;
	public int wave;

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
	}

	void Update () {

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

}
