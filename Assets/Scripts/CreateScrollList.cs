using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateScrollList : MonoBehaviour {

	Company myCompany;
	public ProgressBar ProgressFill;

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
	public Transform initialRemoveEmployeeContentPanel;


	//public RectTransform progressFill;
	public Canvas SelectInitialEmployeesCanvas;
	bool selectInitialEmployeesCanvasIsOpen = false;

	ClickSound click;

	void Start () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		initialRemoveEmployeeContentPanel = GameObject.FindWithTag("Remove Content Panel").GetComponent<Transform>();
		SelectInitialEmployeesCanvas = GameObject.Find ("SelectEmployees initial").GetComponent<Canvas>();
		initialAvailableEmployeeContentPanel = GameObject.Find ("Init Available Content Panel").GetComponent<Transform> ();
		ProgressFill = GameObject.Find ("Main Camera").GetComponent<ProgressBar> ();
		projectEmployeeContentPanel = GameObject.Find ("Currently On Project Content Panel").GetComponent<Transform> ();
		availableEmployeeContentPanel = GameObject.Find ("Available Content Panel").GetComponent<Transform> ();
	}

	public void PopulateEmployeeList () {
		emptyEmployeeList ();
		foreach (var item in myCompany.characters) {
			if(!item.hasQuit) {
				GameObject newPanel = Instantiate (employeePanel) as GameObject;
				EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
				panel.nameLabel.text = item.characterName;
				if(item.gender == 'M') {
					panel.genderLabel.text = item.gender.ToString() + "ale";
				}else {
					panel.genderLabel.text = item.gender.ToString() + "emale";
				}
				panel.moraleLabel.text = item.morale.ToString();
				panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
				panel.speedLabel.text = item.speed.ToString();
				panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
				panel.salaryLabel.text = "$" + item.salary.ToString();
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
				ProgressFill.setFinalProgressTo(ratio);
				break;
			}
		}

		foreach (var item in myCompany.characters) {
			if(!item.onProject && !item.hasQuit){
				GameObject newPanel = Instantiate (availableEmployeePanel) as GameObject;
				EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();

				panel.nameLabel.text = item.characterName;
				if(item.gender == 'M') {
					panel.genderLabel.text = item.gender.ToString() + "ale";
				}else {
					panel.genderLabel.text = item.gender.ToString() + "emale";
				}
				panel.moraleLabel.text = item.morale.ToString();
				panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
				panel.speedLabel.text = item.speed.ToString();
				panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
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

	public void PopulateAvailableInitialEmployeeList (int id) {
		ProgressFill.setProgressTo (0);
		if (selectInitialEmployeesCanvasIsOpen == false) {
			selectInitialEmployeesCanvasIsOpen = true;
			SelectInitialEmployeesCanvas.enabled = true;
		}
		float ratio = 0.0f;
		int category = 0;
		
		foreach(var proj in myCompany.availableProjects) {
			if(id == proj.ID) {
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				//progressFill.sizeDelta = new Vector2(50, ratio);
				category = proj.category;
				break;
			}
		}
		
		foreach (var item in myCompany.characters) {
			if(!item.onProject && !item.hasQuit){
				GameObject newPanel = Instantiate (initialAvailableEmployeePanel) as GameObject;
				EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
				
				panel.nameLabel.text = item.characterName;
				if(item.gender == 'M') {
					panel.genderLabel.text = item.gender.ToString() + "ale";
				}else {
					panel.genderLabel.text = item.gender.ToString() + "emale";
				}
				panel.moraleLabel.text = item.morale.ToString();
				panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
				panel.speedLabel.text = item.speed.ToString();
				panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
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

	public void populateProjectEmployeeList (int id) {
		float ratio = 0.0f;

		foreach(var proj in myCompany.projects) {
			if(id == proj.ID) {
				foreach(var item in proj.employees) {
					GameObject newPanel = Instantiate (projectEmployeePanel) as GameObject;
					EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
					panel.nameLabel.text = item.characterName;
					if(item.gender == 'M') {
						panel.genderLabel.text = item.gender.ToString() + "ale";
					}else {
						panel.genderLabel.text = item.gender.ToString() + "emale";
					}
					panel.moraleLabel.text = item.morale.ToString();
					panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
					panel.speedLabel.text = item.speed.ToString();
					panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
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
		//progressFill.sizeDelta = new Vector2 (50, ratio);
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

						GameObject newPanel = Instantiate (projectEmployeePanel) as GameObject;
						EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
						panel.nameLabel.text = emp.characterName;
						if(emp.gender == 'M') {
							panel.genderLabel.text = emp.gender.ToString() + "ale";
						}else {
							panel.genderLabel.text = emp.gender.ToString() + "emale";
						}
						panel.moraleLabel.text = emp.morale.ToString();
						panel.moraleBar.sizeDelta = new Vector2(emp.morale * 10, 20);
						panel.speedLabel.text = emp.speed.ToString();
						panel.speedBar.sizeDelta = new Vector2(emp.speed * 10, 20);
						panel.employeeIcon.sprite = emp.sprite;
						panel.ID.text = emp.ID.ToString();
						panel.ProjectID.text = proj.ID.ToString();
						panel.rating.text = emp.skills[proj.category].ToString() + " / 20";
						panel.requiredSkillBar.sizeDelta = new Vector2(emp.skills[proj.category] * 10, 20);
						
						newPanel.transform.SetParent (projectEmployeeContentPanel);
						panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressFill.setFinalProgressTo (ratio);
	}

	public GameObject initalRemoveEmployeePrefab;


	public void initialRemoveEmployee(IDPair ids) {
		click.playSound();
		
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == projectID){
				foreach(Character emp in proj.employees){
					if(emp.ID == employeeID){
						emp.onProject = false;
						emp.project = "";
						proj.workEstimate -= emp.speed * proj.deadline;
						proj.employees.Remove(emp);
						Destroy(initalRemoveEmployeePrefab);

						// Put the employee back into the available list.
						GameObject newPanel = Instantiate (initialAvailableEmployeePanel) as GameObject;
						EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
						
						panel.nameLabel.text = emp.characterName;
						if(emp.gender == 'M') {
							panel.genderLabel.text = emp.gender.ToString() + "ale";
						}else {
							panel.genderLabel.text = emp.gender.ToString() + "emale";
						}
						panel.moraleLabel.text = emp.morale.ToString();
						panel.moraleBar.sizeDelta = new Vector2(emp.morale * 10, 20);
						panel.speedLabel.text = emp.speed.ToString();
						panel.speedBar.sizeDelta = new Vector2(emp.speed * 10, 20);
						panel.employeeIcon.sprite = emp.sprite;
						panel.ID.text = emp.ID.ToString();
						panel.ProjectID.text = proj.ID.ToString();
						panel.category.text = myCompany.skills[proj.category];
						panel.rating.text = emp.skills[proj.category].ToString() + " / 20";
						panel.requiredSkillBar.sizeDelta = new Vector2(emp.skills[proj.category] * 10, 20);
						
						newPanel.transform.SetParent (initialAvailableEmployeeContentPanel);
						panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressFill.setProgressTo (ratio);
	}

	public void initialAddEmployee(IDPair ids){
		click.playSound();

		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		float ratio = 0.0f;
		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == projectID){
				foreach(Character item in myCompany.characters){
					if(item.ID == employeeID){
						item.onProject = true;
						item.project = proj.projName;
						proj.employees.Add(item);
						proj.workEstimate += item.speed * proj.deadline;
						Destroy(availableEmployeePanel);

						GameObject newPanel = Instantiate (initalRemoveEmployeePrefab) as GameObject;
						EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			
						panel.nameLabel.text = item.characterName;
						if(item.gender == 'M') {
							panel.genderLabel.text = item.gender.ToString() + "ale";
						}else {
							panel.genderLabel.text = item.gender.ToString() + "emale";
						}
						panel.moraleLabel.text = item.morale.ToString();
						panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
						panel.speedLabel.text = item.speed.ToString();
						panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
						panel.employeeIcon.sprite = item.sprite;
						panel.ID.text = item.ID.ToString();
						panel.ProjectID.text = proj.ID.ToString();
						panel.category.text = myCompany.skills[proj.category];
						panel.rating.text = item.skills[proj.category].ToString() + " / 20";
						panel.requiredSkillBar.sizeDelta = new Vector2(item.skills[proj.category] * 10, 20);

						newPanel.transform.SetParent (initialRemoveEmployeeContentPanel);
						panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressFill.setProgressTo (ratio);
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
						emp.transform.position = new Vector3(-8 + UnityEngine.Random.value * 10, -2 + UnityEngine.Random.value * 5, 0);
						proj.employees.Remove(emp);
						Destroy(projectEmployeePanel);

						GameObject newPanel = Instantiate (availableEmployeePanel) as GameObject;
						EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
						
						panel.nameLabel.text = emp.characterName;
						if(emp.gender == 'M') {
							panel.genderLabel.text = emp.gender.ToString() + "ale";
						}else {
							panel.genderLabel.text = emp.gender.ToString() + "emale";
						}
						panel.moraleLabel.text = emp.morale.ToString();
						panel.moraleBar.sizeDelta = new Vector2(emp.morale * 10, 20);
						panel.speedLabel.text = emp.speed.ToString();
						panel.speedBar.sizeDelta = new Vector2(emp.speed * 10, 20);
						panel.employeeIcon.sprite = emp.sprite;
						panel.ID.text = emp.ID.ToString();
						panel.ProjectID.text = proj.ID.ToString();
						panel.category.text = myCompany.skills[proj.category];
						panel.rating.text = emp.skills[proj.category].ToString();
						panel.rating.text = emp.skills[proj.category].ToString() + " / 20";
						panel.requiredSkillBar.sizeDelta = new Vector2(emp.skills[proj.category] * 10, 20);
						
						newPanel.transform.SetParent (availableEmployeeContentPanel);
						panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
						break;
					}
				}
				ratio = (float)proj.workEstimate / proj.initialWorkAmount;
				break;
			}
		}
		ProgressFill.setFinalProgressTo (ratio);
	}

	public void PopulateApplicantList () {
		emptyEmployeeList ();
		foreach (var item in myCompany.applicants) {
			GameObject newPanel = Instantiate (applicantsPanel) as GameObject;
			EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			panel.nameLabel.text = item.characterName;
			if(item.gender == 'M') {
				panel.genderLabel.text = item.gender.ToString() + "ale";
			}else {
				panel.genderLabel.text = item.gender.ToString() + "emale";
			}
			panel.moraleLabel.text = item.morale.ToString();
			panel.moraleBar.sizeDelta = new Vector2(item.morale * 10, 20);
			panel.speedLabel.text = item.speed.ToString();
			panel.speedBar.sizeDelta = new Vector2(item.speed * 10, 20);
			panel.salaryLabel.text = "$" + item.salary.ToString();
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

	public void closeManageProjectEmployeesPanel() {
		click.playSound ();

		selectEmployeesCanvasIsOpen = false;
		SelectEmployeesCanvas.enabled = false;

		foreach (Transform child in availableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}

		foreach (Transform child in projectEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
		CreateProjectScrollList curprojects = GameObject.Find ("Main Camera").GetComponent<CreateProjectScrollList> ();
		curprojects.PopulateCurrentProjectList ();
	}

	public void closeInitialAvailableEmployeeList () {
		click.playSound();

		selectInitialEmployeesCanvasIsOpen = false;
		SelectInitialEmployeesCanvas.enabled = false;

		foreach (Transform child in initialRemoveEmployeeContentPanel) {
			GameObject.Destroy (child.gameObject);
		}
		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == myCompany.selectedProject){
				myCompany.projects.Add(proj);
				myCompany.availableProjects.Remove(proj);
				break;
			}
		}
	}

	public void closeInitialAvailableEmployeeListOnCancel () {
		click.playSound();

		selectInitialEmployeesCanvasIsOpen = !selectInitialEmployeesCanvasIsOpen;
		SelectInitialEmployeesCanvas.enabled = !SelectInitialEmployeesCanvas.enabled;
		
		foreach (Transform child in initialAvailableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
		foreach (Transform child in initialRemoveEmployeeContentPanel) {
			GameObject.Destroy (child.gameObject);
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

	public void emptyAvailableEmployeeList() {
		foreach (Transform child in availableEmployeeContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void hire (Text _id){
		click.playSound();
		int id = Int32.Parse(_id.text);

		if(myCompany.characters.Count == myCompany.maxEmployees) {
			TooManyEmployees tooMany = GameObject.FindWithTag("TooMany").GetComponent<TooManyEmployees>();
			tooMany.openTooMany();
		}
		else {
			foreach(Character emp in myCompany.applicants){
				if(emp.ID == id){
					myCompany.partialSalaries += (int)(emp.salary * ((4 - (myCompany.weeksPassed % 4)) / 4.0));
					myCompany.partialSalaries -= emp.salary;
					myCompany.characters.Add(emp);
					myCompany.applicants.Remove(emp);
					emp.gameObject.transform.position = new Vector3(-8 + UnityEngine.Random.value * 10, -2 + UnityEngine.Random.value * 5, 0);
					emp.gameObject.transform.localScale = new Vector2(1,1);
					Destroy(applicantPrefab);
					myCompany.IncrementEmployeeNumber();
					break;
				}
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
					proj.workEstimate -= emp.speed * proj.deadline;
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
				myCompany.DecrementEmployeeNumber();
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

