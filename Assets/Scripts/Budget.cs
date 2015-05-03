using UnityEngine;
using System.Collections;

public class Budget : MonoBehaviour {

	public int totalSalaries;
	public int miscCost;
	public int projectRewards;
	public int projectPenalties;
	public int monthlyAmount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getBalance () {
		return (monthlyAmount + projectRewards - totalSalaries - miscCost - projectPenalties);
	}
}
