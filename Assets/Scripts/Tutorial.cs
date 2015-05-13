using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject welcomePanel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void closeWelcome() {
		welcomePanel.SetActive (false);
	}
}
