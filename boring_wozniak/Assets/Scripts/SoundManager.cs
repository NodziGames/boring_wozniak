using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	public AudioClip[] clips;

	private AudioSource sfx;

	public static SoundManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	public void Start()
	{
		sfx = GetComponent<AudioSource>();
	}

	public void PlayOnceAltered(int clip)
	{
		//Set the pitch of the audio source to the randomly chosen pitch.
		sfx.pitch = Random.Range(0.9f, 1.1f);

		//Set the clip to the clip at our randomly chosen index.
		sfx.clip = clips[clip];

		//Play the clip.
		sfx.PlayOneShot(sfx.clip);
	}
}
