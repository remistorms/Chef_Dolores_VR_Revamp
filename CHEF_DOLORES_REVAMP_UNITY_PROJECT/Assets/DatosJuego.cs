using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJuego : MonoBehaviour {

	public static DatosJuego instance;

	public List<int> ingredientsValues;

	//public Dictionary<string, int> datosIngredientes;

	void Awake(){
		instance = this;
	}


}
