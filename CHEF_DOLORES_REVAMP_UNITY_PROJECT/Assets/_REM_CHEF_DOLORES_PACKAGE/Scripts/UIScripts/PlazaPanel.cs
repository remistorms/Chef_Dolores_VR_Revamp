﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlazaPanel : MonoBehaviour {


	public string plaza_url;
	public string[] plazas;
	public string[] separators;
	public GameObject buttonPrefab;
	public RectTransform buttonsParent;
	public Button nextButton;
	string plazasDisponibles;

	[SerializeField]
	RectTransform resizeableScrollArea;

	public void GetPlazaButtons(){
	
		//Shows loading 
		SecondaryCanvas.instance.ShowLoadingMessage ();
		StartCoroutine (GetPlazasRoutine ());

	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.P)) {
			//GetPlazaButtons (testString, separators);
			Debug.Log ("Getting plaza buttons");
		}
	}

	//modifies the size of the scroll area based on the amount of childern
	void ResizeScrollArea(){
		//GetNumber of childer
		int totalButtons = resizeableScrollArea.childCount;
		Vector2 size;

		//Checks if the buttons are odd or even and gets the proper wigdth
		if (totalButtons % 3 == 0 && totalButtons >= 9) {
			Debug.Log ("Even numbered buttons");
			float x = 400 + (totalButtons/3) * 400;
			size = new Vector2 (x, resizeableScrollArea.sizeDelta.y);
		} 

		else if (totalButtons % 3 != 0 && totalButtons >= 9) {
			Debug.Log ("Odd numbered buttons");
			float x = 400 + (Mathf.RoundToInt(totalButtons/3)) * 400;
			size = new Vector2 (x, resizeableScrollArea.sizeDelta.y);
		}

		else {
			size = new Vector2 (1200, resizeableScrollArea.sizeDelta.y);
		}

		//Resizes the panel accordingly 
		resizeableScrollArea.sizeDelta = size;
	}

	//This method activates NEXT button only when one button is pressed
	void NextButtonActivator(){
		//Debug.LogError("I added a method to the button, but the cool thing is that the method is on this game object.... evens baby");
		nextButton.interactable = true;
	}

	void Start(){
		nextButton.interactable = false;
	}

	public void GetPlazas()
	{
		StartCoroutine(GetPlazasRoutine());
	}

	//Get
	IEnumerator GetPlazasRoutine(){


		UnityWebRequest www = UnityWebRequest.Get(plaza_url);

		yield return www.SendWebRequest();
		yield return new WaitForSeconds (1.5f);

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
			SecondaryCanvas.instance.ShowErrorMessage ("OCURRIO UN ERROR: " + www.error);
		}

		else {
			// Show results as text
			plazasDisponibles = www.downloadHandler.text;
			//separates the long string based on selected separators and stores them inside plazas array
			plazas = plazasDisponibles.Split (separators, System.StringSplitOptions.RemoveEmptyEntries);
		

			//FOR EACH ELEMENT INSIDE PLAZAS ARRAY ->
			for (int i = 0; i < plazas.Length; i++) {
				yield return new WaitForSeconds (0.05f);
				//Creates a prefab and palce is inside the panel
				GameObject instantiatedButton = Instantiate (buttonPrefab, buttonsParent.transform) as GameObject;
				Button button = instantiatedButton.GetComponent<Button> ();
				//changes the name and label
				instantiatedButton.name = "Button_" + plazas [i];
				instantiatedButton.GetComponent<Button> ().onClick.AddListener (NextButtonActivator);
				button.GetComponentInChildren<Text> ().text = plazas [i];
			}

			SecondaryCanvas.instance.HideLoadingMessage ();
			ResizeScrollArea ();
		}
	}
}
