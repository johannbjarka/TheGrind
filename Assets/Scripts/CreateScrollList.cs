using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public Sprite icon;
	public string name;
	public string gender;
	public string morale;
	public string speed;
	public string salary;
}

public class CreateScrollList : MonoBehaviour {

	public GameObject employeePanel;
	public List<Item> itemList;

	public Transform contentPanel;

	void Start () {
		PopulateList ();
	}

	void PopulateList () {
		foreach (var item in itemList) {
			GameObject newPanel = Instantiate (employeePanel) as GameObject;
			EmployeePanel panel = newPanel.GetComponent <EmployeePanel> ();
			panel.nameLabel.text = item.name;
			panel.genderLabel.text = item.gender;
			panel.moraleLabel.text = item.morale;
			panel.speedLabel.text = item.speed;
			panel.salaryLabel.text = item.salary;
			panel.employeeIcon.sprite = item.icon;
			newPanel.transform.SetParent (contentPanel);
		}
	}
}
