using UnityEngine;
using System.Collections;

public class Employee : Applicant {

	//Rigidbody2D rigid;
	Animator anim;

	void Awake () {
		morale = Random.Range(3, 7);
		//menu = gameObject.AddComponent<EmployeeMenu>() as EmployeeMenu;
		//menu.employeeID = this.ID;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//rigid = GetComponent<Rigidbody2D> ();
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
