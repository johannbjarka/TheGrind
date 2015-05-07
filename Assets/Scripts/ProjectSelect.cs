using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ProjectSelect : MonoBehaviour {

	public void selectProject(Text _id){
		int id = Int32.Parse(_id.text);
		Company myCompany = GameObject.Find ("Company").GetComponent<Company>();
		foreach(Project proj in myCompany.availableProjects){
			if(proj.ID == id){
				myCompany.projects.Add(proj);
				myCompany.availableProjects.Remove(proj);
				break;
			}
		}
		//TODO: Take player to menu to select employees for project
		CreateScrollList list = GameObject.Find("Main Camera").GetComponent<CreateScrollList>();
		list.PopulateAvailableEmployeeList(id);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
