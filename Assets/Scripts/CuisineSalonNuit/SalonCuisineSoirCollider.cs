using UnityEngine;
using System.Collections;

public class SalonCuisineSoirCollider : MonoBehaviour
{
	private Fading fader;
	public GameObject bobGO;
	private Bob bob;

	void Awake()
	{
		fader = transform.parent.GetComponent<Fading>();
		bob = bobGO.GetComponent<Bob>();
	}

	void Start()
	{
		if(Model.Instance.previousScene == "ChambreNuit")
		{
			bob.transform.position = new Vector3(-14.28f, -0.95f, -3f);
			bob.transform.localScale = new Vector2(1, 1);
		}
		else if(Model.Instance.previousScene == "SalleDeBainNuit")
		{
			bob.transform.position = new Vector3(-12.4f, -0.95f, -3f);
		}
		else if(Model.Instance.previousScene == "CuisineSalonMatin")
		{
			SoundScript.playNight();
			SoundScript.FadeIn();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (gameObject.name == "ToBedroom") fader.LoadScene("ChambreNuit");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetAxis("Vertical") > 0.5f && gameObject.name == "ToBathroom")
			fader.LoadScene("SalleDeBainNuit");
	}
}
