using UnityEngine;
using System.Collections;

public class CashSound : MonoBehaviour {

	public void playSound () {
		GetComponent<AudioSource>().Play();
	}
}
