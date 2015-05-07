using UnityEngine;
using System.Collections;

public class OpenBudget : MonoBehaviour {

	public Canvas budgetView;
	private bool isOpen = false;

	public void openBudget () {
		isOpen = !isOpen;
		budgetView.enabled = !budgetView.enabled;
	}
}
