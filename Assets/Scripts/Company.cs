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

	void Awake () {
		// Create 5 starting employees
		for(int i = 0; i < 5; i++) {
			GameObject character;
			Vector3 pos = new Vector3(-8+Random.value*10, -2+Random.value*5, 0);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
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
	}
	// Use this for initialization
	void Start () {
		// Initialize budget
		budget = gameObject.AddComponent<Budget>() as Budget;
		budget.totalSalaries = 0;
		budget.miscCost = 200;
		budget.projectRewards = 0;
		budget.projectPenalties = 0;
		budget.monthlyAmount = 1000;



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

		GameObject projectObj2 = Instantiate(projectPrefab) as GameObject;
		Project proj2 = projectObj2.GetComponent<Project>();
		proj2.projName = myProject.projectNames[1];
		proj2.description = myProject.projectDescriptions[1];
		proj2.deadline = 1;
		proj2.workAmount = 7;
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
		proj4.reward = 300;
		proj4.penalty = 300;
		proj4.expectedQuality = 40;
		proj4.category = 12;
		availableProjects.Add(proj4);
		projects.Add (proj4);
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
			totalSalaries += c.salary;
		}
		return totalSalaries;
	}

	void setProjectID (Project proj) {
		proj.ID = projectID;
		projectID++;
	}
}
