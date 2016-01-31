using UnityEngine;
using System.Collections;

public class FolowingCamera : MonoBehaviour
{
	public GameObject bob;
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		transform.position = new Vector3(bob.transform.position.x, position.y, position.z);
	}
}
