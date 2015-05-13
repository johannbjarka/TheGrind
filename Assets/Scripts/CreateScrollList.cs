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
	public GameObject initialAvailableEmployeePanel;
	public GameObject applicantsPanel;
	public GameObject applicantPrefab;
	public GameObject employeePrefab;
	public GameObject projectEmployeePanel;

	public Transform employeeContentPanel;
	public Transform applicantContentPanel;
	public Transform availableEmployeeContentPanel;
	public Transform initialAvailableEmployeeContentPanel;
	public Transform skillsMenuContentPanel;
	public Transform projectEmployeeContentPanel;

	ClickSound click;

	void Start () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
	}

	public void PopulateEmployeeList () {
		emptyEmployeeList ();
		foreach (var item in myCompany.characters) {
			GameObject newPanel = Instantiate (employeePanel) as GameObject;
			EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			panel.nameLabel.text = item.characterName;
			panel.genderLabel.text = item.gender.ToString();
			panel.moraleLabel.text = item.morale.ToString();
			panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
			panel.speedLabel.text = item.speed.ToString();
			panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
			panel.salaryLabel.text = item.salary.ToString();
			panel.employeeIcon.sprite = item.sprite;
			panel.ID.text = item.ID.ToString();
			if(item.onProject) {
				if(item.project.Length > 12) {
					panel.project.text = item.project.Substring(0, 9) + "...";
				}
				else {
					panel.project.text = item.project;
				}
			}
			else {
				panel.project.text = "None";
			}
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
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
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
				panel.employeeIcon.sprite = item.sprite;
				panel.ID.text = item.ID.ToString();
				panel.ProjectID.text = id.ToString();
				panel.category.text = myCompany.skills[category];
				panel.rating.text = item.skills[category].ToString();
				panel.rating.text = item.skills[category].ToString() + " / 20";
				panel.requiredSkillBar.sizeDelta = new Vector2(item.skills[category] * 10, 20);

				newPanel.transform.SetParent (availableEmployeeContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
		}
	}

	public Canvas SelectInitialEmployeesCanvas;
	bool selectInitialEmployeesCanvasIsOpen = false;
	
	public void PopulateAvailableInitialEmployeeList (int id) {
		selectInitialEmployeesCanvasIsOpen = !selectInitialEmployeesCanvasIsOpen;
		SelectInitialEmployeesCanvas.enabled = !SelectInitialEmployeesCanvas.enabled;
		float ratio = 0.0f;
		int category = 0;
		
		foreach(var proj in myCompany.availableProjects) {
			if(id == proj.ID) {
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				category = proj.category;
				break;
			}
		}
		
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleInitialFill(ratio);
		
		foreach (var item in myCompany.characters) {
			if(!item.onProject){
				GameObject newPanel = Instantiate (initialAvailableEmployeePanel) as GameObject;
				EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
				
				panel.nameLabel.text = item.characterName;
				panel.genderLabel.text = item.gender.ToString();
				panel.moraleLabel.text = item.morale.ToString();
				panel.speedLabel.text = item.speed.ToString();
				panel.employeeIcon.sprite = item.sprite;
				panel.ID.text = item.ID.ToString();
				panel.ProjectID.text = id.ToString();
				panel.category.text = myCompany.skills[category];
				panel.rating.text = item.skills[category].ToString() + " / 20";
				panel.requiredSkillBar.sizeDelta = new Vector2(item.skills[category] * 10, 20);
				
				newPanel.transform.SetParent (initialAvailableEmployeeContentPanel);
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
					panel.employeeIcon.sprite = item.sprite;
					panel.ID.text = item.ID.ToString();
					panel.ProjectID.text = id.ToString();
					panel.rating.text = item.skills[proj.category].ToString() + " / 20";
					panel.requiredSkillBar.sizeDelta = new Vector2(item.skills[proj.category] * 10, 20);

					newPanel.transform.SetParent (projectEmployeeContentPanel);
					panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleRemoveFill(ratio);
	}

	public void addEmployee(IDPair ids){
		click.playSound();

		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in myCompany.characters){
					if(emp.ID == employeeID){
						emp.onProject = true;
						emp.project = proj.projName;
						proj.employees.Add(emp);
						proj.workEstimate += emp.speed * proj.deadline;
						Destroy(availableEmployeePanel);
						break;
					}
				}
				// TODO: 
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleFill(ratio);
	}

	public void initialAddEmployee(IDPair ids){
		click.playSound();

		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == projectID){
				foreach(Character emp in myCompany.characters){
					if(emp.ID == employeeID){
						emp.onProject = true;
						emp.project = proj.projName;
						proj.employees.Add(emp);
						proj.workEstimate += emp.speed * proj.deadline;
						Destroy(availableEmployeePanel);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleInitialFill(ratio);
	}

	public void removeEmployee (IDPair ids) {
		click.playSound();

		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in proj.employees){
					if(emp.ID == employeeID){
						emp.onProject = false;
						emp.project = "";
						proj.workEstimate -= emp.speed * proj.deadline;
						proj.employees.Remove(emp);
						Destroy(projectEmployeePanel);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressBar progBar = GameObject.Find("Main Camera").GetComponent<ProgressBar>();
		progBar.scaleRemoveFill(ratio);
	}

	public void PopulateApplicantList () {
		emptyEmployeeList ();
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
		click.playSound();

		selectEmployeesCanvasIsOpen = !selectEmployeesCanvasIsOpen;
		SelectEmployeesCanvas.enabled = !SelectEmployeesCanvas.enabled;


		foreach (Transform child in availableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void closeInitialAvailableEmployeeList () {
		click.playSound();

		selectInitialEmployeesCanvasIsOpen = !selectInitialEmployeesCanvasIsOpen;
		SelectInitialEmployeesCanvas.enabled = !SelectInitialEmployeesCanvas.enabled;

		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == myCompany.selectedProject){
				myCompany.projects.Add(proj);
				myCompany.availableProjects.Remove(proj);
				break;
			}
		}
		
		/*foreach (Transform child in initialAvailableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}*/
	}

	public void closeInitialAvailableEmployeeListOnCancel () {
		click.playSound();

		selectInitialEmployeesCanvasIsOpen = !selectInitialEmployeesCanvasIsOpen;
		SelectInitialEmployeesCanvas.enabled = !SelectInitialEmployeesCanvas.enabled;
		
		foreach (Transform child in initialAvailableEmployeeContentPanel) {
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

	public void emptyInitialAvailableEmployeeList() {
		foreach(Transform child in initialAvailableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void hire (Text _id){
		click.playSound();
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
		click.playSound();

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
				skills.transform.position = new Vector3(0,1.0f,0);

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
				skills.transform.position = new Vector3(0,1.0f,0);
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
