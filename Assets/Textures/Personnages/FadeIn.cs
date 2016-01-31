using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float speed = 0.1f;

	private float end;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		Color color = sprite.color;
		color.a = 0f;
		sprite.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((sprite.color.a >= 1f && speed > 0) || (sprite.color.a <= 0f && speed < 0)) return;

		Color color = sprite.color;
		color.a += speed * Time.deltaTime;
		sprite.color = color;
	}

	public void Fade()
	{
		speed = -speed;
	}
}
