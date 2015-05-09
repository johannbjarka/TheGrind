using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateScrollList : MonoBehaviour {

	Company myCompany;

	public GameObject employeePanel;
	public GameObject availableEmployeePanel;
	public GameObject applicantsPanel;
	public GameObject applicantPrefab;
	public GameObject employeePrefab;
	public GameObject projectEmployeePanel;

	public Transform employeeContentPanel;
	public Transform applicantContentPanel;
	public Transform availableEmployeeContentPanel;
	public Transform skillsMenuContentPanel;
	public Transform projectEmployeeContentPanel;

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

	public Canvas SelectEmployeesCanvas;
	bool selectEmployeesCanvasIsOpen = false;

	public void PopulateAvailableEmployeeList (int id) {
		selectEmployeesCanvasIsOpen = !selectEmployeesCanvasIsOpen;
		SelectEmployeesCanvas.enabled = !SelectEmployeesCanvas.enabled;
		foreach (var item in myCompany.characters) {
			GameObject newPanel = Instantiate (availableEmployeePanel) as GameObject;
			EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			if(!item.onProject){
				panel.nameLabel.text = item.characterName;
				panel.genderLabel.text = item.gender.ToString();
				panel.moraleLabel.text = item.morale.ToString();
				panel.speedLabel.text = item.speed.ToString();
				panel.salaryLabel.text = item.salary.ToString();
				panel.employeeIcon.sprite = item.sprite;
				panel.ID.text = item.ID.ToString();
				panel.ProjectID.text = id.ToString();

				newPanel.transform.SetParent (availableEmployeeContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
		}
	}

	public Canvas RemoveEmployeesCanvas;
	bool removeEmployeesCanvasIsOpen = false;

	public void populateProjectEmployeeList (int id) {
		removeEmployeesCanvasIsOpen = !removeEmployeesCanvasIsOpen;
		RemoveEmployeesCanvas.enabled = !RemoveEmployeesCanvas.enabled;
		foreach(var proj in myCompany.projects) {
			if(id == proj.ID) {
				foreach(var item in proj.employees) {
					GameObject newPanel = Instantiate (projectEmployeePanel) as GameObject;
					EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
					panel.nameLabel.text = item.characterName;
					panel.genderLabel.text = item.gender.ToString();
					panel.moraleLabel.text = item.morale.ToString();
					panel.speedLabel.text = item.speed.ToString();
					panel.salaryLabel.text = item.salary.ToString();
					panel.employeeIcon.sprite = item.sprite;
					panel.ID.text = item.ID.ToString();
					panel.ProjectID.text = id.ToString();
					
					newPanel.transform.SetParent (projectEmployeeContentPanel);
					panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				}
			}
		}
	}

	public void addEmployee(IDPair ids){
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in myCompany.characters){
					if(emp.ID == employeeID){
						emp.onProject = true;
						proj.employees.Add(emp);
						Destroy(availableEmployeePanel);
						break;
					}
				}
				break;
			}
		}
	}

	public void removeEmployee (IDPair ids) {
		Debug.Log("YOLO");
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in proj.employees){
					if(emp.ID == employeeID){
						emp.onProject = false;
						proj.employees.Remove(emp);
						Destroy(projectEmployeePanel);
						break;
					}
				}
				break;
			}
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

	public void closeAvailableEmployeeList () {
		selectEmployeesCanvasIsOpen = !selectEmployeesCanvasIsOpen;
		SelectEmployeesCanvas.enabled = !SelectEmployeesCanvas.enabled;
		foreach (Transform child in availableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
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
				myCompany.partialSalaries += (int)(emp.salary * ((4 - (myCompany.weeksPassed % 4)) / 4.0));
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
				myCompany.partialSalaries += (int)(emp.salary * ((myCompany.weeksPassed % 4) / 4.0));
				myCompany.characters.Remove(emp);
				emp.gameObject.transform.position = new Vector3(-1000, -1000, 0);
				Destroy(employeePrefab);
				break;
			}
		}
		//takePlant();
	}


	public Canvas skillsCanvas;
	bool skillsCanvasIsOpen = false;
	public GameObject skillsMenuPrefab;
	GameObject myCamera;
	
	public void openSkills (Text _id) {
		myCamera = GameObject.Find ("Main Camera");
		skillsCanvas = myCamera.GetComponent<CreateScrollList>().skillsCanvas;
		skillsMenuContentPanel = myCamera.GetComponent<CreateScrollList> ().skillsMenuContentPanel;
		int id = Int32.Parse(_id.text);
		GameObject newskillsPanel = Instantiate (skillsMenuPrefab) as GameObject;
		SkillsMenu skills = newskillsPanel.GetComponent <SkillsMenu> ();

		foreach(Character emp in myCompany.characters){
			if(id == emp.ID){
				skills.Graphics.text = emp.skills [0].ToString();
				skills.AI.text = emp.skills [1].ToString();
				skills.Algorithms.text = emp.skills [2].ToString();
				skills.Databases.text = emp.skills [3].ToString();
				skills.Debugging.text = emp.skills [4].ToString();
				skills.Design.text = emp.skills [5].ToString();
				skills.Research.text = emp.skills [6].ToString();
				skills.ERP.text = emp.skills [7].ToString();
				skills.Hacking.text = emp.skills [8].ToString();
				skills.Networking.text = emp.skills [9].ToString();
				skills.Recursion.text = emp.skills [10].ToString();
				skills.StateMachine.text = emp.skills [11].ToString();
				skills.WebDevelopment.text = emp.skills [12].ToString();
				
				skillsCanvasIsOpen = !skillsCanvasIsOpen;
				skillsCanvas.enabled = !skillsCanvas.enabled;
				newskillsPanel.transform.SetParent (skillsMenuContentPanel);
				skills.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				break;
			}
		}
		

	}
	public void openApplicantSkills (Text _id) {
		myCamera = GameObject.Find ("Main Camera");
		skillsCanvas = myCamera.GetComponent<CreateScrollList>().skillsCanvas;
		skillsMenuContentPanel = myCamera.GetComponent<CreateScrollList> ().skillsMenuContentPanel;
		int id = Int32.Parse(_id.text);
		GameObject newskillsPanel = Instantiate (skillsMenuPrefab) as GameObject;
		SkillsMenu skills = newskillsPanel.GetComponent <SkillsMenu> ();

		foreach (Character emp in myCompany.applicants) {
			if (id == emp.ID) {
				skills.Graphics.text = emp.skills [0].ToString ();
				skills.AI.text = emp.skills [1].ToString ();
				skills.Algorithms.text = emp.skills [2].ToString ();
				skills.Databases.text = emp.skills [3].ToString ();
				skills.Debugging.text = emp.skills [4].ToString ();
				skills.Design.text = emp.skills [5].ToString ();
				skills.Research.text = emp.skills [6].ToString ();
				skills.ERP.text = emp.skills [7].ToString ();
				skills.Hacking.text = emp.skills [8].ToString ();
				skills.Networking.text = emp.skills [9].ToString ();
				skills.Recursion.text = emp.skills [10].ToString ();
				skills.StateMachine.text = emp.skills [11].ToString ();
				skills.WebDevelopment.text = emp.skills [12].ToString ();
				
				skillsCanvasIsOpen = !skillsCanvasIsOpen;
				skillsCanvas.enabled = !skillsCanvas.enabled;
				newskillsPanel.transform.SetParent (skillsMenuContentPanel);
				skills.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			}
		}
	}
	
	public void closeSkills () {
		skillsCanvasIsOpen = !skillsCanvasIsOpen;
		skillsCanvas.enabled = !skillsCanvas.enabled;
		foreach (Transform child in skillsMenuContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
	}
}
