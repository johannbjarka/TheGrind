using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Company : MonoBehaviour {

	public Budget budget;
	public Month month;
	public int weeksPassed;
	private int projectID = 0;
	public int characterID = 0;
	public int jobSecurity = 75;
	public List<Character> characters;
	//public Dictionary<string, Employee> characters = new Dictionary<string, Employee>();
	//public Dictionary<string, Applicant> applicants = new Dictionary<string, Applicant>();
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
		budget.monthlyAmount = 500;

		// Initialize month
		month = gameObject.AddComponent<Month>() as Month;
		month.numberOfProjectsFinished = 0;
		month.totalQuality = 0;

		//Initialize weeks
		weeksPassed = 0;

		//Initialize project lists
		projects = new List<Project>();
		completedProjects = new List<Project>();

		/*Applicant appl = gameObject.AddComponent<Applicant>() as Applicant;
		Employee emp1 = gameObject.AddComponent<Employee>() as Employee;
		emp1.ID = 0;
		emp1.salary = 100;
		emp1.characterName = "Ron Jones";
		emp1.gender = 'M';
		emp1.skills = appl.skills;
		emp1.speed = appl.speed;
		emp1.morale = 5;
		characters [emp1.characterName] = emp1;
		// Don't need the applicant script anymore
		Destroy(appl);

		appl = appl.createApplicant ();
		Employee emp2 = gameObject.AddComponent<Employee>() as Employee;
		emp2.ID = 1;
		emp2.salary = 80;
		emp2.characterName = "Philomena Cunk";
		emp2.gender = 'F';
		emp2.skills = appl.skills;
		emp2.speed = appl.speed;
		emp2.morale = 5;
		characters [emp2.characterName] = emp2;
		// Don't need the applicant script anymore
		Destroy(appl);

		appl = appl.createApplicant ();
		Employee emp3 = gameObject.AddComponent<Employee>() as Employee;
		emp3.ID = 2;
		emp3.salary = 110;
		emp3.characterName = "Phyllis Harris";
		emp3.gender = 'F';
		emp3.skills = appl.skills;
		emp3.speed = appl.speed;
		emp3.morale = 5;
		characters [emp3.characterName] = emp3;
		// Don't need the applicant script anymore
		Destroy(appl);*/
	}
	
	// Update is called once per frame
	void Update () {
		budget.totalSalaries = getTotalSalaries();
	}

	int getTotalSalaries () {
		// 150 is the player characters salary
		int totalSalaries = 150;
		foreach(Character c in characters) {
			totalSalaries += c.salary; 
		}
		return totalSalaries;
	}

	void setProjectID (Project proj) {
		proj.ID = projectID;
		projectID++;
	}

	/*void setApplicantID (Applicant appl) {
		appl.ID = applicantID;
		applicantID++;
	}*/
}
