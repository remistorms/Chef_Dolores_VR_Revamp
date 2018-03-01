using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SecondaryCanvas : MonoBehaviour {

	public static SecondaryCanvas instance;

	public Image icon;
	float rotateSpeed = -3f;
	bool isRotating = false;
	Vector3 originalScale;


	void Awake(){
		instance = this;
		//
		originalScale = transform.localScale;
		transform.localScale = Vector3.zero;
		gameObject.SetActive (false);
	}

	public void ShowLoadingMessage(){

		gameObject.SetActive (true);
		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x, 
			originalScale,
			0.5f);

		isRotating = true;
		
	}

	public void HideLoadingMessage(){
		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x, 
			Vector3.zero,
			0.5f);

		isRotating = false;
	}

	void FixedUpdate(){
		if (isRotating) {
			icon.transform.RotateAround (Vector3.forward, rotateSpeed * Time.deltaTime);
		}
	}
}
