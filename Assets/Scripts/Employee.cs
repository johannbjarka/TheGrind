using UnityEngine;
using System.Collections;

public class Employee : Applicant {
	
	public int morale;
	Animator anim;

	void Awake () {
		morale = Random.Range(3, 7);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
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
	}
}
