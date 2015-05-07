using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Continue : MonoBehaviour {

	public int projectsFinished;
	public int monthlyBalance;
	public char monthlyGrade;
	public int newBudget;
	public Canvas performanceReview;
	private bool pfReviewOpen = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void continueGame () {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.weeksPassed++;

		// Calculate the amount of work done on each project
		for(int i = 0; i < myCompany.projects.Count; i++) {
			myCompany.projects[i].deadline--;
			foreach(Character emp in myCompany.projects[i].employees) {
				myCompany.projects[i].workAmount -= emp.speed;
			}
			// If the project is finished, add it to completed projects, add the 
			// reward to the budget and remove it from projects.
			if(myCompany.projects[i].workAmount <= 0) {
				myCompany.completedProjects.Add(myCompany.projects[i]);
				myCompany.projects.Remove(myCompany.projects[i]);
				myCompany.budget.projectRewards += myCompany.projects[i].reward;
				
				// Remove employees from the project
				foreach(Character emp in myCompany.projects[i].employees) {
					emp.onProject = false;
				}
			}
			// If a project's deadline has passed and it's not finished we 
			// remove it from projects and add the penalty to projectPenalties. 
			if(myCompany.projects[i].deadline == 0 && myCompany.projects[i].workAmount > 0) {
				myCompany.budget.projectPenalties += myCompany.projects[i].penalty;
				
				// Remove employees from the project
				foreach(Character emp in myCompany.projects[i].employees) {
					emp.onProject = false;
				}
				myCompany.projects.Remove(myCompany.projects[i]);
			}
		}

		// If a month has passed
		if((myCompany.weeksPassed % 4) == 0) {
			projectsFinished = myCompany.month.numberOfProjectsFinished;
			monthlyBalance = myCompany.month.calcFinalBalance();
			monthlyGrade = myCompany.month.getGrade();
			newBudget = myCompany.month.getNextAllowance();
			myCompany.budget.projectRewards = 0;
			myCompany.budget.projectPenalties = 0;
			myCompany.budget.monthlyAmount = newBudget;

			if(projectsFinished == 0){
				//myCompany.jobSecurity -= 15;
				//FOR ALPHA
				myCompany.firePlayer(1);
			}
			if(myCompany.characters.Count == 0){
				//myCompany.jobSecurity -= 15;
				//FOR ALPHA
				myCompany.firePlayer(2);
			}
			//pfReviewOpen = !pfReviewOpen;
			//performanceReview.enabled = !performanceReview.enabled;
		}

		foreach(Character emp in myCompany.characters) {
			if(emp.morale <= 0) {
				// TODO: send message that employee quit
				myCompany.characters.Remove(emp);
			}
		}
	}
}
