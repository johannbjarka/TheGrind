using UnityEngine;
using System.Collections;

public class ComputerMenu : MonoBehaviour {

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

	public void openComputerMenuPanel () {
		menuIsOpen = !menuIsOpen;
		ComputerMenuCanvas.enabled = !ComputerMenuCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openEmployeeRecords () {
		employeeRecordsIsOpen = !employeeRecordsIsOpen;
		EmployeeRecordsCanvas.enabled = !EmployeeRecordsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openAvailableProjects () {
		availableProjectsIsOpen = !availableProjectsIsOpen;
		AvailableProjectsCanvas.enabled = !AvailableProjectsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openApplicantsMenu () {
		applicantsMenuIsOpen = !applicantsMenuIsOpen;
		ApplicantsCanvas.enabled = !ApplicantsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}

	public void openCurrentProjects () {
		currentProjectsIsOpen = !currentProjectsIsOpen;
		CurrentProjectsCanvas.enabled = !CurrentProjectsCanvas.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}
}
