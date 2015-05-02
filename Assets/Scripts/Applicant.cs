using UnityEngine;
using System.Collections;

public class Applicant : Character {

	private static int numberOfSkills = 13;
	public int[] skills = new int[numberOfSkills];
	public int speed;

	void Awake () {
		for (int i = 0; i < skills.Length; i++) {
			skills[i] = Random.Range(0, 20);
		}
		speed = Random.Range(0, 5);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hire () {
		//Employee emp = new Employee(this.skills, this.speed);
	}

	public Applicant createApplicant () {
		Applicant appl = gameObject.AddComponent<Applicant>() as Applicant;
		for (int i = 0; i < skills.Length; i++) {
			appl.skills[i] = Random.Range(1, 20);
		}
		appl.speed = Random.Range(1, 5);
		return appl;
	}
}
