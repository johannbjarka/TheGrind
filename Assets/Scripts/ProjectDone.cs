using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProjectDone : MonoBehaviour {

	public Canvas projectDone;

	void Update () {
		// Hacky way to check if canvas has child elements
		ProjectFinishPanel[] projs =  projectDone.GetComponentsInChildren<ProjectFinishPanel>();
		if(projs.Length == 0) {
			projectDone.enabled = false;
		}
		else {
			projectDone.enabled = true;
		}
	}
}
