﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HoverPanel : MonoBehaviour {

	public GameObject HoverPanelPrefab;
	public Text CharacterName;
	public Text CharacterID;
	public Button SkillsButton;
	public Button FireButton;
	Company myCompany;

	GameObject myCamera;
	CreateScrollList myList;
	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find ("Main Camera");
		myList = myCamera.GetComponent<CreateScrollList> ();
		myCompany = GameObject.Find("Company").GetComponent<Company>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void closeHoverPanel() {
		GameObject.Destroy (HoverPanelPrefab);
	}

	public void fireEmployee() {
		myList.fire (this.CharacterID);
		closeHoverPanel ();
	}

	public void giveRaise() {
		CashSound cash = GameObject.FindWithTag("Cash").GetComponent<CashSound>();
		cash.playSound();

		int ID = Int32.Parse(this.CharacterID.text);
		foreach(var emp in myCompany.characters) {
			if(emp.ID == ID) {
				emp.salary += 250;
				emp.morale++;
			}
		}
	}

	public void yellAt() {
		YellSound yell = GameObject.FindWithTag("Yell").GetComponent<YellSound>();
		yell.playSound();

		int ID = Int32.Parse(this.CharacterID.text);
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
