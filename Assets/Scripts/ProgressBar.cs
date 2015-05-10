using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public RectTransform progressFill;

	public void scaleFill () {
		progressFill.localScale = new Vector3(progressFill.localScale.x, 0.2f, progressFill.localScale.z);
	}
}
