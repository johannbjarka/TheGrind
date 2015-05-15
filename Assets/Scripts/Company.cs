using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Company : MonoBehaviour {

	public GameObject employeePrefab;
	public GameObject projectPrefab;
	public Budget budget;
	public Month month;
	public int weeksPassed;
	public int jobSecurity = 75;
	public int maxEmployees = 20;
	public int selectedProject;
	// Currently active employees
	public List<Character> characters;
	public List<Character> applicants;
	// Currently active projects
	public List<Project> projects;
	public List<Project> availableProjects;
	public List<Project> completedProjects;
	public List<Sprite> chartables;
	public List<Sprite> originaltables;
	public List<GameObject> tables;
	public int[] tableFlowers;
	public int partialSalaries = 0;
	public Text weeks;
	public Text balance;
	public Text balance2;
	public Text salaries;
	public Text misc;
	public Text income;
	public Text penalties;
	public Text allocated;
	public Text projFinished;
	public Text monthBalance;
	public Text monthJobSecurity;
	public Text grade;
	public Text nextBudget;
	public Text jobSec;

	public Canvas EmployeePrefabCanvas;
	public Transform EmployeePrefabContentPanel;

	public int curNumberofEmps = 0;
	public Text totalEmployees;

	ClickSound click;

	public Dictionary<int, string> skills;

	public Canvas gotFiredCanvas;
	bool gotFiredCanvasIsOpen = false;

	public Canvas MenuCanvas;
	public Canvas ConfirmationCanvas;

	public RectTransform jobSecBar;

	public void IncrementEmployeeNumber() {
		curNumberofEmps++;
		totalEmployees.text = curNumberofEmps.ToString ();
	}

	public void DecrementEmployeeNumber() {
		curNumberofEmps--;
		totalEmployees.text = curNumberofEmps.ToString ();
	}

	void Awake () {
		// Create starting employees
		for(int i = 0; i < 5; i++) {
			GameObject character;
			Vector3 pos = new Vector3(- 8 + Random.value * 10, - 2 + Random.value * 5, 0);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			character.transform.SetParent(EmployeePrefabContentPanel);
			character.gameObject.transform.localScale = new Vector2(44,44);
			characters.Add(emp);
			IncrementEmployeeNumber();
		}
		
		// Create starting applicants
		for(int i = 0; i < 5; i++) {
			GameObject character;
			Vector3 pos = new Vector3(1000, 1000, -100f);
			character = Instantiate(employeePrefab, pos, Quaternion.identity) as GameObject;
			Character emp = character.GetComponent<Character>();
			applicants.Add(emp);

		}
	}
	// Use this for initialization
	void Start () {
		// Initialize budget
		budget = gameObject.AddComponent<Budget>() as Budget;
		budget.totalSalaries = 0;
		budget.miscCost = 2000;
		budget.projectRewards = 0;
		budget.projectPenalties = 0;
		budget.monthlyAmount = 15000;

		skills = new Dictionary<int, string>();
		skills[0] = "AI:";
		skills[1] = "Algorithms:";
		skills[2] = "Databases:";
		skills[3] = "Hacking:";
		skills[4] = "Networking:";
		skills[5] = "Web Dev:";

		for(int i = 0; i < 20; i++) {
			tableFlowers[i] = Random.Range(0,4);
		}

		for(int i = 0; i < 4; i++) {
			GameObject projectObj = Instantiate(projectPrefab) as GameObject;
			Project proj = projectObj.GetComponent<Project>();
			availableProjects.Add(proj);
		}

		// Initialize month
		month = gameObject.AddComponent<Month>() as Month;
		month.numberOfProjectsFinished = 0;
		month.totalQuality = 0;

		//Initialize weeks
		weeksPassed = 0;

		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) {
			openMenu();
		}

		budget.totalSalaries = getTotalSalaries();
		weeks.text = (weeksPassed + 1).ToString();
		if(budget.getBalance() < 0) {
			balance.color = Color.red;
			balance2.color = Color.red;
		}
		else {
			balance.color = Color.black;
			balance2.color = Color.black;
		}
		balance.text = "$" + budget.getBalance().ToString();
		balance2.text = "$" + budget.getBalance().ToString();
		salaries.text = "$" + budget.totalSalaries.ToString();
		misc.text = "$" + budget.miscCost.ToString();
		income.text = "$" + budget.projectRewards.ToString();
		if(budget.projectPenalties > 0) {
			penalties.color = Color.red;
		}
		else {
			penalties.color = Color.black;
		}
		penalties.text = "$" + budget.projectPenalties.ToString();
		allocated.text = "$" + budget.monthlyAmount.ToString();
		monthJobSecurity.text = jobSecurity.ToString();
		jobSec.text = jobSecurity.ToString();
		jobSecBar.sizeDelta = new Vector2 (jobSecurity * 2, 20);

		if(jobSecurity > 100){
			jobSecurity = 100;
		}
		else if(jobSecurity <= 0){
			jobSecurity = 0;
			firePlayer("Job security too low!");
		}
		for (int i = 0; i < characters.Count; i++) {
			if(characters[i].onProject)
			{
				tables[i].GetComponent<SpriteRenderer>().sprite = chartables[characters[i].rand*5 + tableFlowers[i]];
			}
			else{
				tables[i].GetComponent<SpriteRenderer>().sprite = originaltables[tableFlowers[i]];
			}
		}
	}

	public void openMenu () {
		click.playSound();
		MenuCanvas.enabled = !MenuCanvas.enabled;
	}

	public void openConfirmationPanel () {
		click.playSound();
		ConfirmationCanvas.enabled = !ConfirmationCanvas.enabled;
	}

	public void setTextFields (int monthBal) {
		projFinished.text = month.numberOfProjectsFinished.ToString();
		monthBalance.text = "$" + monthBal.ToString();
		grade.text = month.grade.ToString();
		nextBudget.text = "$" + budget.monthlyAmount.ToString();
	}

	int getTotalSalaries () {
		// 250 is the player characters salary
		int totalSalaries = 250;
		totalSalaries += partialSalaries;
		foreach(Character c in characters) {
			totalSalaries += c.salary;
		}
		return totalSalaries;
	}

	public void firePlayer(string reason){
		// Set the text.
		gotFiredCanvas.GetComponent<PlayerFiredPanel> ().explanation.text = reason;

		// Then show the canvas only if it is closed.
		if(!gotFiredCanvasIsOpen) {
			gotFiredCanvas.enabled = !gotFiredCanvas.enabled;
			gotFiredCanvasIsOpen = !gotFiredCanvasIsOpen;
		}
	}

	public string getDescription (int cat) {
		switch (cat) {
		case 0:
			return "AI";
		case 1:
			return "Algorithms";
		case 2:
			return "Databases";
		case 3:
			return "Hacking";
		case 4:
			return "Networking";
		case 5:
			return "Web Development";
		default:
			return "UNDEFINED CATEGORY";
		}
	}
}