using UnityEngine;
using System.Collections;
using System;

public class AddToProject : MonoBehaviour {

	public void addEmployee(IDPair ids){
		Debug.Log("YOLO");
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		//Project proj2 = ;
		Debug.Log (ids.projectID.text);
		Debug.Log (ids.employeeID.text);
		int projectID = Int32.Parse(ids.projectID.text);
		int employeeID = Int32.Parse(ids.employeeID.text);
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				foreach(Character emp in myCompany.characters){
					if(emp.ID == employeeID){
						emp.onProject = true;
						proj.employees.Add(emp);
						break;
					}
				}
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
