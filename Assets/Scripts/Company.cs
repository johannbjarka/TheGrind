using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Company : MonoBehaviour {

	public GameObject employeePrefab;
	public Budget budget;
	public Month month;
	public int weeksPassed;
	private int projectID = 0;
	public int characterID = 0;
	public int jobSecurity = 75;
	public int maxEmployees = 20;
	public List<Character> characters;
	public List<Character> applicants;
	public List<Project> projects;
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
			Vector3 pos = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0f);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			emp.isApplicant = false;
			characters.Add(emp);
		}

		// Create 5 starting applicants
		for(int i = 0; i < 5; i++) {
			GameObject character;
			Vector3 pos = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), -100f);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			applicants.Add(emp);
		}

		// Initialize month
		month = gameObject.AddComponent<Month>() as Month;
		month.numberOfProjectsFinished = 0;
		month.totalQuality = 0;

		//Initialize weeks
		weeksPassed = 0;

		//Initialize project lists
		projects = new List<Project>();
		completedProjects = new List<Project>();
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
