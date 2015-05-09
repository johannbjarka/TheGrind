using UnityEngine;
using System.Collections;

public class CharacterAI : MonoBehaviour {

	public Character me;
	public Vector2[] watercoolers;
	public int thirsty;

	void Awake(){
		me = gameObject.GetComponent<Character>();
		thirsty = Random.Range(1, 50);
	}

	void Start(){
		watercoolers = new Vector2[3];
		watercoolers[0].x = 0.01f;
		watercoolers[0].y = 4.19f;
		watercoolers[1].x = -8.66f;
		watercoolers[1].y = 0.679f;
		watercoolers[2].x = 8.656f;
		watercoolers[2].y = 0.682f;
	}

	void Update(){
		//if(me != null){

		//Debug.Log(me.characterName);
		int rand = Random.Range(0, 10001);
		if(rand > 9995){
			thirsty++;
		}

		//Check if thirsty
		if(thirsty >= 50){
			if(!me.onProject) {
				getWater();
			}
		}
		//}
	}

	void getWater(){

		//Check current position
		float x = transform.position.x;
		float y = transform.position.y;

		//Get closest watercooler
		Vector2 myPosition = new Vector2(x, y);
		int closest = 0;
		for(int i = 1; i < 3; i++){
			if(Vector2.Distance(watercoolers[i], myPosition) < Vector2.Distance(watercoolers[closest], myPosition)){
				closest = i;
			}
		}

		//Travel to watercoolers[i]
		if(watercoolers[closest].x > x + 0.1) {
			//Go to the right until x == watercoolers[closest].x
			bool mov1 = true;

			me.anim.SetInteger ("Direction", 3);
			me.anim.SetBool ("Moving", mov1);
			me.anim.IsInTransition (0);
			if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_East")) {
				transform.position += Vector3.right * me.movSpeed;
			}
		}
		else if(watercoolers[closest].x < x - 0.1) {
			//Go to the left until x == watercoolers[closest].x
			bool mov1 = true;
			
			me.anim.SetInteger ("Direction", 1);
			me.anim.SetBool ("Moving", mov1);
			me.anim.IsInTransition (0);
			if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_West")) {
				transform.position += Vector3.left * me.movSpeed;
			}
		}
		else {
			if(watercoolers[closest].y > y + 0.1) {
				//Go north until x == watercoolers[closest].x
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 2);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")) {
					transform.position += Vector3.up * me.movSpeed;
				}
			}
			else if(watercoolers[closest].y < y - 0.1) {
				//Go south until x == watercoolers[closest].x
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 0);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")) {
					transform.position += Vector3.down * me.movSpeed;
				}
			}
			else {
				//Do nothing
				//Play drinking animation?
				thirsty = 0;
			}
		}

		/*
		//me.transform.position(watercoolers[closest].x, myPosition.y);
		//gameObject.transform.position = new Vector3(watercoolers[closest].x, watercoolers[closest].y, 0);

		//Run function for drinking from that watercooler
		*/

	}
}
