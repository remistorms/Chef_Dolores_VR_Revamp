using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class PostGameMenu : MonoBehaviour {

	public Text textArea;
	string infoString;

	void OnEnable(){
		StartCoroutine (EndRoutine ());
	}

	IEnumerator EndRoutine(){
	

		ShowPostGameInfo ();

		//Captures screenshot if setup initially
		if (BootGO.instance.takeScreenshots) {
			ScreenCapture.CaptureScreenshot ("CD_Screenshot_" + System.DateTime.Now);
		}
		//Just time to read
		yield return new WaitForSeconds (10);

		//Destroys Boot
		BootGO.instance.DestroyBoot ();

		//Loads first scene
		SceneManager.LoadScene (0);

	}

	void ShowPostGameInfo(){

		XRSettings.enabled = false;

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
			"Resultado: " + DatosJugador.instance.resultadoDelJuego + "\n" +
			"--------------------"
			;

		textArea.text = infoString.ToUpper();

	}
}