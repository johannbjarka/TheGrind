using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class HoverFireConfirm : MonoBehaviour {
	
	public GameObject hoverFireConfirm;
	public Text hoverFireText;
	private bool hoverIsOpen = false;
	
	void Start() {
		hoverFireConfirm.SetActive(false);
	}
	
	public void openHoverFireConfirm (Text _id) {
		Company myCompany = GameObject.Find ("Company").GetComponent<Company>();
		int ID = Int32.Parse(_id.text);
		hoverIsOpen = !hoverIsOpen;
		hoverFireConfirm.SetActive(!hoverFireConfirm.activeSelf);
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
		foreach(Character emp in myCompany.characters) {
			if(emp.ID == ID) {
				if(emp.gender == 'M') {
					hoverFireText.text = "If you fire " + emp.characterName + 
						" you will have to pay him a severance package of $" + emp.salary.ToString();
				}
				else {
					hoverFireText.text = "If you fire " + emp.characterName + 
						" you will have to pay her a severance package of $" + emp.salary.ToString();
				}
			}
		}
	}
}
