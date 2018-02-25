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
	public bool isMaxedOut = false;
	public CanvasGroup panelCanvas;

	//UI STUFF
	[SerializeField]
	Image[] itemSlotsUI;
	[SerializeField]
	Button machineButton;
	public Transform buttonHoverPosition;

	void Awake(){
		instance = this;
		gameObject.tag = "MixerMachine";
		foreach (var item in itemSlotsUI) {
			item.GetComponent<Image> ().sprite = null;
			CheckMachineButton ();
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
		CheckMachineButton ();
			if (currentSlot == 5) {
				isMaxedOut = true;
				MixIngredients ();
			}
	}

	// METHOD TO MIX INGREDIENTS
	public void MixIngredients(){

		Debug.Log ("Mix ingredients");	
		
	}

	void CheckMachineButton(){
		Debug.Log (ingredientsInsideMachine.Capacity.ToString() + " ingredients inside machine");
		if (ingredientsInsideMachine.Capacity == 0) {
			//machineButton.interactable = false;
			panelCanvas.blocksRaycasts = false;
		} else
			//machineButton.interactable = true;
			panelCanvas.blocksRaycasts = true;
	}
}
