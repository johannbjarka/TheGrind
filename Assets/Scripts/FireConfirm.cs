using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class FireConfirm : MonoBehaviour {

	public GameObject fireConfirmView;
	public Text fireText;
	private bool isOpen = false;

	void Start() {
		fireConfirmView.SetActive(false);
	}

	public void openFireConfirm (Text _id) {
		Company myCompany = GameObject.Find ("Company").GetComponent<Company>();
		int ID = Int32.Parse(_id.text);
		isOpen = !isOpen;
		fireConfirmView.SetActive(!fireConfirmView.activeSelf);
		ClickSound click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
		click.playSound();
		foreach(Character emp in myCompany.characters) {
			if(emp.ID == ID) {
				if(emp.gender == 'M') {
					fireText.text = "If you fire " + emp.characterName + 
						" you will have to pay him a severance package of $" + emp.salary.ToString();
				}
				else {
					fireText.text = "If you fire " + emp.characterName + 
						" you will have to pay her a severance package of $" + emp.salary.ToString();
				}
			}
		}
	}
}
