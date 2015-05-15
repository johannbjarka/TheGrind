using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoverPanel : MonoBehaviour {

	public GameObject HoverPanelPrefab;
	public Text CharacterName;
	public Text CharacterID;
	public Button SkillsButton;
	public Button FireButton;

	GameObject myCamera;
	CreateScrollList myList;
	// Use this for initialization
	void Start () {
		myCamera = GameObject.Find ("Main Camera");
		myList = myCamera.GetComponent<CreateScrollList> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void closeHoverPanel() {
		GameObject.Destroy (HoverPanelPrefab);
	}

	public void fireEmployee() {
		myList.fire (this.CharacterID);
		closeHoverPanel ();
	}


}
