using UnityEngine;
using System;
using System.Collections;

public class SelectingEmployees : MonoBehaviour {

	ClickSound click;
	// Use this for initialization
	void Start () {
		click = GameObject.FindWithTag("ClickSound").GetComponent<ClickSound>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
