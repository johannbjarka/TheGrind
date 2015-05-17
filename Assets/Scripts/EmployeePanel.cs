using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class EmployeePanel : MonoBehaviour {
	public GameObject panel;
	public Image employeeIcon;
	public Text speedLabel;
	public RectTransform speedBar;
	public Text nameLabel;
	public Text genderLabel;
	public Text salaryLabel;
	public Text moraleLabel;
	public RectTransform moraleBar;
	public Text project;
	public Button skillsButton;
	public Button hireButton;
	public Button fireButton;
	public Text ID;
	public Text ProjectID;
	public Text category;
	public Text rating;
	public RectTransform requiredSkillBar;
	Company myCompany;

	void Start() {
		myCompany = GameObject.Find("Company").GetComponent<Company>();
	}

	void Update() {
		int ID = Int32.Parse(this.ID.text);
		foreach(var emp in myCompany.characters) {
			if(emp.ID == ID) {
				speedLabel.text = emp.speed.ToString();
				speedBar.sizeDelta = new Vector2(emp.speed * 10, 20);
				moraleLabel.text = emp.morale.ToString();
				moraleBar.sizeDelta = new Vector2(emp.morale * 10, 20);
				salaryLabel.text = "$" + emp.salary.ToString();
			}
		}
	}

	public void giveRaise() {
		CashSound cash = GameObject.FindWithTag("Cash").GetComponent<CashSound>();
		cash.playSound();
		
		int ID = Int32.Parse(this.ID.text);
		foreach(var emp in myCompany.characters) {
			if(emp.ID == ID) {
				emp.salary += 250;
				if(emp.morale < 10) {
					emp.morale++;
				}
			}
		}
	}
	
	public void yellAt() {
		YellSound yell = GameObject.FindWithTag("Yell").GetComponent<YellSound>();
		yell.playSound();
		
		int ID = Int32.Parse(this.ID.text);
		foreach(var emp in myCompany.characters) {
			if(emp.ID == ID) {
				int rand = UnityEngine.Random.Range(0, 2);
				if(rand == 0){
					if(emp.speed < 10) {
						emp.speed++;
					}
				}
				rand = UnityEngine.Random.Range(0, 2);
				if(rand == 0) {
					if(emp.morale > 0) {
						emp.morale--;
					}
				}
			}
		}
	}
}
