﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour {



	public string nombreJugador;
	[SerializeField]
	string ticketJugador; 
	[SerializeField]
	string productosComprados; 
	[SerializeField]
	float montoDeCompra; 
	[SerializeField]
	string plazaSeleccionada; 
	[SerializeField]
	string cadenaSeleccionada; 
	[SerializeField]
	string premioSeleccionado;
	[SerializeField]
	int puntosObtenidos;


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
