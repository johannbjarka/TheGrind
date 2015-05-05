using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private string[] firstNames = new string[] {
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
	private string[] lastNames = new string[] {
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
	public bool isApplicant = true;
	public float movSpeed;
	Animator anim;
	SpriteRenderer spriteRend;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		// Initialize character away from office
		transform.position = new Vector3(0, 0, 0);
		int totalskills = 0;
		for (int i = 0; i < skills.Length; i++) {
			skills[i] = Random.Range(1, 21);
			totalskills += skills[i];
		}

		speed = Random.Range(1, 6);
		salary = (int)(totalskills * (1.0 + ((speed - 3) / 10.0)));
		morale = Random.Range(3, 8);
		int genderType = Random.Range(0, 2);
		if(genderType == 0) {
			gender = 'M';
			characterName = firstNames[Random.Range(0, 31)] + " " + lastNames[Random.Range(0, 35)];
			int rand = Random.Range(10, sprites.Length);
			anim.runtimeAnimatorController = controllers[rand];
			//spriteRend = GetComponent<SpriteRenderer> ();
			//spriteRend.sprite = sprites[rand];
		}
		else {
			gender = 'F';
			characterName = firstNames[Random.Range(22, 48)] + " " + lastNames[Random.Range(0, 35)];
			int rand = Random.Range(0, 9);
			anim.runtimeAnimatorController = controllers[rand];
			//spriteRend = GetComponent<SpriteRenderer> ();
			//spriteRend.sprite = sprites[rand];
		}
		movSpeed = 0.05f;
		ID = _ID;
		_ID++;
	}
	
	// Update is called once per frame
	void Update () {
		int dir = (int)(Random.value * 4);
		int mov = Random.Range(0,20);
		bool mov1;
		if (mov == 0) {
			mov1 = false;
		} else {
			mov1 = true;
		}
		anim.SetInteger ("Direction", dir);
		anim.SetBool ("Moving", mov1);
		anim.IsInTransition (0);
		//if (mov1 == true) {
		//if (dir == 0) {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")){
			//rigid.AddForce(-(Vector2.up * movSpeed));
			transform.position += -Vector3.up * movSpeed;
			//transform.Translate (-Vector2.up * movSpeed);
		} //else if (dir == 1) {
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_West")){
			//rigid.AddForce(-Vector2.right * movSpeed);
			transform.position += -Vector3.right * movSpeed;
			//transform.Translate (-Vector2.right * movSpeed);
		} else //if (dir == 2) {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")){
			//rigid.AddForce(Vector2.up * movSpeed);
			transform.position += Vector3.up * movSpeed;
			//transform.Translate (Vector2.up * movSpeed);
		} else// if (dir == 3) {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_East")){
			//rigid.AddForce(Vector2.right * movSpeed);
			transform.position += Vector3.right * movSpeed;
			//transform.Translate (Vector2.right * movSpeed);
		}
		//}
	}
}
