using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EmployeeQuits : MonoBehaviour {

	public Canvas employeeQuits;
	
	void Update () {
		// Hacky way to check if canvas has child elements
		EmployeeQuitsPanel[] panels =  employeeQuits.GetComponentsInChildren<EmployeeQuitsPanel>();
		if(panels.Length == 0) {
			employeeQuits.enabled = false;
		}
		else {
			employeeQuits.enabled = true;
		}
	}
}
