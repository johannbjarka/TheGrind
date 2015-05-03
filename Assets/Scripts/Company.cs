using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Company : MonoBehaviour {

	public Budget budget;
	public Month month;
	//public Character[] characters;
	public Player player;
	public Dictionary<string, Employee> characters = new Dictionary<string, Employee>();
	public Dictionary<string, Applicant> applicants = new Dictionary<string, Applicant>();
	public Project[] projects;
	public Project[] completedProjects;

	// Use this for initialization
	void Start () {
		// Initialize budget
		budget = gameObject.AddComponent<Budget>() as Budget;
		budget.totalSalaries = 0;
		budget.miscCost = 200;
		budget.projectRewards = 0;
		budget.monthlyAmount = 500;

		// Initialize month
		month = gameObject.AddComponent<Month>() as Month;
		month.numberOfProjectsFinished = 0;
		month.totalQuality = 0;

		//Initialize player
		player = gameObject.AddComponent<Player>() as Player;
		player.salary = 150;
		player.characterName = "Bill Lumbergh";
		player.gender = 'M';
		player.jobSecurity = 75;

		// Initialize employees
		/*Player player = gameObject.AddComponent<Player>() as Player;
		player.salary = 150;
		player.characterName = "Bill Lumbergh";
		player.gender = 'M';
		player.jobSecurity = 75;
		characters[player.characterName] = player;*/

		Applicant appl = gameObject.AddComponent<Applicant>() as Applicant;
		appl = appl.createApplicant();
		Employee emp1 = gameObject.AddComponent<Employee>() as Employee;
		emp1.salary = 100;
		emp1.characterName = "Ron Jones";
		emp1.gender = 'M';
		emp1.skills = appl.skills;
		emp1.speed = appl.speed;
		emp1.morale = 5;
		characters [emp1.characterName] = emp1;

		appl = appl.createApplicant ();
		Employee emp2 = gameObject.AddComponent<Employee>() as Employee;
		emp2.salary = 80;
		emp2.characterName = "Philomena Cunk";
		emp2.gender = 'F';
		emp2.skills = appl.skills;
		emp2.speed = appl.speed;
		emp2.morale = 5;
		characters [emp2.characterName] = emp2;

		appl = appl.createApplicant ();
		Employee emp3 = gameObject.AddComponent<Employee>() as Employee;
		emp3.salary = 110;
		emp3.characterName = "Phyllis Harris";
		emp3.gender = 'F';
		emp3.skills = appl.skills;
		emp3.speed = appl.speed;
		emp3.morale = 5;
		characters [emp3.characterName] = emp3;
	}
	
	// Update is called once per frame
	void Update () {
		budget.totalSalaries = getTotalSalaries();
	}

	int getTotalSalaries () {
		// 150 is the player characters salary
		int totalSalaries = 150;
		foreach(KeyValuePair<string, Character> c in characters) {
			totalSalaries += c.Value.salary; 
		}
		return totalSalaries;
	}	
}
