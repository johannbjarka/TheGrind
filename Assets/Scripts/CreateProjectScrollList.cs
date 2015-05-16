using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class CreateProjectScrollList : MonoBehaviour {

	public GameObject availableProjectPanel;
	public GameObject currentProjectPanel;

	Company myCompany;

	public Transform AvailableProjectContentPanel;
	public Transform CurrentProjectContentPanel;

	void Start () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
	}

	public void PopulateAvailableProjectList () {
		emptyProjectList ();
		for (int i = myCompany.availableProjects.Count - 1; i >= 0; i--) {
			if(!myCompany.availableProjects[i].isFinished) {
				GameObject newProjectPanel = Instantiate (availableProjectPanel) as GameObject;
				ProjectPanel panel = newProjectPanel.GetComponent <ProjectPanel> ();
				panel.Name.text = myCompany.availableProjects[i].projName;
				if(myCompany.availableProjects[i].deadline == 1) {
					panel.Deadline.text = "Next week";
				}
				else {
					panel.Deadline.text = myCompany.availableProjects[i].deadline.ToString() + " weeks";
				}
				panel.Description.text = myCompany.availableProjects[i].description;
				panel.Reward.text = "$" + myCompany.availableProjects[i].reward.ToString();
				panel.Penalty.text = "$" + myCompany.availableProjects[i].penalty.ToString();
				panel.ID.text = myCompany.availableProjects[i].ID.ToString();
				panel.Category.text = myCompany.getDescription(myCompany.availableProjects[i].category);
				newProjectPanel.transform.SetParent (AvailableProjectContentPanel);
				panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			}
		}
	}

	public void PopulateCurrentProjectList () {
		if (myCompany.projects.Count == 0) {
			// Display shortcut to available projects
			Debug.Log("No Projects");
		} else {
			emptyProjectList ();
			foreach (var project in myCompany.projects) {
				if (!project.isFinished) {
					GameObject newProjectPanel = Instantiate (currentProjectPanel) as GameObject;
					ProjectPanel panel = newProjectPanel.GetComponent <ProjectPanel> ();
					panel.Name.text = project.projName;
					if (project.deadline == 1) {
						panel.Deadline.text = "Next week";
					} else {
						panel.Deadline.text = project.deadline.ToString () + " weeks";
					}
					panel.Description.text = project.description;
					panel.Reward.text = "$" + project.reward.ToString ();
					panel.Penalty.text = "$" + project.penalty.ToString ();
					panel.ID.text = project.ID.ToString ();
					float _ratio = (float)project.workEstimate / project.initialWorkAmount;
					int ratio = (int)(_ratio * 100);
					if (ratio > 100) {
						ratio = 100;
					}
					panel.percentDone.text = "Estimate: " + ratio.ToString () + "%";
					panel.progressBar.sizeDelta = new Vector2 (ratio * 4.8f, 30);
					panel.Category.text = myCompany.getDescription (project.category);
					newProjectPanel.transform.SetParent (CurrentProjectContentPanel);
					panel.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				}
			}
		}
	}

	public void emptyProjectList () {
		foreach (Transform child in AvailableProjectContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
		foreach (Transform child in CurrentProjectContentPanel) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void selectProject(Text _id) {
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();

		myCompany = GameObject.Find ("Company").GetComponent<Company>();
		int id = Int32.Parse(_id.text);
		myCompany.selectedProject = id;
		// Takes player to menu to select employees for project
		CreateScrollList list = GameObject.Find("Main Camera").GetComponent<CreateScrollList>();
		list.PopulateAvailableInitialEmployeeList(id);
	}

	public void destroyPanel() {
		emptyProjectList();
		PopulateAvailableProjectList();
		CreateScrollList scrollList = GameObject.Find("Main Camera").GetComponent<CreateScrollList>();
		scrollList.emptyInitialAvailableEmployeeList();
	}

	public void deSelectProject () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		foreach(var proj in myCompany.availableProjects) {
			if(myCompany.selectedProject == proj.ID) {
				foreach(Character emp in proj.employees) {
					emp.onProject = false;
					emp.transform.position = new Vector3(-8 + UnityEngine.Random.value * 10, -2 + UnityEngine.Random.value * 5, 0);
				}
				proj.workEstimate = 0;
				proj.employees.Clear();
				break;
			}
		}
	}

	public void addToProject(Text _id) {
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();

		int id = Int32.Parse(_id.text);
		CreateScrollList list = GameObject.Find("Main Camera").GetComponent<CreateScrollList>();
		list.PopulateAvailableEmployeeList(id);
	}

	public void removeFromProject(Text _id) {
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
		int id = Int32.Parse(_id.text);
		CreateScrollList list = GameObject.Find("Main Camera").GetComponent<CreateScrollList>();
		list.populateProjectEmployeeList(id);
	}

}
