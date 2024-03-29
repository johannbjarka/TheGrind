﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private string[] firstNames = {
		"Omar",
		"D'Angelo",
		"Avon",
		"Stringer",
		"Jimmy",
		"Tom",
		"Bill",
		"Lavondrius",
		"Jimmy",
		"Leonardo",
		"Michaelangelo",
		"Donatello",
		"Rafael",
		"Chris",
		"Kermit",
		"Larry",
		"Bob",
		"Martin",
		"Moses",
		"John",
		"Peter",
		"Michael",
		"Link",
		"Neville",
		"David",
		"Marco",
		"Dario",
		"Ashley",
		"Ariel",
		"Alex",
		"Paris",
		"Terry",
		"Robin",
		"Blaine",
		"Parker",
		"Taylor",
		"Jane",
		"Alison",
		"Linda",
		"Peach",
		"Hilary",
		"Kendra",
		"Monique",
		"Ingrid",
		"Brunhilde",
		"Laura",
		"Elizabeth",
		"Tabitha",
		"Rachel",
		"Jennifer",
		"Rosa",
		"Maria",
		"Gemma"
	};
	private string[] lastNames = {
		"Muzone",
		"Little",
		"Barksdale",
		"Bell",
		"McNulty",
		"Williams",
		"Smith",
		"Johnson",
		"Jones",
		"Parker",
		"Neville",
		"King",
		"Martin",
		"Simpson",
		"Stark",
		"DiCaprio",
		"Schiffel",
		"Thue",
		"Bancale",
		"Carboni",
		"Totti",
		"Barzagli",
		"Lee",
		"Ki",
		"Gonzalez",
		"Huang",
		"Nguyen",
		"Villagra",
		"Stewart",
		"Colbert",
		"McBride",
		"Donovan",
		"Hendricks",
		"Lagavulin",
		"Henry",
		"Keane",
		"Bergkamp",
		"Gerrard",
		"Neeson",
		"Ulfkonge"
	};
	public int rand;
	public int salary;
	public string characterName;
	public char gender;
	public int[] skills;
	public RuntimeAnimatorController[] controllers;
	public Sprite[] sprites;
	public int speed;
	public int ID;
	private static int _ID = 0;
	public int morale;
	public bool onProject = false;
	public bool hasQuit = false;
	public string project;
	public float movSpeed;
	public Sprite sprite;
	public Animator anim;
	SpriteRenderer spriteRend;

	public GameObject employeePrefab;
	public GameObject HoverPanelPrefab;

	Company myCompany;

	Transform EmployeePrefabContentPanel;
	void Awake () {
		anim = GetComponent<Animator> ();
	}

	public void test() {
		GameObject newHoverPanel = Instantiate (HoverPanelPrefab) as GameObject;
		HoverPanel panel = newHoverPanel.GetComponent<HoverPanel> ();

		panel.CharacterName.text = this.characterName;
		panel.CharacterID.text = this.ID.ToString();

		var mousex = (Input.mousePosition.x);
		var mousey = (Input.mousePosition.y);
		var mouseposition = Camera.main.ScreenToWorldPoint (new Vector3 (mousex, mousey, 0));
		newHoverPanel.transform.localPosition = new Vector3 (mouseposition.x, mouseposition.y, 0);
		panel.transform.SetParent (EmployeePrefabContentPanel);
		newHoverPanel.gameObject.transform.localScale = new Vector3 (1, 1, 1);
		if(this.gender == 'M') {
			HelloMan hm = GameObject.FindWithTag("HelloMan").GetComponent<HelloMan>();
			hm.playSound();
		}
		else {
			HelloGirl hg = GameObject.FindWithTag("HelloGirl").GetComponent<HelloGirl>();
			hg.playSound();
		}
	}
	// Use this for initialization
	void Start () {
		myCompany = GameObject.Find ("Company").GetComponent<Company> ();
		EmployeePrefabContentPanel = myCompany.EmployeePrefabContentPanel;
        // Initialize character away from office
        // transform.position = new Vector3(-8 + Random.value * 10, -2 + Random.value * 5, 0);

        int totalskills = 0;

		for (int i = 0; i < skills.Length; i++) {
			skills[i] = Random.Range(1, 21);
			totalskills += skills[i];
		}

		speed = Random.Range(5, 11);
		salary = (int)(totalskills * 2 * (1.0 + ((speed - 3) / 10.0))) * 10;
		morale = Random.Range(3, 8);

		int genderType = Random.Range(0, 2);
		if(genderType == 0) {
			gender = 'M';
			characterName = firstNames[Random.Range(0, 36)] + " " + lastNames[Random.Range(0, lastNames.Length)];
			rand = Random.Range(10, sprites.Length);
			anim.runtimeAnimatorController = controllers[rand];
			sprite = sprites[rand];
		} else {
			gender = 'F';
			characterName = firstNames[Random.Range(27, firstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];
			rand = Random.Range(0, 9);
			anim.runtimeAnimatorController = controllers[rand];
			sprite = sprites[rand];
		}
		movSpeed = 0.03f;
		ID = _ID;
		_ID++;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterAI myAI = gameObject.GetComponent<CharacterAI>();
		if(myAI.thirsty < 50) {
			int dir = (int)(Random.value * 4);
			int mov = Random.Range(0,4);
			bool mov1;
			if (mov == 0) {
				mov1 = true;
			} else {
				mov1 = false;
			}
			anim.SetInteger ("Direction", dir);
			anim.SetBool ("Moving", mov1);
			anim.IsInTransition (0);

			if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")){
				transform.position += -Vector3.up * movSpeed;
			} else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_West")){
				transform.position += -Vector3.right * movSpeed;
			} else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")){
				transform.position += Vector3.up * movSpeed;
			} else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_East")){
				transform.position += Vector3.right * movSpeed;
			}
		}
		if(onProject)
		{
			transform.position = new Vector3(1000, 1000, 0); 
		}
	}
}
