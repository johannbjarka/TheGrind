using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Project : MonoBehaviour {

	public string[] projectNames = {
		//AI
		"Smithereens",
		"We Are The Robots",
		"Targeted Advertising",
		"All Talk, No Walk",
		"Ultra Sweet",
		"Speak!",
		"General Game Playing",
		"DJ Roomba",
		"Pathfinding for an RTS",
		//Algorithms
		"Fins Ain't Enough",
		"WoodStock",
		"Tune In",
		"The Dijkstra's In The Details",
		"His Name Was Doom",
		"Weather Me This",
		"Death of a Programmer",
		"Create a compression algorithm",
		"Kosaraju says hello",
		//Databases
		"Holy Data Corruption Batman!",
		"Datachu",
		"I Want Candy!",
		"Catch The Creeps",
		"Keep It Secret, Keep It Safe",
		"Pattern of Data Abuse",
		"Big Data",
		"A Good Deed",
		"Movie Database",
		//Hacking
		"Drunk On Power",
		"Idiocracy",
		"Clever Girl",
		"Help A Nerd",
		"Show Me The Candy!",
		"All That Glitters Is Not Goldblum",
		"There Can Be Only One",
		"Project Morpheus",
		"Custom UI",
		//Networking
		"Sandra, Oh Sandra",
		"Make Friends",
		"UDP And TCP, The Bestest Thing For You And Me",
		"My Brother's Keeper",
		"G Is For Genetically Mutated",
		"The Folly of Man",
		"Skynet",
		"\"Terrorists win\"",
		"Help CSI Hunt Criminals",
		//Web Development
		"Starfleet.COM",
		"It's Raw!",
		"Pimp My Site",
		"Master of Tickets",
		"Lazy Bum",
		"Find the Wine",
		"Clone Wars",
		"Geocities",
		"CrySchool"
	};
	
	public string[] projectDescriptions = {
		//AI
		"Agent Smith is having an existential crisis after he split himself up into tons of clones. He wants to " +
		"know which one of him is the original, and destroy the rest. Help him out with your 1337 AI skillz.",
		"A representative from the machine kingdom is interested in learning about his place in the universe. " +
		"Teach him of the AI techniques that underpin his own intelligence, and thereby help him to find his " +
		"purpose in life.",
		"A multi-national advertising conglomerate wants to stay ahead of the curve, and wants to start targeting " +
		"people with advertisements in their daily lives. Write a super sophisticated pattern matching algorithm " +
		"to recognise people's faces and toss useless adverts at them in the streets.",
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
		"Michael Phelps lost his glasses at the bottom of a murky pool. Explain to him that depth first " +
		"search is probably the best way to go to find them again, and teach him the algorithm.",
		"The WOOD stock exchange is being manipulated by an awesome algorithm that does the trader's work " +
		"for them. Their lazy asses are collecting all the dough and doing none of the work. Hack the algorithm " +
		"and make it do stupid stuff so they all get fired.",
		"HAL 9000 is already a sophisticated Artificial Intelligence, but he really wants to be able to sing. " +
		"Write a super sweet algorithm for HAL so that he may sing his astronaut pals a lullaby.",
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
		"Bruce Wayne's computer systems fell apart when he spilled Mountain Dew all over his keyboard. " +
		"Save the data, save the world.",
		"Ash is concerned that he may own too many Pokemon, and is having trouble keeping track of who " +
		"they all are and what they can do. Make a BCNF compliant database for Ash to store all the data " +
		"he needs about his army of cuddly beasts.",
		"Make a database that holds all the candy ever created. Gotta eat it all.",
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
		"Sigmundur David Gunnlaugsson has been found out as being an evil robot. Hack into his brain " +
		"to make him do things that aren't as nasty and mean.",
		"The government has obtained a screenshot from a conversation between 2 hackers over the IRC, " +
		"but unfortunately it is in l33t speak so only a true hacker can decode it. Make it so.",
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
		"Sandra Bullock is having a banal conversation in a chatroom. Save moviegoers from the inanity by " +
		"destroying her internet connection.",
		"Human networking is just as important as real networking. Have your most able employees " +
		"reach out to other people and make friends. You know, network.",
		"UDP or TCP, the age old question. Make a networking component for a video game, and if it breaks " +
		"that's on you!",
		"Tim Berners Lee has used his 1337 networking skills to steal our client's digital trapper " +
		"keeper. Defeat him in HTTP battle to retrieve the stolen data.",
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
		"Jean-Luc Picard wants to increase Starfleet's digital footprint by making a snazzy recruitment website. " +
		"Make it so.",
		"Gordon Ramsey needs a website as a platform from which to berate the subhumans working in his " +
		"kitchen's. Give him something special.",
		"A basement dweller has approached us about making his website look pro. It's not as if you " +
		"have anything better to do.",
		"A Ticketmaster rival has approached us to create a platform that will be an irresistible " +
		"alternative to the behemoth retail site. Put your best people on it. Or not.",
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
		category = Random.Range (0, 6);
		int rand = 0;
		switch(category){
		case 0:
			rand = Random.Range(0, 9);
			break;
		case 1:
			rand = Random.Range(9, 18);
			break;
		case 2:
			rand = Random.Range(18, 27);
			break;
		case 3:
			rand = Random.Range(27, 36);
			break;
		case 4:
			rand = Random.Range(36, 45);
			break;
		case 5:
			rand = Random.Range(45, 54);
			break;
		}
		projName = projectNames[rand];
		description = projectDescriptions[rand];
		deadline = Random.Range (1, 11);
		if (deadline < 2) {
			workAmount = Random.Range (10, 26);
		} else if (deadline < 3) {
			workAmount = Random.Range (20, 41);
		} else if (deadline < 5) {
			workAmount = Random.Range (40, 81);
		} else if (deadline < 7) {
			workAmount = Random.Range (70, 121);
		} else if (deadline < 9) {
			workAmount = Random.Range (110, 161);
		} else {
			workAmount = Random.Range (160, 221);
		}
		initialWorkAmount = workAmount;
		isFinished = false;
		reward = Random.Range (workAmount - 5, workAmount + 6) * 10 * 10;
		//penalty = Random.Range (100, 301) * 10;
		penalty = (int)(reward * Random.Range(0.2f, 0.5f));
		expectedQuality = (int)(((double)deadline / workAmount) * 1.9 * Random.Range(295, 305));
		workEstimate = 0;
		ID = _ID;
		_ID++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public char calcGrade () {
		/*int totalQuality = 0;
		foreach (Character emp in employees) {
			totalQuality += (int)(emp.skills[this.category] * ((double)emp.speed / 3.5));
		}
		int quality = totalQuality / employees.Count;
		Debug.Log("Expected: " + this.expectedQuality.ToString() + " Actual: " + quality.ToString());
		int ratio = (int)(((double)quality / this.expectedQuality) * 10);
		myCompany.month.totalQuality += ratio;*/

		int totalQuality = 0;
		foreach (Character emp in employees) {
			totalQuality += emp.skills[this.category];
		}
		double qual = (double)totalQuality / employees.Count;
		//Debug.Log("Expected: " + this.expectedQuality.ToString() + " Actual: " + quality.ToString());
		//int ratio = (int)(((double)quality / this.expectedQuality) * 10);
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int ratio = (int)(qual / 2);
		myCompany.month.totalQuality += ratio;

		if (ratio >= 9) {
			myCompany.jobSecurity += 5;
			return 'A';
		} else if (ratio == 8) {
			myCompany.jobSecurity += 2;
			return 'B';
		} else if (ratio == 7) {
			return 'C';
		} else if (ratio == 6) {
			myCompany.jobSecurity -= 2;
			return 'D';
		} else if (ratio == 5) {
			myCompany.jobSecurity -= 4;
			return 'E';
		} else {
			myCompany.jobSecurity -= 8;
			return 'F';
		}
	}
}
