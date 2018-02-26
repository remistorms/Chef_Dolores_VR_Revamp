using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedDish : MonoBehaviour {

	public float dishPoints;
	float sum = 0;
	public GameObject hamburguesa, sandwich, ensalada, tortitasDePapa, jitomateRelleno, bolasDeArroz;

	void Awake(){
		DisableAllDishes ();
	}
	public void CreateDish(string mainIngredient){
	
		//disables all, starts from scratch
		DisableAllDishes();

		//Select type, based on infredient from 2nd slot
		SelectMain(mainIngredient);

		//Set the value
		GetDishValue();

		//Display Text in UI Canvas

	}

	void DisableAllDishes(){
		hamburguesa.SetActive (false);
		sandwich.SetActive (false);
		tortitasDePapa.SetActive (false);
		ensalada.SetActive (false);
		jitomateRelleno.SetActive (false);
		bolasDeArroz.SetActive (false);
	}

	void SelectMain(string selected)
	{
		switch (selected) {

		case "arroz":
			bolasDeArroz.SetActive (true);
			break;

		case "bollos":
			hamburguesa.SetActive (true);
			break;

		case "pan":
			sandwich.SetActive (true);
			break;

		case "jitomate":
			jitomateRelleno.SetActive (true);
			break;

		case "papas":
			hamburguesa.SetActive (true);
			break;

		default:
			ensalada.SetActive (true);
			break;
		}
	}

	void GetDishValue(){
		for (int i = 0; i < MixerMachine.instance.ingredientsInsideMachine.Count; i++) {
			sum = sum + MixerMachine.instance.ingredientsInsideMachine [i].GetComponent<Ingredient> ().points;
		}
		dishPoints = sum;
	}

}
