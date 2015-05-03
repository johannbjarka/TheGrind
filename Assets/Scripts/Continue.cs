using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Continue : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void continueToNextWeek () {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.weeksPassed++;

		foreach(Project proj in myCompany.projects) {
			proj.deadline--;
			// Calculate the amount of work done on each project
			foreach(Employee emp in proj.employees) {
				proj.workAmount -= emp.speed;
			}
			// If the project is finished, add it to completed projects, add the 
			// reward to the budget and remove it from projects.
			if(proj.workAmount <= 0) {
				myCompany.completedProjects.Add(proj);
				myCompany.projects.Remove(proj);
				myCompany.budget.projectRewards += proj.reward;
				//TODO: Remove employees from the project
			}
			// If a project's deadline has passed and it's not finished we 
			// remove it from projects and add the penalty to projectPenalties. 
			if(proj.deadline == 0 && proj.workAmount > 0) {
				myCompany.projects.Remove(proj);
				myCompany.budget.projectPenalties += proj.penalty;
				//TODO: Remove employees from the project
			}
		}

		// If a month has passed
		if((myCompany.weeksPassed % 4) == 0) {
			int projectsFinished = myCompany.month.numberOfProjectsFinished;
			int monthlyBalance = myCompany.month.calcFinalBalance();
			char monthlyGrade = myCompany.month.getGrade();
			int newBudget = myCompany.month.getNextAllowance();
			myCompany.budget.projectRewards = 0;
			myCompany.budget.projectPenalties = 0;
			myCompany.budget.monthlyAmount = newBudget;
		}

		foreach(KeyValuePair<string, Employee> emp in myCompany.characters) {
			if(emp.Value.morale <= 0) {
				// TODO: send message that employee quit
				myCompany.characters.Remove(emp.Value.characterName);
			}
		}
	}
}
