using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateScrollList : MonoBehaviour {

	Company myCompany;

	public GameObject employeePanel;
	public GameObject applicantsPanel;
	public GameObject applicantPrefab;
	public GameObject employeePrefab;

	public Transform employeeContentPanel;
	public Transform applicantContentPanel;

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
			panel.employeeIcon.sprite = item.sprite;
			panel.ID.text = item.ID.ToString();
			newPanel.transform.SetParent (employeeContentPanel);
			panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}

	public void PopulateApplicantList () {
		foreach (var item in myCompany.applicants) {
			GameObject newPanel = Instantiate (applicantsPanel) as GameObject;
			EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			panel.nameLabel.text = item.characterName;
			panel.genderLabel.text = item.gender.ToString();
			panel.moraleLabel.text = item.morale.ToString();
			panel.speedLabel.text = item.speed.ToString();
			panel.salaryLabel.text = item.salary.ToString();
			panel.employeeIcon.sprite = item.sprite;
			panel.ID.text = item.ID.ToString();
			newPanel.transform.SetParent (applicantContentPanel);
			panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}

	public void emptyEmployeeList () {
		foreach (Transform child in employeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
		foreach (Transform child in applicantContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void hire (Text _id){
		int id = Int32.Parse(_id.text);

		foreach(Character emp in myCompany.applicants){
			if(emp.ID == id){
				myCompany.characters.Add(emp);
				myCompany.applicants.Remove(emp);
				emp.gameObject.transform.position = new Vector3(0, 0, 0);
				Destroy(applicantPrefab);
				break;
			}
		}
	}

	public void fire (Text _id){
		//TODO: Remove from Project, Remove from Company, take plant.
		int id = Int32.Parse(_id.text);
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		foreach(Project proj in myCompany.projects){
			foreach(Character emp in proj.employees){
				if(emp.ID == id){
					proj.employees.Remove(emp);
					break;
				}
			}
		}
		foreach(Character emp in myCompany.characters){
			if(emp.ID == id){
				myCompany.characters.Remove(emp);
				emp.gameObject.transform.position = new Vector3(-1000, -1000, 0);
				Destroy(employeePrefab);
				break;
			}
		}
		//takePlant();
	}
}
