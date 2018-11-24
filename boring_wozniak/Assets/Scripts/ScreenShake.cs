using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

	public float intensity;
	public float time;

	// Use this for initialization
	void Start () {

		Invoke("StopShaking", time);
		
	}
	
	// Update is called once per frame
	void Update () {

		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + Random.Range(-intensity, intensity), Camera.main.transform.position.y + Random.Range(-intensity, intensity), -10f);
		
	}

	void StopShaking()
	{
		Destroy(gameObject);
	}
}
