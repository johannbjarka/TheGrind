using UnityEngine;
using System.Collections;

public class MonthlyReview : MonoBehaviour {

	public Canvas monthlyReview;
	private bool isOpen = false;
	
	public void openMonthlyReview () {
		isOpen = !isOpen;
		monthlyReview.enabled = !monthlyReview.enabled;
	}
}
