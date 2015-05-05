using UnityEngine;
using System.Collections;

public class ComputerMenu : MonoBehaviour {

	public Canvas ComputerMenuCanvas;
	public Canvas EmployeeRecordsCanvas;
	public Canvas AvailableProjectsCanvas;

	bool menuIsOpen = false;
	bool employeeRecordsIsOpen = false;
	bool availableProjectsIsOpen = false;

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
}
