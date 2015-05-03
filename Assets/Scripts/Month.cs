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
		//TODO implement functionality
		int ratio = totalQuality / numberOfProjectsFinished;
		if (ratio >= 9) {
			return 'A';
		} else if (ratio == 8) {
			return 'B';
		} else if (ratio == 7) {
			return 'C';
		} else if (ratio == 6) {
			return 'D';
		} else if (ratio == 5) {
			return 'E';
		} else {
			return 'F';
		}
	}

	int nextAllowance () {
		//TODO implement functionality
		return 0;
	}
}
