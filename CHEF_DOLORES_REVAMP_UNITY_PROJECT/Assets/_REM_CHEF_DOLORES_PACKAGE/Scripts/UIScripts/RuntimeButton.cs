using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//MY ENUM
public enum ButtonTypeEnum 
{
	Plaza, 
	Cadena, 
	Premio 
};

public class RuntimeButton : MonoBehaviour {

	public ButtonTypeEnum buttonType;
	public Color selectedColor;
	Color defaultColor;
	void Awake(){

		//Adds the event listener depending on the selected buttonTypeEnum
		switch (buttonType) {

			case ButtonTypeEnum.Plaza:
			GetComponent<Button> ().onClick.AddListener (SetPlaza);
			break;

			case ButtonTypeEnum.Cadena:
			GetComponent<Button> ().onClick.AddListener (SetCadena);
			break;

			case ButtonTypeEnum.Premio:
			GetComponent<Button> ().onClick.AddListener (SetPremio);
			break;

			default:
			break;
		}

		//Adds the click event for changing colors
		GetComponent<Button> ().onClick.AddListener (ClickOnButton);
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

	//This method will add the string of the selected cadena
	void SetCadena(){
		DatosJugador.instance.SetCadena (GetComponentInChildren<Text> ().text);
	}

	void SetPremio(){
		DatosJugador.instance.SetPremio (GetComponentInChildren<Text> ().text);
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
