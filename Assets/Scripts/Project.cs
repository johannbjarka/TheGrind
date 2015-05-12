using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project : MonoBehaviour {

	public string[] projectNames = {
		//AI
		"General Game Playing",
		"DJ Roomba",
		"Pathfinding for an RTS",
		//Algorithms
		"Weather Me This",
		"Death of a Programmer",
		"Create a compression algorithm",
		"Kosaraju says hello",
		//Databases
		"Pattern of Data Abuse",
		"Big Data",
		"A Good Deed",
		"Movie Database",
		//Hacking
		"All That Glitters Is Not Goldblum",
		"There Can Be Only One",
		"Project Morpheus",
		"Custom UI",
		//Networking
		"The Folly of Man",
		"Skynet",
		"\"Terrorists win\"",
		"Help CSI hunt criminals",
		//Web Development
		"Find the Wine",
		"Clone Wars",
		"Geocities",
		"CrySchool"
	};
	
	public string[] projectDescriptions = {
		//AI
		"Make a program that learns how to play a game without having ever seen that game before. No pressure.",
		"The client needs a UI and search algorithm implementation for a combined music playing " +
		"and vacuum cleaning robot.",
		"PPC is making a new RTS module for it's popular game, VEV Offline, and needs your help " +
		"to implement the A* algorithm for unit pathfinding. Make it so.",
		//Algorithms
		"Icelandic weather has been seen as a riddle for a long time. Now it has been suggested that " +
		"the problem lies with outdated prediction algorithms. Make them better, for summer is coming.",
		"A client wants you to create an algorithm that solves the Travelling Salesperson problem " +
		"with linear time complexity. Good luck with that.",
		"Gavin Belson the CEO of Hooli needs you to create the best compression algorithm " +
		"in the world so he can achieve his mission of destroying Pied Piper.",
		"A walk-in customer wants you to make an implementation of Kosaraju's algorithm " +
		"to find the strongly connected components of his network of friends.",
		//Databases
		"A social networking site has been found guilty by the court of the streets of taking peoples " +
		"freely given information and using it to make money. Use your database exploit skills to destroy all " +
		"the data.",
		"Donald Trump wants you to make the biggest database in the world, most probably to compensate for " +
		"something.",
		"A good samaritan wants you to hack into the DEA databases to make them BCNF compliant. " +
		"For the good of our country, do not fail.",
		"The International Federation of Moviemakers wants you to make a movie database. " +
		"It has to be BCNF compliant.",
		//Hacking
		"A neurotic scientist wants you to write a computer virus capable of bringing down an alien spacecraft. " +
		"You know, just in case it's ever needed.",
		"Connor McLeod has asked for your assistance in rooting out Kurgan's presence on the internet," +
		" as there can be only one Immortal with a FaceBook page.",
		"Hack into the matrix to save Neo from certain death.",
		"An Indian hacker has requested a custom UI for breaking into the FBI database. Make it happen.",
		//Networking
		"The machines have taken over, using a sophisticated HTTP exploit. Close the loophole " +
		"early and you get 5 extra minutes for your coffee break.",
		"Executives at the Cyberdyne Systems labs are finding it difficult to create an evil " +
		"supercomputer capable of enslaving humanity through the internet. Help those brothers out.",
		"Some asshole destroyed the Counter Strike network code. Save the CS community and get it up and " +
		"running again!",
		"Create a GUI interface using Visual Basic to track the criminal's IP address.",
		//Web Development
		"The Icelandic Government desperatelyneeds to update the publically run liquor store's website. " +
		"The site's search bar is quite awful, and you need to fix it. This is super serial.",
		"A venture capitalist douche wants you to make a clone of Candy Crush, cause, you know, money. " +
		"You don't have to like it.",
		"The Geocities website hosting service is having trouble with it's terrible default look. Make it more bearable.",
		"A university in Iceland has a terrible intranet that needs replacing, make a new intranet for the school."
	};

	public int ID;
	private static int _ID = 0;
	public string projName;
	public string description;
	public int deadline;
	public int workAmount;
	public int initialWorkAmount;
	public int workEstimate;
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
		initialWorkAmount = workAmount;
		reward = Random.Range (workAmount - 5, workAmount + 6) * 10;
		penalty = Random.Range (100, 301);
		category = Random.Range (0, 13);
		expectedQuality = (int)(((double)deadline / workAmount) * Random.Range(200, 401));*/
		workEstimate = 0;
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
