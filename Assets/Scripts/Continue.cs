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
	public Text isProjDone;
	public Canvas projectDone;
	public Canvas performanceReview;
	Company myCompany;

	public Canvas EmployeeCanvas;
	public Canvas ApplicantCanvas;
	public Canvas ComputerCanvas;
	public Canvas ProjectCanvas;
	public Canvas CurProjectCanvas;
	public Canvas skillsMenuCanvas;
	public Canvas SelectEmployeesCanvas;
	public Canvas SelectInitialEmployeeCanvas;
	public Canvas RemoveEmployeesCanvas;
	public Canvas BudgetCanvas;
	public Canvas GotFiredCanvas;
	public Canvas PerformanceReviewCanvas;
	public Canvas ProjectFinishedCanvas;

	public void continueGame () {
		EmployeeCanvas.enabled = false;
		ApplicantCanvas.enabled = false;
		ComputerCanvas.enabled = false;
		ProjectCanvas.enabled = false;
		CurProjectCanvas.enabled = false;
		skillsMenuCanvas.enabled = false;
		SelectEmployeesCanvas.enabled = false;
		SelectInitialEmployeeCanvas.enabled = false;
		RemoveEmployeesCanvas.enabled = false;
		BudgetCanvas.enabled = false;
		GotFiredCanvas.enabled = false;
		PerformanceReviewCanvas.enabled = false;
		ProjectFinishedCanvas.enabled = false;

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
				isProjDone.text = "Good job! You finished the project in time.";
				projDone.openProjectDone();
				// Remove employees from the project
				foreach(Character emp in myCompany.projects[i].employees) {
					emp.onProject = false;
					emp.transform.position = new Vector3(-8+Random.value*10, -2+Random.value*5, 0);
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
				isProjDone.text = "Oh no! You didn't finish in time. The project needed more employees.";
				projDone.openProjectDone();
				// Remove employees from the project
				foreach(Character emp in myCompany.projects[i].employees) {
					emp.onProject = false;
					emp.transform.position = new Vector3(-8+Random.value*10, -2+Random.value*5, 0);
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

			if(myCompany.month.numberOfProjectsFinished == 0){
				myCompany.firePlayer("You did not finish any projects this month! This is " +
				                     "UNACCEPTAAAABLEEEEEE! You're FIRED!");
			}
			else if(myCompany.characters.Count == 0){
				myCompany.firePlayer("You do not have any employees, you can't do this all by yourself! You're FIRED!");
			}
			else {
				monthly.openMonthlyReview();
			}
			myCompany.month.numberOfProjectsFinished = 0;
			myCompany.month.totalQuality = 0;
			myCompany.budget.projectRewards = 0;
			myCompany.budget.projectPenalties = 0;
			myCompany.partialSalaries = 0;
		}

		//Random event
		int ranEvent = Random.Range(1, 5);
		string eventText = "";
		if(ranEvent == 1) {
			eventText = callEvent();
			Debug.Log(eventText);
		}

		// Employees quit if their morale reaches 0
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

	string callEvent() {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		int randEvent = Random.Range(1, 34);
		string eventText = "";
		
		switch(randEvent){
		case 1:
			eventText = "You played golf with the CEO this weekend. " +
				"You kept it cool and lost on purpose. Budget +$1000";
			myCompany.budget.monthlyAmount += 1000;
			break;
		case 2:
			eventText = "The boss invited you on a badass blimp ride. " +
				"You used company funds to foot the bill. Budget -$2500";
			myCompany.budget.monthlyAmount -= 2500;
			break;
		case 3:
			eventText = "You met the person of your dreams. Flowers and real champagne" +
				" sure can be expensive. Budget -$1000";
			myCompany.budget.monthlyAmount -= 1000;
			break;
		case 4:
			eventText = "The boss came in just before the office closed on Friday" +
				" and launched a drunken tirade at the staff. Staff morale -1";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			break;
		case 5:
			eventText = "Due to incessant requests, management ordered you to pay for " +
				"an in depth seminar on appropriate workplace communication. " +
					"Staff morale +1. Budget -$1000";
			foreach(Character emp in myCompany.characters) {
				emp.morale++;
			}
			myCompany.budget.monthlyAmount -= 1000;
			break;
		case 6:
			eventText = "Your friends prank called your boss and left the impression that " +
				"you're a sexual deviant. Job security -10";
			myCompany.jobSecurity -= 10;
			break;
		case 7:
			eventText = "Your kid got into a fight at school. You left early to cheer her " +
				"on. The boss came by while you were away. Job security -5";
			myCompany.jobSecurity -= 5;
			break;
		case 8:
			eventText = "The office security camera caught a hobo on tape breaking into " +
				"the office and doing his business in the flower pots. Cleanup was a priority. Budget -$500";
			myCompany.budget.monthlyAmount -= 500;
			break;
		case 9:
			eventText = "The office was ransacked over the weekend. The thieves made off with " +
				"a red Swingline stapler and three PCs. Budget -$1000";
			myCompany.budget.monthlyAmount -= 1000;
			break;
		case 10:
			eventText = "You went with your boss to Las Vegas for a conference. He went to a strip joint " +
				"but you didn't want to partake. As punishment he used your departments budget to foot the bill. " +
					"Budget -$1500";
			myCompany.budget.monthlyAmount -= 1500;
			break;
		case 11:
			eventText = "You went all in at the staff party on Friday. Your drunken advances " +
				"made everyone uncomfortable. Staff morale -1, Job security -5";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			myCompany.jobSecurity -= 5;
			break;
		case 12:
			eventText = "You decided to increase office morale by holding a screening of " +
				"\"Requiem For A Dream\". Staff morale -1";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			break;
		case 13:
			eventText = "You went to lunch with the top brass. Your jokes were unusually well " +
				"received. Job security +5";
			myCompany.jobSecurity += 5;
			break;
		case 14:
			eventText = "You made an inappropriately left-leaning political comment at a board meeting. " +
				"Job security -5";
			myCompany.jobSecurity -= 5;
			break;
		case 15:
			eventText = "You forwarded a wildly inappropriate e-mail to your boss. Lucky for you he swings that way. " +
				"Job security +5";
			myCompany.jobSecurity += 5;
			break;
		case 16:
			eventText = "You were sued by your bosses secretary. Your light flirting was obviously not as well " +
				"received as you had hoped. You settle out of court. Job security -10";
			myCompany.jobSecurity -= 10;
			break;
		case 17:
			eventText = "You came into work in the same clothes you wore yesterday. Someone noticed. Job security -1";
			myCompany.jobSecurity -= 1;
			break;
		case 18:
			eventText = "You go to a meeting with your boss to ask for a raise. You ask him to \"Show you the money\". " +
				"Job security -5";
			myCompany.jobSecurity -= 5;
			break;
		case 19:
			eventText = "Your mother calls your boss to complain about the long hours you work. She thoroughly " +
				"embarrasses you. Job security -5";
			myCompany.jobSecurity -= 5;
			break;
		case 20:
			eventText = "You give your boss a bottle of scotch and a pair of bunny slippers. Job security +5";
			myCompany.jobSecurity += 5;
			break;
		case 21:
			eventText = "You managed to sell excess paper on the black market. Budget +$500";
			myCompany.budget.monthlyAmount += 500;
			break;
		case 22:
			eventText = "Someone left a note under your apartment door saying \"I know where you live now\"";
			break;
		case 23:
			eventText = "An old woman berated you for cutting in line at the supermarket.";
			break;
		case 24:
			eventText = "You went to a baseball game and had a corndog, but you left your personal wallet in your" +
				"other pants. Thank God for the company credit card. Budget -$10";
			myCompany.budget.monthlyAmount -= 10;
			break;
		case 25:
			eventText = "You went on a date and spilled an ice cream cone on your shoes. " +
				"It didn't get better from there.";
			break;
		case 26:
			eventText = "Management installed a PA system in the office to keep the staff on their toes. " +
				"Staff morale -1";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			break;
		case 27:
			eventText = "Management installed a security camera in all the office bathrooms to discourage" +
				" unauthorized breaks. Staff morale -2";
			foreach(Character emp in myCompany.characters) {
				emp.morale -= 2;
			}
			break;
		case 28:
			eventText = "The boss paid a visit to your department to show off his Nazi memorabilia. " +
				"You played along. Staff morale -1";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			break;
		case 29:
			eventText = "You spent the weekend making plans to hike the Pacific Crest Trail. " +
				"Not even you believe you'll actually do it.";
			break;
		case 30:
			eventText = "You went to Las Vegas in a $20.000 car but came back in a " +
				"$200.000 Greyhound bus.";
			break;
		case 31:
			eventText = "You found out the staff has been calling you Mr. Toad behind your back. " +
				"Staff morale +1, Job security -3";
			foreach(Character emp in myCompany.characters) {
				emp.morale++;
			}
			myCompany.jobSecurity -= 3;
			break;
		case 32:
			eventText = "During an office party you try to impress your employees by performing an " +
				"improvised dance routine. You failed. Staff morale -1, Job security -3";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			myCompany.jobSecurity -= 3;
			break;
		case 33:
			eventText = "During a team building exercise you whipped out a guitar and broke into song. " +
				"It was not your finest hour. Staff morale -1, Job security -3";
			foreach(Character emp in myCompany.characters) {
				emp.morale--;
			}
			myCompany.jobSecurity -= 3;
			break;
		default:
			break;
		}
		return eventText;
	}
}
