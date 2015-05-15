using UnityEngine;
using System.Collections;

public class Budget : MonoBehaviour {

	public int totalSalaries;
	public int totalTotalSalaries;
	public int miscCost;
	public int projectRewards;
	public int projectPenalties;
	public int monthlyAmount;
	public int totalFunding;
	public int goal;
	public int monthlyGoal;
	public int lastBalance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getBalance () {
		return (totalFunding + projectRewards - totalSalaries - totalTotalSalaries - miscCost - projectPenalties);
	}

	public int getOldBalance() {
		return (monthlyAmount + projectRewards - totalSalaries - miscCost - projectPenalties);
	}
}
