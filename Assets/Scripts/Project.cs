using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project : MonoBehaviour {

	public int ID;
	public int deadline;
	public int workAmount;
	public int reward;
	public int penalty;
	// What kind of project it is
	public int skill;
	public int expectedQuality;
	public ProjectMenu menu;
	public List<Employee> employees;

	// Use this for initialization
	void Start () {
		employees = new List<Employee>();
		menu = gameObject.AddComponent<ProjectMenu>() as ProjectMenu;
		menu.projectID = this.ID;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Project createProject () {
		Project proj = gameObject.AddComponent<Project>() as Project;
		proj.deadline = Random.Range (1, 10);
		if (proj.deadline < 3) {
			proj.workAmount = Random.Range (5, 20);
		} else if (proj.deadline < 6) {
			proj.workAmount = Random.Range (20, 60);
		} else {
			proj.workAmount = Random.Range (50, 100);
		}
		proj.reward = Random.Range (workAmount - 5, workAmount + 5) * 10;
		proj.penalty = Random.Range (100, 300);
		proj.skill = Random.Range (0, 12);
		// TODO: Possibly add other factors, like length of project and work amount
		//proj.expectedQuality = Random.Range(10, 80);
		proj.expectedQuality = (int)((double)(proj.deadline / proj.workAmount) * Random.Range(200, 400));

		return proj;
	}

	void pickProject () {

	}

	char calcGrade () {
		int totalQuality = 0;
		foreach (Employee emp in employees) {
			totalQuality += emp.skills[this.skill] * emp.speed;
		}
		int quality = totalQuality / employees.Count;
		int ratio = (quality / this.expectedQuality) * 10;

		//Month myMonth = GetComponent<Month>();
		Month myMonth = gameObject.GetComponent<Month>();
		myMonth.totalQuality += ratio;
		myMonth.numberOfProjectsFinished++;

		Company myCompany = gameObject.GetComponent<Company>();

		if (ratio >= 9) {
			myCompany.jobSecurity += 2;
			return 'A';
		} else if (ratio == 8) {
			myCompany.jobSecurity += 1;
			return 'B';
		} else if (ratio == 7) {
			return 'C';
		} else if (ratio == 6) {
			myCompany.jobSecurity -= 1;
			return 'D';
		} else if (ratio == 5) {
			myCompany.jobSecurity -= 2;
			return 'E';
		} else {
			myCompany.jobSecurity -= 3;
			return 'F';
		}
	}
}
