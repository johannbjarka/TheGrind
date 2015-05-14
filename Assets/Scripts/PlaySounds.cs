using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

	public void playWatercoolerSound() {
		WaterCooler wc = GameObject.FindWithTag("Watercooler").GetComponent<WaterCooler>();
		wc.playSound();
	}
}
