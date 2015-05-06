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
	}

	public void openEmployeeRecords () {
		employeeRecordsIsOpen = !employeeRecordsIsOpen;
		EmployeeRecordsCanvas.enabled = !EmployeeRecordsCanvas.enabled;
	}

	public void openAvailableProjects () {
		availableProjectsIsOpen = !availableProjectsIsOpen;
		AvailableProjectsCanvas.enabled = !AvailableProjectsCanvas.enabled;
	}

	public void openApplicantsMenu () {
		applicantsMenuIsOpen = !applicantsMenuIsOpen;
		ApplicantsCanvas.enabled = !ApplicantsCanvas.enabled;
	}

	public void openCurrentProjects () {
		currentProjectsIsOpen = !currentProjectsIsOpen;
		CurrentProjectsCanvas.enabled = !CurrentProjectsCanvas.enabled;
	}
}
