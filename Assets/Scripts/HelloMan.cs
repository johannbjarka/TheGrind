using UnityEngine;
using System.Collections;

public class HelloMan : MonoBehaviour {

	public void playSound () {
		GetComponent<AudioSource>().Play();
	}
}
