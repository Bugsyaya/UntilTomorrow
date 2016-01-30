using UnityEngine;
using System.Collections;

public class ChambreMatin : MonoBehaviour
{
    public GameObject ui;

    private Fading fader;

	// Use this for initialization
	void Start () {
        fader = ui.GetComponent<Fading>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        fader.LoadScene("CuisineSalonMatin");
        Debug.Log("Trigger");
    }
}
