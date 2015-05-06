using UnityEngine;
using System.Collections;

public class AddToProject : MonoBehaviour {

	public void addEmployee(int projectID, int employeeID){
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		Project proj2 = new Project();
		foreach(Project proj in myCompany.projects){
			if(proj.ID == projectID){
				proj2 = proj;
				break;
			}
		}
		foreach(Character emp in myCompany.characters){
			if(emp.ID == employeeID){
				emp.onProject = true;
				proj2.employees.Add(emp);
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
