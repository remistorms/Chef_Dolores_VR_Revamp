using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class IngredientsSetup : MonoBehaviour {

	public string superString;
	public string []ingredientes_puntos;
	public List<string> ingredientes, puntos;
	public string[] separators;

	public string ingredients_url;

	[SerializeField]
	public Dictionary <string, int> ingredientsTable =  new Dictionary<string, int>();

	public void GetIngredients()
	{
		//Shows loading 
		//SecondaryCanvas.instance.ShowLoadingMessage ();
		StartCoroutine(GetIngredientsRoutine());
	}

	//Get
	IEnumerator GetIngredientsRoutine(){

		//PETICION
		UnityWebRequest www = UnityWebRequest.Get( ingredients_url +  

			"&n=" + DatosJugador.instance.nombreJugador +
			"&t=" + DatosJugador.instance.ticketJugador +
			"&c=" + DatosJugador.instance.cadenaSeleccionada
		);

		yield return www.SendWebRequest();
		//yield return new WaitForSeconds (1.5f);

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
			SecondaryCanvas.instance.ShowErrorMessage ("OCURRIO UN ERROR: IG747");
		}
		else {
			Debug.Log ("SI CONECTO");
			Debug.Log (www.downloadHandler.text);
			// Show results as text
			superString = www.downloadHandler.text;

			//separates the long string based on selected separators and stores them inside plazas array
			ingredientes_puntos = superString.Split (separators, System.StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < ingredientes_puntos.Length; i++) 
			{
				//Pares
				if (i % 2 == 0) {
					ingredientes.Add (ingredientes_puntos [i]);
				} 
				//NONES
				else 
				{
					puntos.Add (ingredientes_puntos [i]);
				}
			}

			//Saves the entire dictionary to the Persisten GO
			DatosJuego.instance.datosIngredientes = ingredientsTable;

		}
	}

}
