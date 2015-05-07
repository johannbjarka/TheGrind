using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) == true) {
			GetComponent<AudioSource>().Play();
		}
	}
}
