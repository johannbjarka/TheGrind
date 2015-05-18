using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoverPanelTutorial : MonoBehaviour {
	
	public GameObject IntroPanel;
	public GameObject SkillsPanel;
	public GameObject FirePanel;
	public GameObject YellPanel;
	public GameObject RaisePanel;
	public GameObject SpeedPanel;
	public GameObject MoralePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void beginTutorial() {
		IntroPanel.SetActive (false);
		SkillsPanel.SetActive (true);
	}

	public void openFirePanel() {
		SkillsPanel.SetActive (false);
		FirePanel.SetActive (true);
	}

	public void openYellPanel() {
		FirePanel.SetActive (false);
		YellPanel.SetActive (true);
	}

	public void openRaisePanel() {
		YellPanel.SetActive (false);
		RaisePanel.SetActive (true);
	}

	public void openSpeedPanel() {
		RaisePanel.SetActive (false);
		SpeedPanel.SetActive (true);
	}

	public void openMoralePanel() {
		SpeedPanel.SetActive (false);
		MoralePanel.SetActive (true);
	}
}
