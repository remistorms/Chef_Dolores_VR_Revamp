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
	public CanvasGroup errorCanvas, loadingCanvas;
	public Text errorLabel;


	void Awake(){
		instance = this;
		loadingCanvas.alpha = 0;
		loadingCanvas.blocksRaycasts = false;
		errorCanvas.alpha = 0;
		errorCanvas.blocksRaycasts = false;
		gameObject.SetActive (false);
	}

	public void ShowLoadingMessage(){

		gameObject.SetActive (true);

		DOTween.To (
			() => loadingCanvas.alpha,
			x => loadingCanvas.alpha = x, 
			1,
			0.5f);

		loadingCanvas.blocksRaycasts = true;
		isRotating = true;
		
	}

	public void HideLoadingMessage(){

		DOTween.To (
			() => loadingCanvas.alpha,
			x => loadingCanvas.alpha = x, 
			0,
			0.5f);

		loadingCanvas.blocksRaycasts = false;
		isRotating = false;
	}

	//ERROR MESSAGE
	public void ShowErrorMessage(string error){

		gameObject.SetActive (true);
		errorLabel.text = error;

		DOTween.To (
			() => errorCanvas.alpha,
			x => errorCanvas.alpha = x, 
			1,
			0.5f);

		errorCanvas.blocksRaycasts = true;

	}

	public void HideErrorMessage(){

		DOTween.To (
			() => errorCanvas.alpha,
			x => errorCanvas.alpha = x, 
			0,
			0.5f);

		errorCanvas.blocksRaycasts = false;

	}

	void FixedUpdate(){
		if (isRotating) {
			icon.transform.RotateAround (Vector3.forward, rotateSpeed * Time.deltaTime);
		}
	}
}
