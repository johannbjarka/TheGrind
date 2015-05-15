using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HoverPanel : MonoBehaviour {

	public GameObject HoverPanelPrefab;
	public Text CharacterName;
	public Button SkillsButton;
	public Button FireButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void closeHoverPanel() {
		GameObject.Destroy (HoverPanelPrefab);
	}
}
