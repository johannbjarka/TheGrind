using UnityEngine;
using System.Collections;

public class HelloGirl : MonoBehaviour {

	public void playSound () {
		GetComponent<AudioSource>().Play();
	}
}
