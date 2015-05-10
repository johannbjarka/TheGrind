using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public RectTransform progressFill;
	public RectTransform removeEmpsFill;

	public void scaleFill (float ratio) {
		if(ratio > 1.0f) {
			ratio = 1.0f;
		}
		progressFill.localScale = new Vector3(progressFill.localScale.x, ratio, progressFill.localScale.z);
	}

	public void scaleRemoveFill (float ratio) {
		if(ratio > 1.0f) {
			ratio = 1.0f;
		}
		removeEmpsFill.localScale = new Vector3(removeEmpsFill.localScale.x, ratio, removeEmpsFill.localScale.z);
	}
}
