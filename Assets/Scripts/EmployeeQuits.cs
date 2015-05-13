using UnityEngine;
using System.Collections;

public class EmployeeQuits : MonoBehaviour {

	public Canvas employeeQuits;
	private bool isOpen = false;
	
	public void quit () {
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
		isOpen = !isOpen;
		employeeQuits.enabled = !employeeQuits.enabled;
	}
}
