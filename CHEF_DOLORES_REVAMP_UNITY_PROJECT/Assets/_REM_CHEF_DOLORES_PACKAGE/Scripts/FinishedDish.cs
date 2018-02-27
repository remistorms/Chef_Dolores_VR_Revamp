using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FinishedDish : MonoBehaviour {

	public static FinishedDish instance;

	public float dishPoints;
	float sum = 0;
	public bool containsTuna;
	public GameObject hamburguesa, sandwich, ensalada, tortitasDePapa, jitomateRelleno, bolasDeArroz;
	public Text dishPointsLabel;
	Vector3 originalScale;

	public int[] multipicadores;

	void Awake(){
		instance = this;
		DisableAllDishes ();
		DisableDishCollider ();
		originalScale = transform.localScale;
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

	public void EnableDishCollider(){
		GetComponent<Collider> ().enabled = true;
	}

	public void DisableDishCollider(){
		GetComponent<Collider> ().enabled = false;
	}

	public void CollectDish(){
		StartCoroutine (CollectDishRoutine ());
	}

	IEnumerator CollectDishRoutine()
	{
		PostGameUI.instance.UpdateScore (Mathf.FloorToInt( dishPoints));
		//Disapear and shirnk
		DisableDishCollider();

		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x,
			Vector3.zero,
			0.25f);
		yield return new WaitForSeconds (0.5f);
		 
		//Reset Machine Animation
		//MixerMachine.instance.machineController.machineAnimator.SetTrigger("resetMachine");
		MixerMachine.instance.ResetMachine();
		yield return new WaitForSeconds (2f);
		transform.localScale = originalScale;
	}
}
