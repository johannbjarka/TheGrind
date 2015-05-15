using UnityEngine;
using System.Collections;

public class ComputerMenu : MonoBehaviour {
	public Continue myContinueClass;
	public Canvas ComputerMenuCanvas;
	public Canvas EmployeeRecordsCanvas;
	public Canvas AvailableProjectsCanvas;
	public Canvas ApplicantsCanvas;
	public Canvas CurrentProjectsCanvas;

	bool menuIsOpen = false;
	bool employeeRecordsIsOpen = false;
	bool availableProjectsIsOpen = false;
	bool applicantsMenuIsOpen = false;
	bool currentProjectsIsOpen = false;

	void Start () {

	}

	public void openComputerMenuPanel () {
		myContinueClass.closeEverything ();
		menuIsOpen = true;
		ComputerMenuCanvas.enabled = true;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void closeComputerPanel() {
		menuIsOpen = false;
		ComputerMenuCanvas.enabled = false;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}
	public void openEmployeeRecords () {
		closeComputerPanel ();
		employeeRecordsIsOpen = !employeeRecordsIsOpen;
		EmployeeRecordsCanvas.enabled = !EmployeeRecordsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openAvailableProjects () {
		closeComputerPanel ();
		availableProjectsIsOpen = !availableProjectsIsOpen;
		AvailableProjectsCanvas.enabled = !AvailableProjectsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openApplicantsMenu () {
		closeComputerPanel ();
		applicantsMenuIsOpen = !applicantsMenuIsOpen;
		ApplicantsCanvas.enabled = !ApplicantsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openCurrentProjects () {
		closeComputerPanel ();
		currentProjectsIsOpen = !currentProjectsIsOpen;
		CurrentProjectsCanvas.enabled = !CurrentProjectsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}
}
