﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Company : MonoBehaviour {

	public GameObject employeePrefab;
	public GameObject projectPrefab;
	public Budget budget;
	public Month month;
	public int weeksPassed;
	public int jobSecurity = 75;
	public int maxEmployees = 20;
	public int selectedProject;
	public List<Character> characters;
	public List<Character> applicants;
	// Currently active projects
	public List<Project> projects;
	public List<Project> availableProjects;
	public List<Project> completedProjects;
	public List<GameObject> tables;
	public List<Sprite> originaltables;
	public int partialSalaries = 0;
	public Text weeks;
	public Text balance;
	public Text balance2;
	public Text salaries;
	public Text misc;
	public Text income;
	public Text penalties;
	public Text allocated;
	public Text projFinished;
	public Text monthBalance;
	public Text monthJobSecurity;
	public Text grade;
	public Text nextBudget;
	public Text jobSec;

	public Dictionary<int, string> skills;

	public Canvas gotFiredCanvas;
	bool gotFiredCanvasIsOpen = false;
	public GameObject gotFiredPanelPrefab;
	
	public Transform gotFiredContentPanel;

	void Awake () {
		// Create 5 starting employees
		for(int i = 0; i < 7; i++) {
			GameObject character;
			Vector3 pos = new Vector3(-8+Random.value*10, -2+Random.value*5, 0);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			characters.Add(emp);
		}
		
		// Create 5 starting applicants
		for(int i = 0; i < 8; i++) {
			GameObject character;
			Vector3 pos = new Vector3(1000, 1000, -100f);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			applicants.Add(emp);
		}
	}
	// Use this for initialization
	void Start () {
		// Initialize budget
		budget = gameObject.AddComponent<Budget>() as Budget;
		budget.totalSalaries = 0;
		budget.miscCost = 200;
		budget.projectRewards = 0;
		budget.projectPenalties = 0;
		budget.monthlyAmount = 1500;

		skills = new Dictionary<int, string>();
		skills[0] = "AI:";
		skills[1] = "Algorithms:";
		skills[2] = "Databases:";
		skills[3] = "Hacking:";
		skills[4] = "Networking:";
		skills[5] = "Web Dev:";

		GameObject projectObj = Instantiate(projectPrefab) as GameObject;
		Project proj = projectObj.GetComponent<Project>();
		// Hard code project for alpha test
		Project myProject = projectPrefab.GetComponent<Project>();
		proj.projName = myProject.projectNames[0];
		proj.description = myProject.projectDescriptions[0];
		proj.deadline = 2;
		proj.workAmount = 15;
		proj.initialWorkAmount = proj.workAmount;
		proj.reward = 200;
		proj.penalty = 120;
		proj.expectedQuality = 27;
		proj.category = 3;
		availableProjects.Add(proj);

		GameObject projectObj2 = Instantiate(projectPrefab) as GameObject;
		Project proj2 = projectObj2.GetComponent<Project>();
		proj2.projName = myProject.projectNames[1];
		proj2.description = myProject.projectDescriptions[1];
		proj2.deadline = 1;
		proj2.workAmount = 7;
		proj2.initialWorkAmount = proj2.workAmount;
		proj2.reward = 100;
		proj2.penalty = 100;
		proj2.expectedQuality = 30;
		proj2.category = 0;
		availableProjects.Add(proj2);

		GameObject projectObj3 = Instantiate(projectPrefab) as GameObject;
		Project proj3 = projectObj3.GetComponent<Project>();
		proj3.projName = myProject.projectNames[2];
		proj3.description = myProject.projectDescriptions[2];
		proj3.deadline = 3;
		proj3.workAmount = 27;
		proj3.initialWorkAmount = proj3.workAmount;
		proj3.reward = 250;
		proj3.penalty = 170;
		proj3.expectedQuality = 40;
		proj3.category = 2;
		availableProjects.Add(proj3);

		GameObject projectObj4 = Instantiate(projectPrefab) as GameObject;
		Project proj4 = projectObj4.GetComponent<Project>();
		proj4.projName = myProject.projectNames[3];
		proj4.description = myProject.projectDescriptions[3];
		proj4.deadline = 4;
		proj4.workAmount = 30;
		proj4.initialWorkAmount = proj4.workAmount;
		proj4.reward = 300;
		proj4.penalty = 300;
		proj4.expectedQuality = 40;
		proj4.category = 5;
		availableProjects.Add(proj4);
		// Initialize month
		month = gameObject.AddComponent<Month>() as Month;
		month.numberOfProjectsFinished = 0;
		month.totalQuality = 0;

		//Initialize weeks
		weeksPassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		budget.totalSalaries = getTotalSalaries();
		weeks.text = (weeksPassed + 1).ToString();
		if(budget.getBalance() < 0) {
			balance.color = Color.red;
			balance2.color = Color.red;
		}
		else {
			balance.color = Color.black;
			balance2.color = Color.black;
		}
		balance.text = budget.getBalance().ToString();
		balance2.text = budget.getBalance().ToString();
		salaries.text = budget.totalSalaries.ToString();
		misc.text = budget.miscCost.ToString();
		income.text = budget.projectRewards.ToString();
		penalties.text = budget.projectPenalties.ToString();
		allocated.text = budget.monthlyAmount.ToString();
		monthJobSecurity.text = jobSecurity.ToString();
		jobSec.text = jobSecurity.ToString();

		if(jobSecurity > 100){
			jobSecurity = 100;
		}
		else if(jobSecurity <= 0){
			jobSecurity = 0;
			firePlayer("Job security too low!");
		}
		for (int i = 0; i < characters.Count; i++) {
			if(characters[i].onProject)
			{
				//tables[i].GetComponent<SpriteRenderer>().sprite = tables[20].GetComponent<SpriteRenderer>().sprite;
			}
			else{
				//tables[i].GetComponent<SpriteRenderer>().sprite = originaltables[i];
			}
		}
	}

	public void setTextFields (int monthBal) {
		projFinished.text = month.numberOfProjectsFinished.ToString();
		monthBalance.text = monthBal.ToString();
		grade.text = month.grade.ToString();
		nextBudget.text = budget.monthlyAmount.ToString();
	}

	int getTotalSalaries () {
		// 250 is the player characters salary
		int totalSalaries = 250;
		totalSalaries += partialSalaries;
		foreach(Character c in characters) {
			totalSalaries += c.salary;
		}
		return totalSalaries;
	}

	public void firePlayer(string reason){
		//Instantiate the panel
		GameObject newGotFiredPanel = Instantiate (gotFiredPanelPrefab) as GameObject;
		PlayerFiredPanel panel = newGotFiredPanel.GetComponent<PlayerFiredPanel> ();
		// Destroy any existing children
		foreach (Transform child in gotFiredContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
		// Set the text
		panel.explanation.text = reason;
		// Set the parent so the panel knows where to go
		newGotFiredPanel.transform.SetParent (gotFiredContentPanel);
		// Have to set the scale or it will be super large
		panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		// Have to set the position for some reason, else the panel will be too low.
		panel.transform.position = new Vector3(0,2.3f,0);

		// Then show the canvas only if it is closed.
		if(!gotFiredCanvasIsOpen) {
			gotFiredCanvas.enabled = !gotFiredCanvas.enabled;
			gotFiredCanvasIsOpen = !gotFiredCanvasIsOpen;
		}
	}

	public string getDescription (int cat) {
		switch (cat) {
		case 0:
			return "AI";
		case 1:
			return "Algorithms";
		case 2:
			return "Databases";
		case 3:
			return "Hacking";
		case 4:
			return "Networking";
		case 5:
			return "Web Development";
		default:
			return "UNDEFINED CATEGORY";
		}
	}
}
