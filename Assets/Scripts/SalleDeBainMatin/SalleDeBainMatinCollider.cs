using UnityEngine;
using System.Collections;

public class SalleDeBainMatinCollider : MonoBehaviour
{
	public GameObject bobGO;
	public GameObject wendy;
	private Bob bob;
	private Fading fader;
	private bool animationLaunched = false;

	void Awake()
	{
		fader = transform.parent.GetComponent<Fading>();
		bob = bobGO.GetComponent<Bob>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		switch (gameObject.name)
		{
			case "ToSalon": if (Input.GetAxis("Vertical") > 0.5f) fader.LoadScene("CuisineSalonMatin"); break;
			case "AnimationCollider":
				if (Input.GetKeyDown(KeyCode.Return) && !animationLaunched) StartCoroutine(LaunchAnimation()); break;
		}
	}

	private IEnumerator LaunchAnimation()
	{
		bob.inputEnable = false;
		Animator animBob = bob.GetComponent<Animator>();
		animBob.SetBool("Dent", true);
		wendy.SetActive(true);

		yield return 0;

		animBob.SetBool("Dent", false);

		yield return new WaitForSeconds(5f);

		animBob.SetBool("DentEnd", true);

		while (!animBob.GetCurrentAnimatorStateInfo(0).IsName("Marche_Bob")) yield return 0;

		wendy.GetComponent<FadeIn>().Fade();
		bob.inputEnable = true;
		animationLaunched = true;
	}
}
