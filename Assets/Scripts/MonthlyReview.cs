using UnityEngine;
using System.Collections;

public class MonthlyReview : MonoBehaviour {

	public Canvas monthlyReview;
	private bool isOpen = false;
	
	public void openMonthlyReview () {
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
		isOpen = !isOpen;
		monthlyReview.enabled = !monthlyReview.enabled;
	}
}
