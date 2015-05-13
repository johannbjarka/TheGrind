using UnityEngine;
using System;
using System.Collections;
using Prime31.TransitionKit;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fadeToContext () {
		var fader = new FadeTransition () {
			nextScene = Application.loadedLevel == 0 ? 1 : 0,
			fadedDelay = 0.1f,
			fadeToColor = Color.black
		};
		TransitionKit.instance.transitionWithDelegate(fader);
	}

	public void fadeToTutorial () {
		/*
		var pixelater = new PixelateTransition() {
			nextScene = Application.loadedLevel == 1 ? 2 : 1,
			finalScaleEffect = PixelateTransition.PixelateFinalScaleEffect.ToPoint,
			duration = 1.0f
		};
		TransitionKit.instance.transitionWithDelegate(pixelater);
		*/

		var winder = new WindTransition () {
			nextScene = 2,
			duration = 1.0f
		};
		TransitionKit.instance.transitionWithDelegate(winder);
	}

	public void fadeToOffice () {
		var winder = new WindTransition () {
			nextScene = 3,
			duration = 1.0f
		};
		TransitionKit.instance.transitionWithDelegate(winder);

		MuteSoundFX mute = GameObject.FindWithTag("Mute").GetComponent<MuteSoundFX>();
		if(mute.officeSound.mute) {
			mute.muteSoundFX();
		}

		/*
		var fader = new FadeTransition () {
			nextScene = Application.loadedLevel == 2 ? 3 : 2,
			fadedDelay = 0.1f,
			fadeToColor = Color.black
		};
		TransitionKit.instance.transitionWithDelegate(fader);
		*/
	}

	public void fadeToNextWeek () {
		// Problem with this is the transition happens after all changes, so the illusion of a transition is lost.
		var fader = new FadeTransition () {
			fadedDelay = 0.01f,
			fadeToColor = Color.black
		};
		TransitionKit.instance.transitionWithDelegate(fader);
	}
}
