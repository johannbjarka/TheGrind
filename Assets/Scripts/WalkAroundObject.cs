using UnityEngine;
using System.Collections;

public class WalkAroundObject : MonoBehaviour {

	public Character me;

	void Awake () {
		me = gameObject.GetComponent<Character>();
	}

	void OnCollisionEnter2d(Collision col) {
		Debug.Log("Collision");
		if(col.gameObject.transform.position.x > gameObject.transform.position.x) {
			if(col.gameObject.transform.position.y > gameObject.transform.position.y) {
				//Go south
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 0);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")) {
					transform.position += Vector3.down * me.movSpeed;
				}
				mov1 = false;
			}
			else {
				//Go north
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 2);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")) {
					transform.position += Vector3.up * me.movSpeed;
				}
				mov1 = false;
			}
		}
		else {
			if(col.gameObject.transform.position.y > gameObject.transform.position.y) {
				//Go south
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 0);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")) {
					transform.position += Vector3.down * me.movSpeed;
				}
				mov1 = false;
			}
			else {
				//Go north
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 2);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")) {
					transform.position += Vector3.up * me.movSpeed;
				}
				mov1 = false;
			}
		}
	}
}
