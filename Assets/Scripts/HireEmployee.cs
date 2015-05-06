using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HireEmployee : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*public void hire (Character emp){
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		myCompany.characters.Add(emp);
		myCompany.applicants.Remove(emp);
		emp.gameObject.transform.position = new Vector3(0, 0, 0);
	}*/
	
	public void hire (Text _id){
		//TODO: Remove from Project, Remove from Company, take plant.
		int id = Int32.Parse(_id.text);
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		foreach(Character emp in myCompany.applicants){
			if(emp.ID == id){
				myCompany.characters.Add(emp);
				myCompany.applicants.Remove(emp);
				emp.gameObject.transform.position = new Vector3(0, 0, 0);
				break;
			}
		}
	}
}
