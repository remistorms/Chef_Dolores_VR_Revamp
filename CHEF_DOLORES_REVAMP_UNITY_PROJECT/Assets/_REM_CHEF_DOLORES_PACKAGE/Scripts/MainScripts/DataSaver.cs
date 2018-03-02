using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataSaver : MonoBehaviour {

	public InputField nombreLabel, ticketLabel, montoLabel, productosLabel; 

	public static DataSaver instance;
	public GameObject boot_GO;
	DatosJugador datosJugador;

	// Use this for initialization
	void Start () {
		instance = this;
		boot_GO = GameObject.Find ("Boot_GO");
		datosJugador = boot_GO.transform.GetComponent<DatosJugador> ();
	}

	public void SubmitDatosCliente(){
	
		datosJugador.SetNombre (nombreLabel.text.ToUpper());
		datosJugador.SetTicket (ticketLabel.text);
		datosJugador.SetMonto (float.Parse (montoLabel.text));
		datosJugador.SetCompra (productosLabel.text);
	}
	

}
