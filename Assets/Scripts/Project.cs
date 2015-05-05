using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project : MonoBehaviour {

	private string[] projectNames = {
		"Project Morpheus",
		"Help CSI hunt criminals",
		"Create a compression algorithm",
		"Cryschool"
	};
	
	private string[] projectDescriptions = {
		"Hack into the matrix to save Neo from certain death.",
		"Create a GUI interface using visual basic to track the criminals IP addresses.",
		"Gavin Belson the CEO of Hooli needs you to create the best compression algorithm " +
		"in the world so he can achieve his mission of destroying Pied Piper.",
		"A university in Iceland has a terrible intranet that needs replacing, make a new intranet for the school."
	};

	public int ID;
	private static int _ID = 0;
	public string name;
	public string description;
	public int deadline;
	public int workAmount;
	public int reward;
	public int penalty;
	public int category;
	public int expectedQuality;
	public bool isActive = false;
	public List<Character> employees;

	// Use this for initialization
	void Start () {
		createProject();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void createProject () {
		//employees = new List<Character>();
		deadline = Random.Range (1, 11);
		if (deadline < 3) {
			workAmount = Random.Range (5, 21);
		} else if (deadline < 6) {
			workAmount = Random.Range (20, 61);
		} else {
			workAmount = Random.Range (50, 101);
		}
		reward = Random.Range (workAmount - 5, workAmount + 6) * 10;
		penalty = Random.Range (100, 301);
		category = Random.Range (0, 13);
		expectedQuality = (int)((double)(deadline / workAmount) * Random.Range(200, 401));
		ID = _ID;
		_ID++;
	}

	char calcGrade () {
		int totalQuality = 0;
		foreach (Character emp in employees) {
			totalQuality += emp.skills[this.category] * emp.speed;
		}
		int quality = totalQuality / employees.Count;
		int ratio = (quality / this.expectedQuality) * 10;

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
