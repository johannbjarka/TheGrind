using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

/*
[System.Serializable]
public class Item {
	public Sprite icon;
	public string name;
	public string gender;
	public string morale;
	public string speed;
	public string salary;
}
*/

public class CreateScrollList : MonoBehaviour {

	Company myCompany;
	public GameObject employeePanel;

	public Transform contentPanel;

	void Start () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
	}

	public void PopulateEmployeeList () {
		foreach (var item in myCompany.characters) {
			GameObject newPanel = Instantiate (employeePanel) as GameObject;
			EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			panel.nameLabel.text = item.characterName;
			panel.genderLabel.text = item.gender.ToString();
			panel.moraleLabel.text = item.morale.ToString();
			panel.speedLabel.text = item.speed.ToString();
			panel.salaryLabel.text = item.salary.ToString();
			panel.employeeIcon.sprite = item.sprites[0];
			newPanel.transform.SetParent (contentPanel);
			panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}

	public void PopulateApplicantList () {
		foreach (var item in myCompany.applicants) {

		}
	}
}
