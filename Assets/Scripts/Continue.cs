using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

	public int projectsFinished;
	public int monthlyBalance;
	public char monthlyGrade;
	public int newBudget;
	public Text	projName;
	public Text rewPen;
	public Text rewPenAmount;
	public Text grade;
	public Canvas performanceReview;
	Company myCompany;
	public Canvas gotFiredCanvas;
	public bool gotFiredCanvasIsOpen = false;
	public GameObject gotFiredPanelPrefab;

	public Transform gotFiredContentPanel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void continueGame () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.weeksPassed++;
		

		for(int i = 0; i < myCompany.projects.Count; i++) {
			myCompany.projects[i].deadline--;
			// Calculate the amount of work done on each project
			foreach(Character emp in myCompany.projects[i].employees) {
				myCompany.projects[i].workAmount -= emp.speed;
			}
			ProjectDone projDone = GameObject.Find("projDone").GetComponent<ProjectDone>();
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
			if((myCompany.projects[i].workAmount <= 0) || 
			   (myCompany.projects[i].deadline == 0)) {

				myCompany.projects.Remove(myCompany.projects[i]);
			}
		}

		// If a month has passed
		if((myCompany.weeksPassed % 4) == 0) {

			myCompany.setTextFields();
			MonthlyReview monthly = GameObject.Find("Monthly").GetComponent<MonthlyReview>();
			monthly.openMonthlyReview();

			myCompany.budget.projectRewards = 0;
			myCompany.budget.projectPenalties = 0;
			myCompany.budget.monthlyAmount = myCompany.month.getNextAllowance();

			if(projectsFinished == 0){
				//myCompany.jobSecurity -= 15;
				//FOR ALPHA
				GameObject newGotFiredPanel = Instantiate (gotFiredPanelPrefab) as GameObject;
				PlayerFiredPanel panel = newGotFiredPanel.GetComponent<PlayerFiredPanel> ();
				panel.explanation.text = "You did not finish any projects this month! This is UNACCEPTAAAABLEEEEEE! You're FIRED!";
				newGotFiredPanel.transform.SetParent (gotFiredContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				panel.transform.position = new Vector3(0,2,0);
				gotFiredCanvas.enabled = !gotFiredCanvas.enabled;
				gotFiredCanvasIsOpen = !gotFiredCanvasIsOpen;
				myCompany.firePlayer(1);
			}
			if(myCompany.characters.Count == 0){
				//myCompany.jobSecurity -= 15;
				//FOR ALPHA
				GameObject newGotFiredPanel = Instantiate (gotFiredPanelPrefab) as GameObject;
				PlayerFiredPanel panel = newGotFiredPanel.GetComponent<PlayerFiredPanel> ();
				panel.explanation.text = "You do not have any employees, you can't do this all by yourself! You're FIRED!";
				gotFiredCanvas.enabled = !gotFiredCanvas.enabled;
				gotFiredCanvasIsOpen = !gotFiredCanvasIsOpen;
				newGotFiredPanel.transform.SetParent (gotFiredContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				panel.transform.position = new Vector3(0,2,0);
				myCompany.firePlayer(2);
			}
			myCompany.month.numberOfProjectsFinished = 0;
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
				GameObject newGotFiredPanel = Instantiate (gotFiredPanelPrefab) as GameObject;
				PlayerFiredPanel panel = newGotFiredPanel.GetComponent<PlayerFiredPanel> ();
				panel.explanation.text = "You're pretty terrible at this, you have been fired and my grandmother is your replacement. She's Jewish so...good with money and that.";
				gotFiredCanvas.enabled = !gotFiredCanvas.enabled;
				gotFiredCanvasIsOpen = !gotFiredCanvasIsOpen;
				newGotFiredPanel.transform.SetParent (gotFiredContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				panel.transform.position = new Vector3(0,2,0);
				myCompany.firePlayer(3);
			}
		}
		else if(myCompany.jobSecurity <= 50){
			int rand = Random.Range(1, 100);
			if(rand > 95){
				GameObject newGotFiredPanel = Instantiate (gotFiredPanelPrefab) as GameObject;
				PlayerFiredPanel panel = newGotFiredPanel.GetComponent<PlayerFiredPanel> ();
				panel.explanation.text = "We have decided to restructure the company, you have been fired to afford the monthly dwarf tossing competition.";
				gotFiredCanvas.enabled = !gotFiredCanvas.enabled;
				gotFiredCanvasIsOpen = !gotFiredCanvasIsOpen;
				newGotFiredPanel.transform.SetParent (gotFiredContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				panel.transform.position = new Vector3(0,2,0);
				myCompany.firePlayer(3);
			}
		}
	}
}
