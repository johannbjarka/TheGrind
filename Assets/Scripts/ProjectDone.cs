using UnityEngine;
using System.Collections;

public class ProjectDone : MonoBehaviour {

	public Canvas projectDone;
	private bool isOpen = false;
	
	public void openProjectDone () {
		isOpen = !isOpen;
		projectDone.enabled = !projectDone.enabled;
	}
}
