﻿using UnityEngine;
using System;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fadeToContext () {
		var fader = new FadeTransition () {
			nextScene = SceneManager.GetActiveScene() == SceneManager.GetSceneAt(0) ? 1 : 0,
			fadedDelay = 0.1f,
			fadeToColor = Color.black
		};
		TransitionKit.instance.transitionWithDelegate(fader);
	}

	public void fadeToTutorial () {
		var fader = new FadeTransition () {
			nextScene = SceneManager.GetActiveScene().name == "ContextScreen" ? 2 : 1,
			fadedDelay = 0.1f,
			fadeToColor = Color.black
		};
		TransitionKit.instance.transitionWithDelegate(fader);
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
