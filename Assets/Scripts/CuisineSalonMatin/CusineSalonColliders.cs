using UnityEngine;
using System.Collections;

public class CusineSalonColliders : MonoBehaviour {
    private Fading fader;
	public Bob bob;
	public GameObject pileTasse;
	public GameObject theWhendy;
	public Sprite[] cupOfTea;

	public GameObject tasse;

	void Awake()
    {
        fader = transform.parent.GetComponent<Fading>();
		bob = GameObject.Find("Bob").GetComponent<Bob>();
    }

	void Start()
	{
		if (Model.Instance.current > 0)
		{
			pileTasse.GetComponent<SpriteRenderer>().sprite = cupOfTea[Model.Instance.current - 1];
			pileTasse.SetActive(true);
		}

		if(Model.Instance.previousScene == "SalleDeBainMatin")
		{
			bob.transform.position = new Vector3(-12.4f, -0.9f, -3f);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(gameObject.name)
        {
            case "ToBedroom": fader.LoadScene("ChambreMatin"); break;
            case "ToWork": fader.LoadScene("CuisineSalonNuit"); SoundScript.FadeOut(); break;
        }
    }

	void OnTriggerStay2D(Collider2D other)
	{
		if (!bob.inputEnable) return;

		switch (gameObject.name)
		{
			case "ToBathroom":
				if (Input.GetAxis("Vertical") > 0.5f) fader.LoadScene("SalleDeBainMatin");
				break;
			case "The": if(Input.GetKeyDown(KeyCode.Return)) StartCoroutine(LaunchTheAnimation()); break;
		}
	}

	private IEnumerator LaunchTheAnimation()
	{
		bob.inputEnable = false;
		Animator anim = bob.GetComponent<Animator>();
		anim.SetFloat("the", 2);

		yield return 0;

		anim.SetFloat("the", 0);
		tasse.SetActive(false);

		while (!anim.GetCurrentAnimatorStateInfo(0).IsName("Marche_Bob")) yield return 0;

		bob.inputEnable = true;

		pileTasse.GetComponent<SpriteRenderer>().sprite = cupOfTea[Model.Instance.current];

		pileTasse.SetActive(true);

		if (Model.Instance.current == 0)
			theWhendy.SetActive(true);

	}
}
