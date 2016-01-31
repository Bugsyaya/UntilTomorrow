using UnityEngine;
using System.Collections;

public class SalleDeBainNuitCollider : MonoBehaviour {

	private Fading fader;

	void Awake()
	{
		fader = transform.parent.GetComponent<Fading>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetAxis("Vertical") > 0.5f) fader.LoadScene("CuisineSalonNuit");
	}
}
