using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	ClickSound click;

	void Start () {
		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
	}

	public void StartGame () {
		click.playSound();
		SceneManager.LoadScene ("Tutorial");
	}

	public void StartContext () {
		click.playSound();
        SceneManager.LoadScene("ContextScreen");
	}

	public void StartOffice () {
		click.playSound();
		MuteSoundFX mute = GameObject.FindWithTag("Mute").GetComponent<MuteSoundFX>();
		if(mute.officeSound.mute) {
			mute.muteSoundFX();
		}
        SceneManager.LoadScene("Office");
	}

	public void QuitGame () {
		click.playSound();
		Application.Quit ();
	}
}
