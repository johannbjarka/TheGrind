using UnityEngine;
using System.Collections;

public class BalanceTutorial : MonoBehaviour {

	public GameObject BalancePanel;
	public GameObject MonthlySalaries;
	public GameObject TotalSalaries;
	public GameObject MiscCost;
	public GameObject ProjectIncome;
	public GameObject ProjectPenalty;
	public GameObject Funding;
	public GameObject Goal;
	public GameObject Profit;
	public GameObject computerPanel;
	public GameObject moneyPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void openBalancePanel() {
		moneyPanel.SetActive (false);
		BalancePanel.SetActive (true);
	}
	public void openTotalSalaries() {
		MonthlySalaries.SetActive (false);
		TotalSalaries.SetActive (true);
	}

	public void openMiscCost() {
		TotalSalaries.SetActive (false);
		MiscCost.SetActive (true);
	}

	public void openProjectIncome() {
		MiscCost.SetActive (false);
		ProjectIncome.SetActive (true);
	}

	public void openProjectPenalty() {
		ProjectIncome.SetActive (false);
		ProjectPenalty.SetActive (true);
	}

	public void openFunding() {
		ProjectPenalty.SetActive (false);
		Funding.SetActive (true);
	}

	public void openGoal() {
		Funding.SetActive (false);
		Goal.SetActive (true);
	}

	public void openProfit() {
		Goal.SetActive (false);
		Profit.SetActive (true);
	}

	public void endBalanceTutorial() {
		BalancePanel.SetActive (false);
		computerPanel.SetActive (true);
	}
}
