using UnityEngine;
using System.Collections;

public class ComputerMenu : MonoBehaviour {

	public Canvas ComputerMenuCanvas;
	bool menuIsOpen = false;

	public void openComputerMenuPanel () {
		menuIsOpen = !menuIsOpen;
		ComputerMenuCanvas.enabled = !ComputerMenuCanvas.enabled;
	}


}
