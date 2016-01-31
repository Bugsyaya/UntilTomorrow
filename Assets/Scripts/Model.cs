using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Model : MonoBehaviour
{
	private static Model _instance = null;
	public static Model Instance { get { return _instance; } }

	void Awake()
	{
		if (_instance != null && _instance != this) Destroy(gameObject);
		else
		{
			_instance = this;
			currentScene = SceneManager.GetActiveScene().name;
			DontDestroyOnLoad(gameObject);
			Constructor();
		}
	}

	public Day[] days;
	public int current;

	private string currentScene;
	public string previousScene;

	public string[] Dialog {get{ return days[current].dialog; }}

	private void Constructor()
	{
		Debug.Log("Model initialisation");

		days = new Day[2];

		days[0] = new Day(
			"...good morning Honey...",
			"It’s time to wake up.",
			"I'll go make your tea for breakfast."
		);

		days[1] = new Day(
			"Hehe... I hope you won’t mess up with me in the bathroom today.",
			"Just, I mustn’t forget your tea before."
		);
		days[1].scenne = "SalleDeBainMatin";
		days[1].gameObjectName = "BrossageDent";
	}

	public void OnLevelWasLoaded(int Level)
	{
		Debug.Log("Scene loaded, activating apropriate Game Objects");
		for (int i = 0; i <= current; i++) days[i].Activate();
		previousScene = currentScene;
		currentScene = SceneManager.GetActiveScene().name;
		Debug.Log(previousScene);
	}

	internal static void NewDay()
	{
		Instance.current++;
	}
}
