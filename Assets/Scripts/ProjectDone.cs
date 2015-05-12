using UnityEngine;
using System.Collections;

public class ProjectDone : MonoBehaviour {

	public Canvas projectDone;
	private bool isOpen = false;
	
	public void openProjectDone () {
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
		isOpen = !isOpen;
		projectDone.enabled = !projectDone.enabled;
	}
}
