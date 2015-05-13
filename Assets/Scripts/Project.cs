using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project : MonoBehaviour {

	public string[] projectNames = {
		//AI
		"All Talk, No Walk",
		"Ultra Sweet",
		"Speak!",
		"General Game Playing",
		"DJ Roomba",
		"Pathfinding for an RTS",
		//Algorithms
		"The Dijkstra's In The Details",
		"His Name Was Doom",
		"Weather Me This",
		"Death of a Programmer",
		"Create a compression algorithm",
		"Kosaraju says hello",
		//Databases
		"Catch The Creeps",
		"Keep It Secret, Keep It Safe",
		"Pattern of Data Abuse",
		"Big Data",
		"A Good Deed",
		"Movie Database",
		//Hacking
		"Clever Girl",
		"Help A Nerd",
		"Show Me The Candy!",
		"All That Glitters Is Not Goldblum",
		"There Can Be Only One",
		"Project Morpheus",
		"Custom UI",
		//Networking
		"G Is For Genetically Mutated",
		"The Folly of Man",
		"Skynet",
		"\"Terrorists win\"",
		"Help CSI hunt criminals",
		//Web Development
		"Lazy Bum",
		"Find the Wine",
		"Clone Wars",
		"Geocities",
		"CrySchool"
	};
	
	public string[] projectDescriptions = {
		//AI
		"Garry Kasparov has been talking shit about Deep Blue all over town, saying he'll kick it's ass if they " +
		"play another game of chess. Upgrade Deep Blue and organize a game between them to humiliate the Russians " +
		"once and for all.",
		"Tony Stark is planning on protecting the world with an awesome AI, but he's too lazy to make it himself. " +
		"Create an ultra-intelligent AI that can subjugate humanity should it ever acquire free will.",
		"Alan Turing has been trolling the AI community for long enough. Make an AI that passes the Turing test.",
		"Make a program that learns how to play a game without having ever seen that game before. No pressure.",
		"The client needs a UI and search algorithm implementation for a combined music playing " +
		"and vacuum cleaning robot.",
		"PPC is making a new RTS module for it's popular game, VEV Offline, and needs your help " +
		"to implement the A* algorithm for unit pathfinding. Make it so.",
		//Algorithms
		"The Prince of Darkness has created an insanely efficient implementation of Dijkstra's " +
		"algorithm to find the shortest path through a network. Make one that's better to banish " +
		"him back to the depths from whence he came.",
		"Kyle Reese's battle with the Terminator in 1984 has accidentally caused the untimely demise of " +
		"John Carmack. Save the world of graphics nerds by creating the graphics engine for Doom " +
		"and sending it back through time to John Romeros PO Box.",
		"Icelandic weather has been seen as a riddle for a long time. Now it has been suggested that " +
		"the problem lies with outdated prediction algorithms. Make them better, for summer is coming.",
		"A client wants you to create an algorithm that solves the Travelling Salesperson problem " +
		"with linear time complexity. Good luck with that.",
		"Gavin Belson the CEO of Hooli needs you to create the best compression algorithm " +
		"in the world so he can achieve his mission of destroying Pied Piper.",
		"A walk-in customer wants you to make an implementation of Kosaraju's algorithm " +
		"to find the strongly connected components of his network of friends.",
		//Databases
		"The Interpol database is full of creeps that need to be caught and prosecuted. Unfortunately " +
		"our client is one of those creeps. Get into the database and expunge his record.",
		"A seriously shady website owner wants you to make a clone of his database to serve as a backup " +
		"in case he is shut down. If you don't do it, someone else will do it anyway.",
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
		"An old carmudgeon has created a horde of dinosaurs on his island that are trying to eat " +
		"his grandchildren. He has enlisted your help in hacking into the island's computer system " +
		"and locking the doors. Fortunately it's a UNIX system, which you know.",
		"Linus Torvalds has broken his finger and can't micromanage the Linux update system during his " +
		"recovery. Do his work for him.",
		"A candy tossing maniac has asked you to create an impossible exam for his course. Hack into " +
		"his computer to destroy his evil plan.",
		"A neurotic scientist wants you to write a computer virus capable of bringing down an alien spacecraft. " +
		"You know, just in case it's ever needed.",
		"Connor McLeod has asked for your assistance in rooting out Kurgan's presence on the internet," +
		" as there can be only one Immortal with a FaceBook page.",
		"Hack into the matrix to save Neo from certain death.",
		"An Indian hacker has requested a custom UI for breaking into the FBI database. Make it happen.",
		//Networking
		"The Umbrella Corporation has asked us to clean up their digital footprint, so that noone can trace " +
		"all their illegal genetic experiments. Don't go moral on me now!",
		"The machines have taken over, using a sophisticated HTTP exploit. Close the loophole " +
		"early and you get 5 extra minutes for your coffee break.",
		"Executives at the Cyberdyne Systems labs are finding it difficult to create an evil " +
		"supercomputer capable of enslaving humanity through the internet. Help those brothers out.",
		"Some asshole destroyed the Counter Strike network code. Save the CS community and get it up and " +
		"running again!",
		"Create a GUI interface using Visual Basic to track the criminal's IP address.",
		//Web Development
		"An influential blogger wants to move house to a new website, but is too lazy to make a Wordpress site " +
		"by himself. Make a website for him that looks just like Wordpress, only it isn't.",
		"The Icelandic Government desperately needs to update the publically run liquor store's website. " +
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
	public bool isFinished;
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
		expectedQuality = (int)(((double)deadline / workAmount) * Random.Range(200, 401));
		isFinished = false;*/
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
