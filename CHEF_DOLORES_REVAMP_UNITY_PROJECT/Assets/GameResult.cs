using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour {

	public static GameResult instance;

	public string insert_premio_url;
	int scoreToWin = 5000;
	public string resultadoJugador;
	public string fullString;

	void Awake(){
		instance = this;
	}

	public void CheckResult(){
	
		switch (DatosJugador.instance.premioSeleccionado) {

			case "VALESDEGASOLINA":
			scoreToWin = 700;
			break;

			case "DIABLITOS":
			scoreToWin = 800;
			break;

			case "TABLET":
			scoreToWin = 900;
			break;

			case "SMARTPHONE":
			scoreToWin = 1000;
			break;

			case "BICICLETAS":
			scoreToWin = 1100;
			break;

			case "BASCULAS":
			scoreToWin = 1200;
			break;

			case "CAJAREGISTRADORA":
			scoreToWin = 1300;
			break;

			case "REBANADORAS":
			scoreToWin = 1400;
			break;

			case "MOTO":
			scoreToWin = 1600;
			break;

		default:
			break;
		}

		if (PostGameUI.instance.playerScore >= scoreToWin) {
			resultadoJugador = "GANO";
		} else {
			resultadoJugador = "PERDIO";
		}

		DatosJugador.instance.resultadoDelJuego = resultadoJugador;
		StartCoroutine (SendResultado ());
	}

	//Get
	IEnumerator SendResultado(){

		fullString = insert_premio_url +

		"n=" + DatosJugador.instance.nombreJugador +
		"&t=" + DatosJugador.instance.ticketJugador +
		"&c=" + DatosJugador.instance.cadenaSeleccionada +
		"&p=" + DatosJugador.instance.premioSeleccionado +
		"&r=" + resultadoJugador +
		"&f=" + System.DateTime.Now.ToString ("yyyyMMdd") +
		"&l=" + PostGameUI.instance.playerScore +
		"&m=" + DatosJugador.instance.montoDeCompra +
		"&a=" + DatosJugador.instance.productosComprados;

		//PETICION
		UnityWebRequest www = UnityWebRequest.Get( fullString
		);

		yield return www.SendWebRequest();
		yield return new WaitForSeconds (1.5f);

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
			//MESSAGE MESSAGE
		}

		else {
			//SNEDS YOU TO POST SCREEN
			yield return new WaitForSeconds(10);
			SceneManager.LoadScene(3);
		}
	}
}
