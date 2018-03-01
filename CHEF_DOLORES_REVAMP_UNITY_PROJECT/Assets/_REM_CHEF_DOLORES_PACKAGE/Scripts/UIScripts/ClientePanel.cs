using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ClientePanel : MonoBehaviour {


	public InputField nombre, ticket, monto, productos;
	public Button nextButton;

	void FixedUpdate(){
	
		if (nombre.text == "" || ticket.text == "" || monto.text == "" || productos.text == "") {
			nextButton.interactable = false;
		} else {
			nextButton.interactable = true;
		}
	}


}
