using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject welcomePanel;
	public GameObject goalPanel;
	public GameObject moneyPanel;
	public GameObject computerPanel;
	public GameObject calendarPanel;
	public GameObject continuePanel;
	public GameObject endPanel;
	public GameObject JobSecurityPanel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void getGoalPanel() {
		welcomePanel.SetActive (false);
		goalPanel.SetActive (true);
	}

	public void getMoneyPanel() {
		goalPanel.SetActive (false);
		moneyPanel.SetActive (true);
	}
	public void getComputerPanel () {
		moneyPanel.SetActive (false);
		computerPanel.SetActive (true);
	}

	public void getCalendarPanel () {
		computerPanel.SetActive (false);
		calendarPanel.SetActive (true);
	}

	public void getContinuePanel () {
		calendarPanel.SetActive (false);
		continuePanel.SetActive (true);
	}

	public void getJobSecurityPanel () {
		continuePanel.SetActive (false);
		JobSecurityPanel.SetActive (true);
	}

	public void endTutorial () {
		JobSecurityPanel.SetActive (false);
		endPanel.SetActive (true);
	}
}
