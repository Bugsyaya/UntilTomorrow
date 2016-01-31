using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour
{
	public AudioClip[] clips;

	private static SoundScript _instance = null;

	private AudioSource source;

	private float speed;

	public static SoundScript Instance { get { return _instance; } }

	void Awake()
	{
		if (_instance != null && _instance != this) Destroy(gameObject);
		else
		{
			_instance = this;
			source = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (speed == 0f) return;
		source.volume += speed * Time.deltaTime;
		if (source.volume == 0 || source.volume == 1) speed = 0f;
	}

	public static void FadeOut()
	{
		Instance.speed = -0.8f;
	}

	public static void FadeIn()
	{
		Instance.speed = 0.8f;
	}

	public static void playNight()
	{
		Instance.source.clip = Instance.clips[1];
		Instance.source.Play();
	}

	public static void playDay()
	{
		Instance.source.clip = Instance.clips[0];
		Instance.source.Play();
	}
}
