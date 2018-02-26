using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedDish : MonoBehaviour {

	public float dishPoints;
	float sum = 0;
	public bool containsTuna;
	public GameObject hamburguesa, sandwich, ensalada, tortitasDePapa, jitomateRelleno, bolasDeArroz;
	public Text dishPointsLabel;

	public int[] multipicadores;

	void Awake(){
		DisableAllDishes ();
	}
	public void CreateDish(string mainIngredient){
	
		//disables all, starts from scratch
		DisableAllDishes();

		//Select type, based on infredient from 2nd slot
		SelectMain(mainIngredient);

		//Set the value
		if (CheckForTuna() == true) {
			dishPoints = MixerMachine.instance.totalPoints;
		} else {
			dishPoints = 0;
		}

		//Display Text in UI Canvas
		
		dishPointsLabel.text = "<size=25><color=#0096ff>"+dishPoints + "</color></size>" + "PTS";

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
			tortitasDePapa.SetActive (true);
			break;

		default:
			ensalada.SetActive (true);
			break;
		}
	}

	void GetDishValue(){

		int totalIngredients = MixerMachine.instance.ingredientsInsideMachine.Count;
	}
			
	bool CheckForTuna(){
		
		foreach (var item in MixerMachine.instance.ingredientsInsideMachine) {
			if (item.GetComponent<Ingredient> ().esAtunDolores) {
				containsTuna = true;
				return containsTuna;
			} else {
				containsTuna = false;
			}

		}

		return containsTuna;
	}
}
