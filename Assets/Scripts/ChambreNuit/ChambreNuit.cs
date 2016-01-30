using UnityEngine;
using System.Collections;

public class ChambreNuit : MonoBehaviour {
    public GameObject ui;

    private Fading fader;

	// Use this for initialization
	void Start () {
        fader = ui.GetComponent<Fading>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        fader.LoadScene("CusineSalonMatin");
    }
}
