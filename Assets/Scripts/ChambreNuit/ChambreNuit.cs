using UnityEngine;
using System.Collections;

public class ChambreNuit : MonoBehaviour
{
    public GameObject ui;

    private Fading fader;

	// Use this for initialization
	void Awake ()
	{
        fader = ui.GetComponent<Fading>();
	}	

    void OnTriggerEnter2D(Collider2D other)
    {
		if (gameObject.name == "ToSalon") fader.LoadScene("CuisineSalonNuit");
    }

	void OnTriggerStay2D(Collider2D other)
	{
		if (!Input.GetKeyDown(KeyCode.Return)) return;

		Model.NewDay();
		fader.LoadScene("ChambreMatin");
		SoundScript.FadeOut();
	}
}
