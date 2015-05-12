using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	ClickSound click;

	void Start () {
		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
	}

	public void StartGame () {
		click.playSound();
		Application.LoadLevel ("Tutorial");
	}

	public void StartContext () {
		click.playSound();
		Application.LoadLevel ("ContextScreen");
	}

	public void StartOffice () {
		click.playSound();
		MuteSoundFX mute = GameObject.FindWithTag("Mute").GetComponent<MuteSoundFX>();
		if(mute.officeSound.mute) {
			mute.muteSoundFX();
		}
		Application.LoadLevel ("Office");
	}

	public void QuitGame () {
		click.playSound();
		Application.Quit ();
	}
}
