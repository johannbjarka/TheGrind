using UnityEngine;
using System.Collections;

public class RandomEvents : MonoBehaviour {

	void callEvent() {
		int randEvent = Random.Range(0, 10);
		string eventText;

		switch(randEvent){
		case 1:
			eventText = "You played golf with the CEO this weekend. " +
				"You kept it cool and lost on purpose. Next monthly allowance +100";
			break;
		case 2:
			eventText = "The boss invited you on a badass blimp ride. " +
				"You used company funds to foot the bill. Budget -250";
			break;
		case 3:
			eventText = "You met the person of your dreams. Flowers and real champagne" +
				" sure can be expensive. Budget -100";
			break;
		case 4:
			eventText = "The boss came in just before the office closed on Friday" +
				" and launched a drunken tirade at the staff. Staff morale -1";
			break;
		case 5:
			eventText = "Due to incessant requests, management ordered you to pay for " +
				"an in depth seminar on appropriate workplace communication. " +
				"Staff morale +1. Budget -100";
			break;
		case 6:
			eventText = "Your friends prank called your boss and left the impression that " +
				"you're a sexual deviant. Job security -10";
			break;
		case 7:
			eventText = "Your kid got into a fight at school. You left early to deal with " +
				"it. The boss came by while you were away. Job security -5";
			break;
		case 8:
			eventText = "The office security camera caught a hobo on tape breaking into " +
				"the office and doing his business in the flower pots. Cleanup was a priority. Budget -50";
			break;
		case 9:
			eventText = "The office was ransacked over the weekend. The thieves made off with " +
				"a stapler and three PCs. Budget -100";
			break;
		case 10:
			eventText = "You went with your boss to Las Vegas for a conference. He went to a strip joint " +
				"but you didn't want to partake. As punishment he used your departments budget to foot the bill. " +
				"Budget -150";
			break;
		case 11:
			eventText = "You went all in at the staff party on Friday. Your drunken advances " +
				"made everyone uncomfortable. Staff morale -1, Job security -5";
			break;
		case 12:
			eventText = "You decided to increase office morale by holding a screening of " +
				"\"Requiem For A Dream\". Staff morale -1";
			break;
		case 13:
			eventText = "You went to lunch with the top brass. Your jokes were unusually well " +
				"received. Job security +5";
			break;
		case 14:
			eventText = "You made an inappropriately left-leaning political comment at a board meeting. " +
				"Job security -5";
			break;
		case 15:
			eventText = "You forwarded a wildly inappropriate e-mail to your boss. Lucky for you he swings that way. " +
				"Job security +5";
			break;
		case 16:
			eventText = "You were sued by your bosses secretary. Your light flirting was obviously not as well " +
				"received as you had hoped. You settle out of court. Job security -10";
			break;
		case 17:
			eventText = "You came into work in the same clothes you wore yesterday. Someone noticed. Job security -1";
			break;
		case 18:
			eventText = "You go to a meeting with your boss to ask for a raise. You ask him to \"Show you the money\". " +
				"Job security -5";
			break;
		case 19:
			eventText = "Your mother calls your boss to complain about the long hours you work. She thoroughly " +
				"embarrasses you. Job security -5";
			break;
		case 20:
			eventText = "You give your boss ";
			break;
		default:
			break;
		}
	}
}
