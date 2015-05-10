using UnityEngine;
using System.Collections;

public class CancelProject : MonoBehaviour {

	public void cancel(int id) {
		Company myCompany = GameObject.Find("Company").GetComponent<Company>();
		foreach(var proj in myCompany.projects) {
			if(id == proj.ID) {
				foreach(Character emp in proj.employees) {
					emp.onProject = false;
				}
				proj.employees.Clear();
				myCompany.availableProjects.Add(proj);
				myCompany.projects.Remove(proj);
				break;
			}
		}
	}
}
