using UnityEngine;
using System.Collections;

public class CalendarClick : MonoBehaviour {

	public Canvas calendarClickView;
	private bool isOpen = false;
	
	public void openCalendar () {
		isOpen = !isOpen;
		calendarClickView.enabled = !calendarClickView.enabled;
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
	}
}
