using UnityEngine;
using System.Collections;

public class ClickSound : MonoBehaviour {

	public void playSound () {
		GetComponent<AudioSource>().Play();
	}
}
