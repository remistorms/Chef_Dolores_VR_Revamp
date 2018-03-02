using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour {

	public static DatosJugador instance;

	public string nombreJugador;
	public string ticketJugador; 
	public string productosComprados; 
	public float montoDeCompra; 
	public string plazaSeleccionada; 
	public string cadenaSeleccionada; 
	public string premioSeleccionado;
	public int puntosObtenidos;

	public string resultadoDelJuego;

	void Awake()
	{
		instance = this;
		resultadoDelJuego = "";
	}


	public void SetNombre(string name){
		nombreJugador = name;
	}

	public void SetTicket(string ticket){
		ticketJugador = ticket;
	}

	public void SetCompra(string compra){
		productosComprados = compra;
	}

	public void SetMonto(float monto){
		montoDeCompra = monto;
	}

	public void SetPlaza(string plaza){
		plazaSeleccionada = plaza;
	}

	public void SetCadena(string cadena){
		cadenaSeleccionada = cadena;
	}

	public void SetPremio(string premio){
		premioSeleccionado = premio;
	}

}
