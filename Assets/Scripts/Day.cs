using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Day
{
	public string[] dialog;
	public string scenne;
	public string gameObjectName;

	public Day(params string[] strings)
	{
		dialog = strings;
	}

	public void Activate()
	{
		if (SceneManager.GetActiveScene().name == scenne)
		{
			Debug.Log("Activate Game Object");
			GameObject.Find(gameObjectName).SetActive(true);
		}
	}
}
