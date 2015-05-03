using UnityEngine;
using System.Collections;

public class Month : MonoBehaviour {
	
	public int numberOfProjectsFinished = 0;
	public int totalQuality = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int calcFinalBalance () {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int balance = myCompany.budget.getBalance();
		if(balance < 0){
			myCompany.player.jobSecurity -= balance / 20;
		}
		else{
			myCompany.player.jobSecurity += balance / 40;
		}
		return balance;
	}

	char getGrade () {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int ratio = totalQuality / numberOfProjectsFinished;
		if (ratio >= 9) {
			myCompany.player.jobSecurity += 4;
			return 'A';
		} else if (ratio == 8) {
			myCompany.player.jobSecurity += 2;
			return 'B';
		} else if (ratio == 7) {
			return 'C';
		} else if (ratio == 6) {
			myCompany.player.jobSecurity -= 2;
			return 'D';
		} else if (ratio == 5) {
			myCompany.player.jobSecurity -= 4;
			return 'E';
		} else {
			myCompany.player.jobSecurity -= 6;
			return 'F';
		}
	}

	int getNextAllowance () {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		int oldAllowance = myCompany.budget.monthlyAmount;
		int newAllowance;
		char grade = getGrade();
		switch (grade)
		{
		case 'A':
			newAllowance = oldAllowance + 100;
			break;
		case 'B':
			newAllowance = oldAllowance + 50;
			break;
		case 'C':
			newAllowance = oldAllowance;
			break;
		case 'D':
			newAllowance = oldAllowance - 50;
			break;
		case 'E':
			newAllowance = oldAllowance - 100;
			break;
		case 'F':
			newAllowance = oldAllowance - 150;
			break;
		default:
			newAllowance = oldAllowance;
			break;
		}
		if(calcFinalBalance() > 0) {
			newAllowance -= calcFinalBalance() / 2;
		}
		return newAllowance;
	}
}
