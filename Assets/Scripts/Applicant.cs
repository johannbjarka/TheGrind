using UnityEngine;
using System.Collections;

public class Applicant : Character {

	private static int numberOfSkills = 13;
	public int[] skills = new int[numberOfSkills];
	public int speed;
	public int ID;
	public ApplicantMenu menu;

	void Awake () {
		for (int i = 0; i < skills.Length; i++) {
			skills[i] = Random.Range(0, 20);
		}
		speed = Random.Range(0, 5);
		menu = gameObject.AddComponent<ApplicantMenu>() as ApplicantMenu;
		menu.applicantID = this.ID;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hire () {
		Employee emp = gameObject.AddComponent<Employee>() as Employee;
		for (int i = 0; i < skills.Length; i++) {
			emp.skills[i] = this.skills[i];
		}
		emp.speed = this.speed;
		emp.salary = this.salary;
		emp.characterName = this.characterName;
		emp.gender = this.gender;

		// Add the applicant to the employee roster and remove it from the pool of applicants.
		//Company myCompany = GetComponent<Company>();
		Company myCompany = gameObject.GetComponent<Company>();
		myCompany.characters.Add(emp.characterName, emp);
		myCompany.applicants.Remove(this.characterName);

		// Destroy this instance of the Applicant script, since it will not be used again.
		Destroy(this);
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
