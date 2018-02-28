using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CadenaPanel : MonoBehaviour {

	public string testString;

	public string[] cadenas;
	public string[] separators;
	public GameObject buttonPrefab;
	public RectTransform buttonsParent;
	[SerializeField]
	RectTransform resizeableScrollArea;

	public void GetCadenaButtons(string longString, string[] separators){

		//separates the long string based on selected separators and stores them inside plazas array
		cadenas = longString.Split (separators, System.StringSplitOptions.RemoveEmptyEntries);

		//FOR EACH ELEMENT INSIDE PLAZAS ARRAY ->
		for (int i = 0; i < cadenas.Length; i++) {
			//Creates a prefab and palce is inside the panel
			GameObject instantiatedButton = Instantiate (buttonPrefab, buttonsParent.transform) as GameObject;
			Button button = instantiatedButton.GetComponent<Button> ();
			//changes the name and label
			instantiatedButton.name = "Button_" + cadenas [i];
			button.GetComponentInChildren<Text> ().text = cadenas [i];
		}

		ResizeScrollArea ();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.C)) {
			GetCadenaButtons (testString, separators);
			Debug.Log ("Getting cadena buttons");
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
}
