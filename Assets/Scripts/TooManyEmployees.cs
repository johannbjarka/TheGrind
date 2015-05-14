using UnityEngine;
using System.Collections;

public class TooManyEmployees : MonoBehaviour {

	public Canvas tooManyView;
	private bool isOpen = false;
	
	public void openTooMany () {
		isOpen = !isOpen;
		tooManyView.enabled = !tooManyView.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}
}
