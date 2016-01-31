using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChambreMatin : MonoBehaviour
{
    public GameObject ui;

    private Fading fader;
	private Dialog dialog;
	private bool dialogDisplayed = false;
	public GameObject bobGO;
	private Bob bob;
	

	// Use this for initialization
	void Start () {
        fader = ui.GetComponent<Fading>();
		dialog = ui.GetComponent<Dialog>();
		bob = bobGO.GetComponent<Bob>();
		bob.inputEnable = false;

		if(Model.Instance.previousScene == "ChambreNuit" || Model.Instance.previousScene == "Intro")
		{
			dialogDisplayed = false;
			SoundScript.playDay();
			SoundScript.FadeIn();
		}
		else
		{
			Debug.Log("From Salon");
			dialogDisplayed = true;
			bob.inputEnable = true;
			bob.transform.position = new Vector3(4.4f, -0.9f, -3f);
			bob.transform.localScale = new Vector2(-1, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!dialogDisplayed && Input.GetKeyDown(KeyCode.Return))
		{
			dialogDisplayed = true;
			dialog.BeginDialog(Model.Instance.Dialog);
		}
		else if (dialog.finished && !bob.inputEnable) bob.inputEnable = true;
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.name == "Chambre") fader.LoadScene("CuisineSalonMatin");
    }
}
