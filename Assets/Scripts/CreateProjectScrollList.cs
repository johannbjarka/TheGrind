using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProjectItem {
	public string ProjectName;
	public string ProjectReward;
	public string ProjectDescription;
	public string ProjectPenalty;
	public string ProjectDeadline;
	public string ProjectCategory;
}

public class CreateProjectScrollList : MonoBehaviour {
	public GameObject projectPanel;
	public List<ProjectItem> projectList;

	public Transform ProjectContentPanel;

	void Start () {
		PopulateProjectList ();
	}

	void PopulateProjectList () {
		foreach (var project in projectList) {
			GameObject newProjectPanel = Instantiate (projectPanel) as GameObject;
			ProjectPanel panel = newProjectPanel.GetComponent <ProjectPanel> ();
			panel.Name.text = project.ProjectName;
			panel.Deadline.text = project.ProjectDeadline;
			panel.Description.text = project.ProjectDescription;
			panel.Reward.text = project.ProjectReward;
			panel.Penalty.text = project.ProjectPenalty;
			panel.Category.text = project.ProjectCategory;
			newProjectPanel.transform.SetParent (ProjectContentPanel);
			panel.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
}
