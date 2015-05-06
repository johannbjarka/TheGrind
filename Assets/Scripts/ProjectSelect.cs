using UnityEngine;
using System.Collections;

public class ProjectSelect : MonoBehaviour {

	public void selectProject(int id){
		Company myCompany = GameObject.Find ("Company").GetComponent<Company>();
		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == id){
				myCompany.projects.Add(proj);
				myCompany.availableProjects.Remove(proj);
			}
		}
		//TODO: Take player to menu to select employees for project
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
