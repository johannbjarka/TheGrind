using UnityEngine;
using System.Collections;

public class FireEmployee : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fire (int id){
		//TODO: Remove from Project, Remove from Company, take plant.
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		foreach(Project proj in myCompany.projects){
			foreach(Character emp in proj.employees){
				if(emp.ID == id){
					proj.employees.Remove(emp);
				}
			}
		}
		foreach(Character emp in myCompany.characters){
			if(emp.ID == id){
				myCompany.characters.Remove(emp);
				Destroy(emp);
			}
		}
		//takePlant();
	}
}
