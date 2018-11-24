using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization

    public static GameManager instance = null;
	public GameObject trump;
	public GameObject cameraObj;

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
		
	}

	void Update () {

	}

}
