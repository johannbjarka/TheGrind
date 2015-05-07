﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel ("Tutorial");
	}

	public void StartContext () {
		Application.LoadLevel ("ContextScreen");
	}

	public void StartOffice () {
		Application.LoadLevel ("Office");
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
