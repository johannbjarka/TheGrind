using UnityEngine;
using System.Collections;

public class WaterCooler : MonoBehaviour {

	public void playSound () {
		GetComponent<AudioSource>().Play();
	}
}
