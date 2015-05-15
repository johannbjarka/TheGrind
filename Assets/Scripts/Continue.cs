using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

	private string[] reason = {
		"steals some office equipment on the way out.",
		"drops trou' and moons you.",
		"tells you to say goodbye to these.",
		"tells you exactly what you are.",
		"thanks you for not being like all the others.",
		"is going back to school.",
		"wants to travel and concentrate on music.",
		"didn't like the office's boys club mentality.",
		"quit because of your terrible management skills.",
		"felt the office was a hostile environment."
	};
	public GameObject projectPrefab;
	public GameObject employeePrefab;
	public int newBudget;
	public Canvas performanceReview;
	Company myCompany;
	public Text eventText;
	public Canvas eventCanvas;

	public GameObject projectFinishedPanel;
	public Transform projectFinishedContentPanel;

	public GameObject employeeQuitsPanel;
	public Transform employeeQuitsContentPanel;
	public Canvas EmployeeCanvas;
	public Canvas ApplicantCanvas;
	public Canvas ComputerCanvas;
	public Canvas ProjectCanvas;
	public Canvas CurProjectCanvas;
	public Canvas skillsMenuCanvas;
	public Canvas SelectEmployeesCanvas;
	public Canvas SelectInitialEmployeeCanvas;
	public Canvas BudgetCanvas;
	public Canvas GotFiredCanvas;
	public Canvas PerformanceReviewCanvas;
	public Canvas ProjectFinishedCanvas;
	public Canvas TooManyCanvas;
	ClickSound click;

	void Start() {
		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
	}

	public void closeEverything() {
		EmployeeCanvas.enabled = false;
		ApplicantCanvas.enabled = false;
		ComputerCanvas.enabled = false;
		ProjectCanvas.enabled = false;
		CurProjectCanvas.enabled = false;
		skillsMenuCanvas.enabled = false;
		SelectEmployeesCanvas.enabled = false;
		SelectInitialEmployeeCanvas.enabled = false;
		BudgetCanvas.enabled = false;
		GotFiredCanvas.enabled = false;
		PerformanceReviewCanvas.enabled = false;
		ProjectFinishedCanvas.enabled = false;
		TooManyCanvas.enabled = false;
	}
	public void continueGame () {
		click.playSound();
		closeEverything ();


		myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.weeksPassed++;

		for(int i = 0; i < 20; i++) {
			myCompany.tableFlowers[i] = Random.Range(0,4);
		}
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
			// If the project is finished, add it to completed projects, add the 
			// reward to the budget and remove it from projects.
			if(myCompany.projects[i].workAmount <= 0) {
				if(!myCompany.projects[i].isFinished) {
					myCompany.completedProjects.Add(myCompany.projects[i]);
					myCompany.budget.projectRewards += myCompany.projects[i].reward;
					myCompany.month.numberOfProjectsFinished++;
					GameObject newPanel = Instantiate (projectFinishedPanel) as GameObject;
					ProjectFinishPanel panel = newPanel.GetComponent<ProjectFinishPanel>();
					panel.projName.text = myCompany.projects[i].projName;
					panel.rewPen.text = "Reward for project:";
					panel.rewPenAmount.text = "$" + myCompany.projects[i].reward.ToString();
					panel.grade.text = myCompany.projects[i].calcGrade().ToString();
					panel.isProjDone.text = "Good job! You finished the project in time.";
					newPanel.transform.SetParent (projectFinishedContentPanel);
					panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
					panel.transform.position = new Vector3(0, 3.5f, 0);
					// Remove employees from the project
					foreach(Character emp in myCompany.projects[i].employees) {
						emp.onProject = false;
						emp.transform.position = new Vector3(-8 + Random.value * 10, -2 + Random.value * 5, 0);
					}
					myCompany.projects[i].isFinished = true;
				}
			}

			// If a project's deadline has passed and it's not finished we 
			// remove it from projects and add the penalty to projectPenalties. 
			if(myCompany.projects[i].deadline <= 0 && myCompany.projects[i].workAmount > 0) {
				if(!myCompany.projects[i].isFinished) {
					myCompany.budget.projectPenalties += myCompany.projects[i].penalty;
					myCompany.jobSecurity -= 5;
					GameObject newPanel = Instantiate (projectFinishedPanel) as GameObject;
					ProjectFinishPanel panel = newPanel.GetComponent<ProjectFinishPanel>();
					panel.projName.text = myCompany.projects[i].projName;
					panel.rewPen.text = "Penalty for project";
					panel.rewPenAmount.text = myCompany.projects[i].penalty.ToString();
					panel.grade.text = "-";
					panel.isProjDone.text = "Oh no! You didn't finish in time. The project needed more employees.";
					newPanel.transform.SetParent (projectFinishedContentPanel);
					panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
					panel.transform.position = new Vector3(0, 3.5f, 0);
					// Remove employees from the project
					foreach(Character emp in myCompany.projects[i].employees) {
						emp.onProject = false;
						emp.transform.position = new Vector3(-8+Random.value*10, -2+Random.value*5, 0);
					}
					myCompany.projects[i].isFinished = true;
				}
			}
		}

		for(int i = 0; i < myCompany.projects.Count; i++) {
			if((myCompany.projects[i].workAmount <= 0) || 
			   (myCompany.projects[i].deadline == 0)) {
				
				myCompany.projects.Remove(myCompany.projects[i]);
			}
		}

		foreach(Project proj in myCompany.availableProjects) {
			if(proj.deadline <= 0) {
				proj.isFinished = true;
			}
		}

		for(int i = 0; i < myCompany.availableProjects.Count; i++) {
			if(myCompany.availableProjects[i].isFinished) {
				myCompany.availableProjects.Remove(myCompany.availableProjects[i]);
			}
		}

		// If a month has passed
		if((myCompany.weeksPassed % 4) == 0) {
			MonthlyReview monthly = GameObject.Find("Monthly").GetComponent<MonthlyReview>();
			int monthlyBalance = myCompany.budget.getBalance();
			myCompany.month.getGrade();
			myCompany.budget.monthlyAmount = myCompany.month.getNextAllowance();
			myCompany.setPercentageText();
			myCompany.getNextGoal();
			myCompany.budget.lastBalance = myCompany.budget.getBalance();
			myCompany.budget.totalFunding += myCompany.budget.monthlyAmount;
			myCompany.budget.totalTotalSalaries += myCompany.budget.totalSalaries;
			myCompany.setTextFields(monthlyBalance);

			if(myCompany.month.numberOfProjectsFinished == 0){
				//TODO; notify player?
				myCompany.jobSecurity -= 10;
			}

			if(myCompany.characters.Count == 0){
				myCompany.firePlayer("You do not have any employees, you can't do this all by yourself! You're FIRED!");
			}
			else {
				monthly.openMonthlyReview();
			}
			myCompany.month.numberOfProjectsFinished = 0;
			myCompany.month.totalQuality = 0;
			/*myCompany.budget.totalFunding += myCompany.budget.monthlyAmount;
			myCompany.budget.totalTotalSalaries += myCompany.budget.totalSalaries;*/
			//myCompany.budget.projectRewards = 0;
			//myCompany.budget.projectPenalties = 0;
			myCompany.partialSalaries = 0;
		}

		//Random event
		int ranEvent = Random.Range(1, 5);
		if(ranEvent == 1) {
			eventText.text = callEvent();
		}

		//Add new Projects to Available Projects 0-1 each week
		int numProjects = Random.Range(0, 3);

		for(int i = 0; i < numProjects; i++) {
			GameObject projectObj = Instantiate(projectPrefab) as GameObject;
			Project proj = projectObj.GetComponent<Project>();
			myCompany.availableProjects.Add(proj);
		}

		//Add new Applicants, Remove old Applicants, 0-2 in 0-2 out.

		int numApplIn = Random.Range(0, 4);
		
		for(int i = 0; i < numApplIn; i++) {
			Vector3 pos = new Vector3(1000, 1000, -100f);
			GameObject characterObj = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character newChar = characterObj.GetComponent<Character>();
			myCompany.applicants.Add(newChar);
		}

		if(myCompany.applicants.Count > 1) {
			int numApplOut = Random.Range(0, 2);
			for(int i = 0; i < numApplOut; i++) {
				myCompany.applicants.Remove(myCompany.applicants[0]);
			}
		}

		// Employees quit if their morale reaches 0
		for(int i = 0; i < myCompany.characters.Count; i++) {
			if(myCompany.characters[i].morale <= 0 && !myCompany.characters[i].hasQuit) {
				GameObject newPanel = Instantiate(employeeQuitsPanel) as GameObject;
				EmployeeQuitsPanel panel = newPanel.GetComponent<EmployeeQuitsPanel>();
				panel.hasQuit.text = myCompany.characters[i].characterName + " has quit!";
				if(myCompany.characters[i].gender == 'M') {
					panel.detailedQuit.text = "He " + reason[Random.Range(0, reason.Length)];
				}
				else {
					panel.detailedQuit.text = "She " + reason[Random.Range(0, reason.Length)];
				}
				panel.quitImage.sprite = myCompany.characters[i].sprite;
	
				newPanel.transform.SetParent (employeeQuitsContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				panel.transform.position = new Vector3(0, -2f, 0);

				myCompany.characters[i].hasQuit = true;
				// Remove employee from project if he was on one
				foreach(Project proj in myCompany.projects){
					foreach(Character emp in proj.employees){
						if(emp.ID == myCompany.characters[i].ID){
							proj.workEstimate -= emp.speed * proj.deadline;
							proj.employees.Remove(emp);
							break;
						}
					}
					break;
				}
				// Calculate partial salary and remove from the company
				myCompany.partialSalaries += (int)(myCompany.characters[i].salary * ((myCompany.weeksPassed % 4) / 4.0));
				myCompany.characters[i].gameObject.transform.position = new Vector3(-1000, -1000, 0);
			}
		}
		for(int i = 0; i < myCompany.characters.Count; i++) {
			if(myCompany.characters[i].morale <= 0) {
				myCompany.characters.Remove(myCompany.characters[i]);
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

	public void closeEventCanvas () {
		eventCanvas.enabled = !eventCanvas.enabled;
	}

	string callEvent() {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		int randEvent = Random.Range(1, 34);
		string eventText = "";
		eventCanvas.enabled = !eventCanvas.enabled;
		
		switch(randEvent){
		case 1:
			eventText = "You played golf with the CEO this weekend. " +
				"You kept it cool and lost on purpose. Funding +$1000";
			myCompany.budget.monthlyAmount += 1000;
			break;
		case 2:
			eventText = "The boss invited you on a badass blimp ride. " +
				"You used company funds to foot the bill. Miscellaneous cost +$2500";
			myCompany.budget.miscCost += 2500;
			break;
		case 3:
			eventText = "You met the person of your dreams. Flowers and real champagne" +
				" sure can be expensive. Miscellaneous cost +$1000";
			myCompany.budget.miscCost += 1000;
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
					"Staff morale +1. Miscellaneous cost +$1000";
			foreach(Character emp in myCompany.characters) {
				emp.morale++;
			}
			myCompany.budget.miscCost += 1000;
			break;
		case 6:
			eventText = "Your friends prank called your boss and left the impression that " +
				"you're a sexual deviant. Job security -5";
			myCompany.jobSecurity -= 5;
			break;
		case 7:
			eventText = "Your kid got into a fight at school. You left early to cheer her " +
				"on. The boss came by while you were away. Job security -5";
			myCompany.jobSecurity -= 5;
			break;
		case 8:
			eventText = "The office security camera caught a hobo on tape breaking into " +
				"the office and doing his business in the flower pots. Cleanup was a priority. Miscellaneous cost +$500";
			myCompany.budget.miscCost += 500;
			break;
		case 9:
			eventText = "The office was ransacked over the weekend. The thieves made off with " +
				"a red Swingline stapler and three PCs. Miscellaneous cost +$1000";
			myCompany.budget.miscCost += 1000;
			break;
		case 10:
			eventText = "You went with your boss to Las Vegas for a conference. He went to a strip joint " +
				"but you didn't want to partake. As punishment he used your departments budget to foot the bill. " +
					"Miscellaneous cost +$1500";
			myCompany.budget.miscCost += 1500;
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
			eventText = "You managed to sell excess paper on the black market. Funding +$500";
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
				" other pants. Thank God for the company credit card. Miscellaneous cost +$10";
			myCompany.budget.miscCost += 10;
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
				"improvised dance routine. You fail. Staff morale -1, Job security -3";
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

	public void destroyPanel () {
		click.playSound();
		Destroy(projectFinishedPanel);
	}

	public void destroyQuitPanel () {
		click.playSound();
		Destroy(employeeQuitsPanel);
	}
}
