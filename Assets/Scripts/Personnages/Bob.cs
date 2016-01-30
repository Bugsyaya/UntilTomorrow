using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour 
{
	public GameObject bob;

	public int health = 100;
	public int speed = 5;

	// Use this for initialization
	void Start () {
		bob = new GameObject ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0){
			float x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			Vector3 vector = new Vector3 (x, 0, 0);
			transform.Translate (vector);
		}
	}
}
