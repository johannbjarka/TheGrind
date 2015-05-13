using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour {

	AudioSource music;
	Button muteButton;
	public Sprite noMusic;

	// Use this for initialization
	void Start () {
		music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
		muteButton = GameObject.FindWithTag("MuteButton").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void muteMusic () {
		if(music.mute) {
			music.mute = false;
			muteButton.image.overrideSprite = null;
		}
		else {
			music.mute = true;
			muteButton.image.overrideSprite = noMusic;
		}
	}
}
