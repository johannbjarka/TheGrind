using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void StartGame () {
		Application.LoadLevel ("Office");
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
