using UnityEngine;
using System.Collections;

public class CharacterAI : MonoBehaviour {
	
	public Character me;
	public Vector2[] watercoolers;
	public int thirsty;
	
	void Awake(){
		me = GetComponent<Character>();
		thirsty = Random.Range(1, 50);
	}
	
	void Start(){
		watercoolers = new Vector2[8];
		watercoolers[0].x = -8.66f;
		watercoolers[0].y = 0.879f;
		watercoolers[1].x = 8.656f;
		watercoolers[1].y = 0.882f;

		watercoolers[2].x = 5f;
		watercoolers[2].y = 1.7f;
		watercoolers[3].x = -5f;
		watercoolers[3].y = 1.7f;
		watercoolers[4].x = -5f;
		watercoolers[4].y = 0.2f;
		watercoolers[5].x = 5f;
		watercoolers[5].y = 0.2f;
		watercoolers[6].x = -5f;
		watercoolers[6].y = -1.2f;
		watercoolers[7].x = 5f;
		watercoolers[7].y = 1.2f;
	}
	
	void Update(){
		//if(me != null){
		
		//Debug.Log(me.characterName);
		int rand = Random.Range(0, 10001);
		if(rand > 9995){
			thirsty++;
		}
		
		//Check if thirsty
		if(thirsty >= 200000){
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
		for(int i = 1; i < 8; i++){
			if(Vector2.Distance(watercoolers[i], myPosition) < Vector2.Distance(watercoolers[closest], myPosition)){
				closest = i;
			}
		}
		
		if((-8.34f < x && x < -5.71f) 
		   || (-4.221f < x && x < -1.421f)
		   || (-0.725f < x && x < 0.745f)
		   || (1.43f < x && x < 4.23f)
		   || (5.667f < x && x < 8.34f)) {
			
			//Travel to watercoolers[i]
			if(watercoolers[closest].x > x + 0.6) {
				//Go to the right until x == watercoolers[closest].x
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 3);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_East")) {
					transform.position += Vector3.right * me.movSpeed;
				}
				mov1 = false;
				//me.anim.speed = 1;
			}
			else if(watercoolers[closest].x < x - 0.6) {
				//Go to the left until x == watercoolers[closest].x
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 1);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_West")) {
					transform.position += Vector3.left * me.movSpeed;
				}
				mov1 = false;
				//me.anim.speed = 1;
			}
			else {
				if(watercoolers[closest].y > y + 0.8) {
					//Go north until x == watercoolers[closest].x
					bool mov1 = true;
					
					me.anim.SetInteger ("Direction", 2);
					me.anim.SetBool ("Moving", mov1);
					me.anim.IsInTransition (0);
					me.anim.speed = 5;
					if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")) {
						transform.position += Vector3.up * me.movSpeed;
					}
					mov1 = false;
					//me.anim.speed = 1;
				}
				else if(watercoolers[closest].y < y - 0.3) {
					//Go south until x == watercoolers[closest].x
					bool mov1 = true;
					
					me.anim.SetInteger ("Direction", 0);
					me.anim.SetBool ("Moving", mov1);
					me.anim.IsInTransition (0);
					me.anim.speed = 5;
					if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")) {
						transform.position += Vector3.down * me.movSpeed;
					}
					mov1 = false;
					//me.anim.speed = 1;
				}
				else {
					//Do nothing
					//Play drinking animation?
					thirsty = 0;
					me.anim.speed = 0.7f;
				}
			}
		}
		else {
			//Travel to watercoolers[i]
			if(watercoolers[closest].y > y + 0.8) {
				//Go north until x == watercoolers[closest].x
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 2);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_North")) {
					transform.position += Vector3.up * me.movSpeed;
				}
				mov1 = false;
				//me.anim.speed = 1;
			}
			else if(watercoolers[closest].y < y - 0.3) {
				//Go south until x == watercoolers[closest].x
				bool mov1 = true;
				
				me.anim.SetInteger ("Direction", 0);
				me.anim.SetBool ("Moving", mov1);
				me.anim.IsInTransition (0);
				me.anim.speed = 5;
				if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_South")) {
					transform.position += Vector3.down * me.movSpeed;
				}
				mov1 = false;
				//me.anim.speed = 1;
			}
			else {
				if(watercoolers[closest].x > x + 0.6) {
					//Go to the right until x == watercoolers[closest].x
					bool mov1 = true;
					
					me.anim.SetInteger ("Direction", 3);
					me.anim.SetBool ("Moving", mov1);
					me.anim.IsInTransition (0);
					me.anim.speed = 5;
					if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_East")) {
						transform.position += Vector3.right * me.movSpeed;
					}
					mov1 = false;
					//me.anim.speed = 1;
				}
				else if(watercoolers[closest].x < x - 0.6) {
					//Go to the left until x == watercoolers[closest].x
					bool mov1 = true;
					
					me.anim.SetInteger ("Direction", 1);
					me.anim.SetBool ("Moving", mov1);
					me.anim.IsInTransition (0);
					me.anim.speed = 5;
					if(me.anim.GetCurrentAnimatorStateInfo(0).IsName("Char_Walk_West")) {
						transform.position += Vector3.left * me.movSpeed;
					}
					mov1 = false;
					//me.anim.speed = 1;
				}
				else {
					//Do nothing
					//Play drinking animation?
					thirsty = 0;
					me.anim.speed = 0.7f;
				}
			}
		}
		/*
		//me.transform.position(watercoolers[closest].x, myPosition.y);
		//gameObject.transform.position = new Vector3(watercoolers[closest].x, watercoolers[closest].y, 0);

		//Run function for drinking from that watercooler
		*/
		
	}
}
