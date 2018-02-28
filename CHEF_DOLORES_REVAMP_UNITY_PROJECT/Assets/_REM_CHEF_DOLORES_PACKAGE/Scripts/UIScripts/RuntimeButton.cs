using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeButton : MonoBehaviour {

	public Color selectedColor;
	Color defaultColor;
	void Awake(){
		//Adds the click event for changing colors
		GetComponent<Button> ().onClick.AddListener (ClickOnButton);
		GetComponent<Button> ().onClick.AddListener (SetPlaza);
		defaultColor= GetComponent<Button> ().image.color;
	}

	void ClickOnButton(){
		ResetAllButtons ();
		GetComponent<Button> ().image.color = selectedColor;
	}

	//This method will add the string of the selected plaza
	void SetPlaza(){
		DatosJugador.instance.SetPlaza (GetComponentInChildren<Text> ().text);
	}

	//This will reset the colors
	public void ResetColor(){
		
		GetComponent<Button> ().image.color = defaultColor;
	}

	void ResetAllButtons(){
		
		//Get all buttons inside the panel, my brother buttons
		RuntimeButton[] buttonBrothers = transform.parent.GetComponentsInChildren<RuntimeButton>();
		//Change each of the buttons to reset color
		foreach (var item in buttonBrothers) {
			item.ResetColor ();
		}

	}
}
