using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	public AudioClip[] clips;

	public AudioClip[] voiceLines;

	private AudioSource sfx;

	private AudioSource sfx2;

	public static SoundManager instance;

	void Awake()
	{
		Invoke("PlayVoiceLine", 1f);
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
	}

	public void Start()
	{
		AudioSource[] sources = GetComponents<AudioSource>();
		sfx = sources[0];
		sfx2 = sources[1];
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

	public void PlayVoiceLine()
	{
		if (GameObject.Find("Trump"))
		{
			sfx2.pitch = 1f;

			sfx2.clip = voiceLines[Random.Range(0, 35)];
			sfx2.PlayOneShot(sfx2.clip);
			Invoke("PlayVoiceLine", 20f);
		}
	}

	public void PlayOnce(int clip)
	{
		sfx2.pitch = 1f;

		sfx2.clip = clips[clip];

		sfx2.PlayOneShot(sfx2.clip);
	}
}
