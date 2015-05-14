using UnityEngine;
using System.Collections;

public class Month : MonoBehaviour {

	public int numberOfProjectsFinished = 0;
	public int totalQuality = 0;
	public char grade;

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
			myCompany.jobSecurity += balance / 200;
		}
		else{
			myCompany.jobSecurity += balance / 400;
		}
		return balance;
	}

	public void getGrade () {
		Company myCompany = gameObject.GetComponent<Company>();
		int ratio = 0;
		if(numberOfProjectsFinished > 0) {
			ratio = totalQuality / numberOfProjectsFinished;
		}
		if (ratio >= 9) {
			myCompany.jobSecurity += 8;
			grade = 'A';
		} else if (ratio == 8) {
			myCompany.jobSecurity += 4;
			grade = 'B';
		} else if (ratio == 7) {
			grade = 'C';
		} else if (ratio == 6) {
			myCompany.jobSecurity -= 4;
			grade = 'D';
		} else if (ratio == 5) {
			myCompany.jobSecurity -= 8;
			grade = 'E';
		} else {
			myCompany.jobSecurity -= 12;
			grade = 'F';
		}
	}
	
	public int getNextAllowance () {
		Company myCompany = gameObject.GetComponent<Company>();
		int oldAllowance = myCompany.budget.monthlyAmount;
		int newAllowance;
		switch (grade)
		{
		case 'A':
			newAllowance = oldAllowance + 1000;
			break;
		case 'B':
			newAllowance = oldAllowance + 500;
			break;
		case 'C':
			newAllowance = oldAllowance;
			break;
		case 'D':
			newAllowance = oldAllowance - 500;
			break;
		case 'E':
			newAllowance = oldAllowance - 1000;
			break;
		case 'F':
			newAllowance = oldAllowance - 1500;
			break;
		default:
			newAllowance = oldAllowance;
			break;
		}

		// Calls calcFinalBalance once to affect the job security
		if(calcFinalBalance() > 0) {
			newAllowance -= myCompany.budget.getBalance() / 2;
			if(newAllowance < 5000) {
				newAllowance = 5000;
			}
		}
		return newAllowance;
	}
}
