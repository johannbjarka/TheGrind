using UnityEngine;
using System.Collections;

public class YellSound : MonoBehaviour {

	public void playSound () {
		GetComponent<AudioSource>().Play();
	}
}
