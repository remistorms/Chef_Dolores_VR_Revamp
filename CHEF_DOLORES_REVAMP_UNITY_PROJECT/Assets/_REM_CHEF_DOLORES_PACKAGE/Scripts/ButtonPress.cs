using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonPress : MonoBehaviour {



	public void AnimateButton(){
		StartCoroutine (ButtonPressRoutine ());
	}

	IEnumerator ButtonPressRoutine(){
		//Dissables collider while the animation happens
		GetComponent<Collider> ().enabled = false;
		Vector3 originalScale = transform.localScale;

		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x,
			new Vector3(originalScale.x, 0.01f, originalScale.z),
			//Vector3.zero,
			0.2f);
		yield return new WaitForSeconds (0.2f);
		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x,
			originalScale,
			0.2f);
		yield return new WaitForSeconds (0.2f);

		//Dissables collider while the animation happens
		GetComponent<Collider> ().enabled = true;

	}
}
