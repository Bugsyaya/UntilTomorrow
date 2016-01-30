using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Fading : MonoBehaviour {
    public Texture2D fadeOutTexture; // The texture that will overlay the scenne. This can be a black image or a loading graphic
    public float fadeSpeed = 0.8f;   // The fading speed

    private int drawDepth = -1000;   // The texture's order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f;      // The texture's alpha value between 0 and 1
    public int fadeDir = -1;        // The direction to fade: in = -1 or out = 1
	
	void OnGUI()
    {
        // fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds.
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // force (clamp) the number between 0 and 1 because Gui.Color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // set color of our GUI (in this case our texture). All color values remain the same & the alpha is set to the alpha variable.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), fadeOutTexture);
    }

    internal void quit()
    {
        throw new NotImplementedException();
    }

    private void BeginFade()
    {
        fadeDir = -1;
    }

    private IEnumerator BeginFade(string sceneName)
    {
        fadeDir = 1;
        yield return new WaitForSeconds(fadeSpeed);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator BeginFadeQuit()
    {
        fadeDir = 1;
        yield return new WaitForSeconds(fadeSpeed);
        Application.Quit();
    }

    void OnLevelWasLoaded(int level)
    {
        BeginFade();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(BeginFade(sceneName));
    }

    public void quitGame()
    {
        StartCoroutine(BeginFadeQuit());
    }
}
