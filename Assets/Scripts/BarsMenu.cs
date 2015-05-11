using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class BarsMenu : MonoBehaviour {

	public Canvas SkillsCanvas;
	public SkillsMenu skills;
	Company myCompany;

	int[] WidthList;

	// Use this for initialization
	void Start () {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
		SkillsCanvas = GameObject.Find ("Skills Menu").GetComponent<Canvas> ();
		skills = GameObject.Find ("Skills Menu").GetComponentInChildren<SkillsMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getSkills (Text _ID) {
		// Open the canvas
		SkillsCanvas.enabled = true;

		// Parse the ID into int
		int ID = Int32.Parse(_ID.text);

		// Search for the employee character and fill in the skills.
		foreach (var emp in myCompany.characters) {
			if(emp.ID == ID) {
				fillSkillBars(emp);
			}
		}
		foreach (var appl in myCompany.applicants) {
			if(appl.ID == ID) {
				fillSkillBars(appl);
			}
		}
	}

	void fillSkillBars (Character person) {
		skills.AIRect.sizeDelta = new Vector2 (person.skills [0] * 10, 20);
		skills.AISkillAmount.text = person.skills [0].ToString () + " / 20";
		skills.AlgorithmsRect.sizeDelta = new Vector2 (person.skills [1] * 10, 20);
		skills.AlgorithmsSkillAmount.text = person.skills [1].ToString () + " / 20";
		skills.DatabasesRect.sizeDelta = new Vector2 (person.skills [2] * 10, 20);
		skills.DatabasesSkillAmount.text = person.skills [2].ToString() + " / 20";
		skills.HackingRect.sizeDelta = new Vector2 (person.skills [3] * 10, 20);
		skills.HackingSkillAmount.text = person.skills [3].ToString() + " / 20";
		skills.NetworkingRect.sizeDelta = new Vector2 (person.skills [4] * 10, 20);
		skills.NetworkingSkillAmount.text = person.skills [4].ToString() + " / 20";
		skills.WebDevelopmentRect.sizeDelta = new Vector2 (person.skills [5] * 10, 20);
		skills.WebDevelopmentSkillAmount.text = person.skills [5].ToString() + " / 20";
	}
	public void closeSkills () {
		SkillsCanvas.enabled = false;
	}


	
	
}
