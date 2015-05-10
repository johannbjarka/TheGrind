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
		float ratio = 0.0f;
		int category = 0;

		foreach(var proj in myCompany.projects) {
			if(id == proj.ID) {
				ratio = (float)proj.workEstimate / proj.workAmount;
				category = proj.category;
				break;
			}
		}

		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleFill(ratio);

		foreach (var item in myCompany.characters) {
			if(!item.onProject){
				GameObject newPanel = Instantiate (availableEmployeePanel) as GameObject;
				EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();

				panel.nameLabel.text = item.characterName;
				panel.genderLabel.text = item.gender.ToString();
				panel.moraleLabel.text = item.morale.ToString();
				panel.speedLabel.text = item.speed.ToString();
				panel.salaryLabel.text = item.salary.ToString();
				panel.employeeIcon.sprite = item.sprite;
				panel.ID.text = item.ID.ToString();
				panel.ProjectID.text = id.ToString();
				panel.category.text = myCompany.skills[category];
				panel.rating.text = item.skills[category].ToString();

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
		float ratio = 0.0f;

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
					panel.category.text = myCompany.skills[proj.category];
					panel.rating.text = item.skills[proj.category].ToString();

					newPanel.transform.SetParent (projectEmployeeContentPanel);
					panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				}
				ratio = (float)proj.workEstimate / proj.workAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleRemoveFill(ratio);
	}

	public void addEmployee(IDPair ids){
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in myCompany.characters){
					if(emp.ID == employeeID){
						emp.onProject = true;
						proj.employees.Add(emp);
						proj.workEstimate += emp.speed * proj.deadline;
						Destroy(availableEmployeePanel);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.workAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleFill(ratio);
	}

	public void removeEmployee (IDPair ids) {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in proj.employees){
					if(emp.ID == employeeID){
						emp.onProject = false;
						proj.workEstimate -= emp.speed * proj.deadline;
						proj.employees.Remove(emp);
						Destroy(projectEmployeePanel);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.workAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleRemoveFill(ratio);
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
		//TODO: Take plant.
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

		foreach(Character emp in myCompany.characters) {
			if(id == emp.ID) {
				skills.AI.text = emp.skills [0].ToString();
				skills.Algorithms.text = emp.skills [1].ToString();
				skills.Databases.text = emp.skills [2].ToString();
				skills.Hacking.text = emp.skills [3].ToString();
				skills.Networking.text = emp.skills [4].ToString();
				skills.WebDevelopment.text = emp.skills [5].ToString();
			
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
				skills.AI.text = emp.skills [0].ToString ();
				skills.Algorithms.text = emp.skills [1].ToString ();
				skills.Databases.text = emp.skills [2].ToString ();
				skills.Hacking.text = emp.skills [3].ToString ();
				skills.Networking.text = emp.skills [4].ToString ();
				skills.WebDevelopment.text = emp.skills [5].ToString ();
				
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
