using UnityEngine;
using System.Collections;

 [RequireComponent(typeof(Rigidbody2D))]
public class Bob : MonoBehaviour 
{
	public GameObject bob;

    private Rigidbody2D _body;

	public int health = 100;
	public int speed = 5;

    void Awake ()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization

    void Start () {
		bob = new GameObject ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0){
			_body.MovePosition (_body.position + new Vector2 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0));
		}
	}
}
