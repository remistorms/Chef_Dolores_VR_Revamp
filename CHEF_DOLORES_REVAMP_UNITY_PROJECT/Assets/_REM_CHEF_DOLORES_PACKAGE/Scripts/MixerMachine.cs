using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MixerMachine : MonoBehaviour {

	public static MixerMachine instance;
	public Transform inputPoint;
	public List<GameObject> ingredientsInsideMachine; 
	public int currentSlot = 0;

	//UI STUFF
	[SerializeField]
	Image[] itemSlotsUI;

	void Awake(){
		instance = this;
		gameObject.tag = "MixerMachine";
		foreach (var item in itemSlotsUI) {
			item.GetComponent<Image> ().sprite = null;
		}
	}

	//	Method to receive indredient
	public void ReceiveIngredient(GameObject ingredient){
			Debug.Log ("MixerMachine received an ingredient just now");

			//Animates ingredient enterin machine

			//Add ingredient to queue at current Slot
			ingredientsInsideMachine.Add(ingredient);

			//Add sprite to UI
			itemSlotsUI[currentSlot].sprite = ingredientsInsideMachine[currentSlot].GetComponent<Ingredient>().icon;

			//Checks if machine is full
			currentSlot ++;
	}

	// METHOD TO MIX INGREDIENTS
	public void MixIngredients(){
		
	}
}
