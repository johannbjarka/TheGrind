using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project : MonoBehaviour {

	public string[] projectNames = {
		"Project Morpheus",
		"Help CSI hunt criminals",
		"Create a compression algorithm",
		"Cryschool"
	};
	
	public string[] projectDescriptions = {
		"Hack into the matrix to save Neo from certain death.",
		"Create a GUI interface using Visual Basic to track the criminal's IP address.",
		"Gavin Belson the CEO of Hooli needs you to create the best compression algorithm " +
		"in the world so he can achieve his mission of destroying Pied Piper.",
		"A university in Iceland has a terrible intranet that needs replacing, make a new intranet for the school."
	};

	public int ID;
	private static int _ID = 0;
	public string projName;
	public string description;
	public int deadline;
	public int workAmount;
	public int reward;
	public int penalty;
	public int category;
	public int expectedQuality;
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
		/*int rand = Random.Range(0, projectNames.Length);
		projName = projectNames[rand];
		description = projectDescriptions[rand];
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
		expectedQuality = (int)(((double)deadline / workAmount) * Random.Range(200, 401));*/
		ID = _ID;
		_ID++;
	}

	public char calcGrade () {
		int totalQuality = 0;
		foreach (Character emp in employees) {
			totalQuality += (int)(emp.skills[this.category] * ((double)emp.speed / 2));
		}
		int quality = totalQuality / employees.Count;
		int ratio = (int)(((double)quality / this.expectedQuality) * 10);

		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.month.totalQuality += ratio;
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
