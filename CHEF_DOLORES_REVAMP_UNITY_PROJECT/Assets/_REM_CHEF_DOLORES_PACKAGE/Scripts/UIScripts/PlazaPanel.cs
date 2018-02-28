using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlazaPanel : MonoBehaviour {

	public string testString;

	public string[] plazas;
	public string[] separators;
	public GameObject buttonPrefab;
	public RectTransform buttonsParent;

	public void GetPlazaButtons(string longString, string[] separators){
	
		//separates the long string based on selected separators and stores them inside plazas array
		plazas = longString.Split (separators, System.StringSplitOptions.RemoveEmptyEntries);

		//FOR EACH ELEMENT INSIDE PLAZAS ARRAY ->
		for (int i = 0; i < plazas.Length; i++) {
			//Creates a prefab and palce is inside the panel
			GameObject instantiatedButton = Instantiate (buttonPrefab, buttonsParent.transform) as GameObject;
			Button button = instantiatedButton.GetComponent<Button> ();
			//changes the name and label
			instantiatedButton.name = "Button_" + plazas [i];
			button.GetComponentInChildren<Text> ().text = plazas [i];
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.P)) {
			GetPlazaButtons (testString, separators);
			Debug.Log ("Getting plaza buttons");
		}
	}
}
