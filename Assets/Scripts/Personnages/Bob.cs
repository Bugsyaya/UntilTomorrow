using UnityEngine;
using System.Collections;

 [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
public class Bob : MonoBehaviour 
{
	public GameObject bob;

    private Rigidbody2D body;
	private Animator anim;

	public int health = 100;
	public float speed = 5f;
	public bool inputEnable = true;

	void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
		if (!inputEnable) return;

		float move = Input.GetAxis("Horizontal");

		if (move != 0){
			body.MovePosition (body.position + new Vector2 (move * speed * Time.deltaTime, 0));
		}

		if (move < 0) transform.localScale = new Vector2(-1, 1);
		else if(move > 0) transform.localScale = new Vector2(1, 1);
		
		anim.SetFloat("Speed", Mathf.Abs(move));
	}
}
