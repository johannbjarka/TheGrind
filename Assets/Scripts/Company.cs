using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Company : MonoBehaviour {

	public GameObject employeePrefab;
	public GameObject projectPrefab;
	public Budget budget;
	public Month month;
	public int weeksPassed;
	private int projectID = 0;
	public int characterID = 0;
	public int jobSecurity = 75;
	public int maxEmployees = 20;
	public List<Character> characters;
	public List<Character> applicants;
	// Currently active projects
	public List<Project> projects;
	public List<Project> availableProjects;
	public List<Project> completedProjects;

	// Use this for initialization
	void Start () {
		// Initialize budget
		budget = gameObject.AddComponent<Budget>() as Budget;
		budget.totalSalaries = 0;
		budget.miscCost = 200;
		budget.projectRewards = 0;
		budget.projectPenalties = 0;
		budget.monthlyAmount = 1000;

		// Create 5 starting employees
		for(int i = 0; i < 5; i++) {
			GameObject character;
			Vector3 pos = new Vector3(-8+Random.value*10, -2+Random.value*5, 0);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			emp.isApplicant = false;
			characters.Add(emp);
		}

		// Create 5 starting applicants
		for(int i = 0; i < 5; i++) {
			GameObject character;
			Vector3 pos = new Vector3(1000, 1000, -100f);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			applicants.Add(emp);
		}

		GameObject projectObj = Instantiate(projectPrefab) as GameObject;
		Project proj = projectObj.GetComponent<Project>();
		// Hard code project for alpha test
		Project myProject = projectPrefab.GetComponent<Project>();
		proj.projName = myProject.projectNames[0];
		proj.description = myProject.projectDescriptions[0];
		proj.deadline = 2;
		proj.workAmount = 15;
		proj.reward = 200;
		proj.penalty = 120;
		proj.expectedQuality = 27;
		proj.category = 8;
		availableProjects.Add(proj);

		proj.projName = myProject.projectNames[1];
		proj.description = myProject.projectDescriptions[1];
		proj.deadline = 1;
		proj.workAmount = 7;
		proj.reward = 100;
		proj.penalty = 100;
		proj.expectedQuality = 30;
		proj.category = 0;
		availableProjects.Add(proj);

		proj.projName = myProject.projectNames[2];
		proj.description = myProject.projectDescriptions[2];
		proj.deadline = 3;
		proj.workAmount = 27;
		proj.reward = 250;
		proj.penalty = 170;
		proj.expectedQuality = 40;
		proj.category = 2;
		availableProjects.Add(proj);

		proj.projName = myProject.projectNames[3];
		proj.description = myProject.projectDescriptions[3];
		proj.deadline = 4;
		proj.workAmount = 30;
		proj.reward = 300;
		proj.penalty = 300;
		proj.expectedQuality = 40;
		proj.category = 12;
		availableProjects.Add(proj);

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
	}

	int getTotalSalaries () {
		// 250 is the player characters salary
		int totalSalaries = 250;
		foreach(Character c in characters) {
			if(!c.isApplicant) {
				totalSalaries += c.salary;
			} 
		}
		return totalSalaries;
	}

	void setProjectID (Project proj) {
		proj.ID = projectID;
		projectID++;
	}
}
