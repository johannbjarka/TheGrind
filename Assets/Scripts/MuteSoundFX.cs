using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteSoundFX : MonoBehaviour {

	public AudioSource officeSound;
	AudioSource clickSound;
	public Text fontIcon;
	//Button muteButton;
	
	// Use this for initialization
	void Start () {
		officeSound = GameObject.FindWithTag("OfficeSound").GetComponent<AudioSource>();
		clickSound = GameObject.FindWithTag("ClickSound").GetComponent<AudioSource>();
		//muteButton = GameObject.FindWithTag("Mute").GetComponent<Button>();
		muteSoundFX();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void muteSoundFX () {
		if(officeSound.mute) {
			fontIcon.text = "\uf028";
			officeSound.mute = false;
			clickSound.mute = false;
			//muteButton.image.color = Color.white;
		}
		else {
			fontIcon.text = "\uf026";
			officeSound.mute = true;
			clickSound.mute = true;
			//muteButton.image.color = Color.red;
		}
	}
}
