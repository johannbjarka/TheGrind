using UnityEngine;
using System.Collections;

public class FireEmployee : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fire (){
		//TODO: Remove from Project, Remove from Company, take plant.
		Company myCompany = GameObject.Find("Main Camera").GetComponent<Company>();
		/*foreach(Project proj in myCompany.projects){
			foreach(Employee emp in proj.employees){
				//if(emp.characterName == this.par)
			}
		}*/
	}
}
