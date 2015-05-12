using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel ("Tutorial");
	}

	public void StartContext () {
		Application.LoadLevel ("ContextScreen");
	}

	public void StartOffice () {
		MuteSoundFX mute = GameObject.FindWithTag("Mute").GetComponent<MuteSoundFX>();
		mute.muteSoundFX();
		Application.LoadLevel ("Office");
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
