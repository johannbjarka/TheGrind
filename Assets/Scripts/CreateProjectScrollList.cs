using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
/*
[System.Serializable]
public class ProjectItem {
	public string ProjectName;
	public string ProjectReward;
	public string ProjectDescription;
	public string ProjectPenalty;
	public string ProjectDeadline;
	public string ProjectCategory;
}
*/
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
		foreach (var project in myCompany.availableProjects) {
			GameObject newProjectPanel = Instantiate (availableProjectPanel) as GameObject;
			ProjectPanel panel = newProjectPanel.GetComponent <ProjectPanel> ();
			panel.Name.text = project.projName;
			if(project.deadline == 1) {
				panel.Deadline.text = "Next week";
			}
			else {
				panel.Deadline.text = project.deadline.ToString() + " weeks";
			}
			panel.Description.text = project.description;
			panel.Reward.text = project.reward.ToString();
			panel.Penalty.text = project.penalty.ToString();
			panel.ID.text = project.ID.ToString();
			panel.Category.text = myCompany.getDescription(project.category);
			newProjectPanel.transform.SetParent (AvailableProjectContentPanel);
			panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}

	public void PopulateCurrentProjectList () {
		foreach (var project in myCompany.projects) {
			GameObject newProjectPanel = Instantiate (currentProjectPanel) as GameObject;
			ProjectPanel panel = newProjectPanel.GetComponent <ProjectPanel> ();
			panel.Name.text = project.projName;
			if(project.deadline == 1) {
				panel.Deadline.text = "Next week";
			}
			else {
				panel.Deadline.text = project.deadline.ToString() + " weeks";
			}
			panel.Description.text = project.description;
			panel.Reward.text = project.reward.ToString();
			panel.Penalty.text = project.penalty.ToString();
			panel.Category.text = myCompany.getDescription(project.category);
			newProjectPanel.transform.SetParent (CurrentProjectContentPanel);
			panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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


}
