using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Dialog)), RequireComponent(typeof(Fading))]
public class Intro : MonoBehaviour
{
    private Dialog dialog;
    private Fading fading;

    private bool dialogStarted = false;

	// Use this for initialization
	void Start () {
        dialog = GetComponent<Dialog>();
        fading = GetComponent<Fading>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(dialog.finished)
        {
            Debug.Log("Dialog finisehd");
            fading.LoadScene("ChambreMatin");
        }
    }

    private void HideMenu()
    {
        GameObject.Find("Start").SetActive(false);
        GameObject.Find("Quit").SetActive(false);
    }

    public void StartGame()
    {
        if (!dialogStarted)
        {
            Debug.Log("Begin Dialog");
            HideMenu();
            string[] strings = {
                "I want to remember you.\nI just don't want to forget you...",
                "But I know it's going to happen.\nI just want to keep you in my mind...",
                "... At least until tomorrow." };
            dialog.BeginDialog(strings);
            dialogStarted = true;
        }
    }

    public void QuitGame()
    {
        fading.quitGame();
    }
}
