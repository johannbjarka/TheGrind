using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteSoundFX : MonoBehaviour {

	public AudioSource officeSound;
	AudioSource clickSound;
	AudioSource waterCoolerSound;
	AudioSource yell;
	AudioSource cash;
	AudioSource helloMan;
	AudioSource helloGirl;
	public Text fontIcon;
	//Button muteButton;
	
	// Use this for initialization
	void Start () {
		officeSound = GameObject.FindWithTag("OfficeSound").GetComponent<AudioSource>();
		clickSound = GameObject.FindWithTag("ClickSound").GetComponent<AudioSource>();
		waterCoolerSound = GameObject.FindWithTag("Watercooler").GetComponent<AudioSource>();
		yell = GameObject.FindWithTag("Yell").GetComponent<AudioSource>();
		cash = GameObject.FindWithTag("Cash").GetComponent<AudioSource>();
		helloMan = GameObject.FindWithTag("HelloMan").GetComponent<AudioSource>();
		helloGirl = GameObject.FindWithTag("HelloGirl").GetComponent<AudioSource>();
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
			waterCoolerSound.mute = false;
			yell.mute = false;
			cash.mute = false;
			helloMan.mute = false;
			helloGirl.mute = false;
		}
		else {
			fontIcon.text = "\uf026";
			officeSound.mute = true;
			clickSound.mute = true;
			waterCoolerSound.mute = true;
			yell.mute = true;
			cash.mute = true;
			helloMan.mute = true;
			helloGirl.mute = true;
		}
	}
}
