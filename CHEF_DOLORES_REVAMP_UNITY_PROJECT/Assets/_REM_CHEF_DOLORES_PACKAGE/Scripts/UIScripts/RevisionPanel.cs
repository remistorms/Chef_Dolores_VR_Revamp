using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevisionPanel : MonoBehaviour {

	public Text textArea;
	string infoString;

	public void ShowPreGameInfo(){

		//String to format the information
		infoString = 
			"<size=25>" + DatosJugador.instance.nombreJugador + "</size>" + 
			"\n" + "--------------------" + "\n" +
			"Ticket: " + DatosJugador.instance.ticketJugador + "\n" +
			"Monto: $" + DatosJugador.instance.montoDeCompra.ToString() + "\n" +
			"--------------------" + "\n" +
			"Plaza: " + DatosJugador.instance.plazaSeleccionada + "\n" +
			"Cadena: " + DatosJugador.instance.cadenaSeleccionada + "\n" +
			"Premio: " + DatosJugador.instance.premioSeleccionado + "\n" +
			"--------------------"
			;

		textArea.text = infoString;

	}

}
