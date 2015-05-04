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

	public int calcFinalBalance () {
		Company myCompany = gameObject.GetComponent<Company>();
		int balance = myCompany.budget.getBalance();
		if(balance < 0){
			myCompany.jobSecurity -= balance / 20;
		}
		else{
			myCompany.jobSecurity += balance / 40;
		}
		return balance;
	}

	public char getGrade () {
		Company myCompany = gameObject.GetComponent<Company>();
		int ratio = totalQuality / numberOfProjectsFinished;
		if (ratio >= 9) {
			myCompany.jobSecurity += 8;
			return 'A';
		} else if (ratio == 8) {
			myCompany.jobSecurity += 4;
			return 'B';
		} else if (ratio == 7) {
			return 'C';
		} else if (ratio == 6) {
			myCompany.jobSecurity -= 4;
			return 'D';
		} else if (ratio == 5) {
			myCompany.jobSecurity -= 8;
			return 'E';
		} else {
			myCompany.jobSecurity -= 12;
			return 'F';
		}
	}

	public int getNextAllowance () {
		Company myCompany = gameObject.GetComponent<Company>();
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
