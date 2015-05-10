using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

	public int newBudget;
	public Text	projName;
	public Text rewPen;
	public Text rewPenAmount;
	public Text grade;
	public Canvas projectDone;
	public Canvas performanceReview;
	Company myCompany;

	public void continueGame () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.weeksPassed++;
		
		for(int i = 0; i < myCompany.availableProjects.Count; i++) {
			myCompany.availableProjects[i].deadline--;
		}

		for(int i = 0; i < myCompany.availableProjects.Count; i++) {
			if(myCompany.availableProjects[i].deadline == 0) {
				myCompany.availableProjects.Remove(myCompany.availableProjects[i]);
			}
		}

		for(int i = 0; i < myCompany.projects.Count; i++) {
			myCompany.projects[i].deadline--;
			// Calculate the amount of work done on each project
			foreach(Character emp in myCompany.projects[i].employees) {
				myCompany.projects[i].workAmount -= emp.speed;
			}
			ProjectDone projDone = GameObject.Find("ProjDone").GetComponent<ProjectDone>();
			// If the project is finished, add it to completed projects, add the 
			// reward to the budget and remove it from projects.
			if(myCompany.projects[i].workAmount <= 0) {
				myCompany.completedProjects.Add(myCompany.projects[i]);
				myCompany.budget.projectRewards += myCompany.projects[i].reward;
				myCompany.month.numberOfProjectsFinished++;
				projName.text = myCompany.projects[i].projName;
				rewPen.text = "Reward for project";
				rewPenAmount.text = myCompany.projects[i].reward.ToString();
				grade.text = myCompany.projects[i].calcGrade().ToString();
				projDone.openProjectDone();
				// Remove employees from the project
				foreach(Character emp in myCompany.projects[i].employees) {
					emp.onProject = false;
				}

			}
			// If a project's deadline has passed and it's not finished we 
			// remove it from projects and add the penalty to projectPenalties. 
			if(myCompany.projects[i].deadline == 0 && myCompany.projects[i].workAmount > 0) {
				myCompany.budget.projectPenalties += myCompany.projects[i].penalty;
				projName.text = myCompany.projects[i].projName;
				rewPen.text = "Penalty for project";
				rewPenAmount.text = myCompany.projects[i].penalty.ToString();
				grade.text = "-";
				projDone.openProjectDone();
				
				// Remove employees from the project
				foreach(Character emp in myCompany.projects[i].employees) {
					emp.onProject = false;
				}
			}
		}

		for(int i = 0; i < myCompany.projects.Count; i++) {
			if((myCompany.projects[i].workAmount <= 0) || 
			   (myCompany.projects[i].deadline == 0)) {
				
				myCompany.projects.Remove(myCompany.projects[i]);
			}
		}

		// If a month has passed
		if((myCompany.weeksPassed % 4) == 0) {
			MonthlyReview monthly = GameObject.Find("Monthly").GetComponent<MonthlyReview>();
			int monthlyBalance = myCompany.budget.getBalance();
			myCompany.month.getGrade();
			myCompany.budget.monthlyAmount = myCompany.month.getNextAllowance();
			myCompany.setTextFields(monthlyBalance);
			monthly.openMonthlyReview();

			if(myCompany.month.numberOfProjectsFinished == 0){
				myCompany.firePlayer("You did not finish any projects this month! This is " +
				                     "UNACCEPTAAAABLEEEEEE! You're FIRED!");
			}
			if(myCompany.characters.Count == 0){
				myCompany.firePlayer("You do not have any employees, you can't do this all by yourself! You're FIRED!");
			}
			myCompany.month.numberOfProjectsFinished = 0;
			myCompany.month.totalQuality = 0;
			myCompany.budget.projectRewards = 0;
			myCompany.budget.projectPenalties = 0;
			myCompany.partialSalaries = 0;
		}

		foreach(Character emp in myCompany.characters) {
			if(emp.morale <= 0) {
				// TODO: send message that employee quit
				myCompany.characters.Remove(emp);
			}
		}
		if(myCompany.jobSecurity <= 25){
			int rand = Random.Range(1, 100);
			if(rand > 80){
				myCompany.firePlayer("You're pretty terrible at this, you have been replaced by a monkey with a typewriter!");
			}
		}
		else if(myCompany.jobSecurity <= 50){
			int rand = Random.Range(1, 100);
			if(rand > 95){
				myCompany.firePlayer("We have decided to restructure the company, you have been fired to " +
				                     "afford the monthly dwarf tossing competition.");
			}
		}
	}
}
