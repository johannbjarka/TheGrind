using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {
		
	public float Xpos;
	public float Ypos;

	// Update is called once per frame
	void Update () {
		Xpos = transform.position.x;
		Ypos = transform.position.y;
		transform.position = new Vector3 (Xpos, Ypos, Ypos);
	}
}
