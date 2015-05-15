using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public RectTransform projectProgressBar;
	public Text ProgressAmount;

	public RectTransform FinalProjectProgressBar;
	public Text FinalProgressAmount;

	public void setProgressTo(float progress) {
		progress *= 100;
		if (progress > 100) {
			progress = 100;
		}
		ProgressAmount.text = ((int)progress).ToString ();
		projectProgressBar.sizeDelta = new Vector2 (80, progress * 2.5f);
	}

	public void setFinalProgressTo(float progress) {
		progress *= 100;
		if (progress > 100) {
			progress = 100;
		}
		FinalProgressAmount.text = ((int)progress).ToString ();
		FinalProjectProgressBar.sizeDelta = new Vector2(80, progress * 2.5f);
	}
}
