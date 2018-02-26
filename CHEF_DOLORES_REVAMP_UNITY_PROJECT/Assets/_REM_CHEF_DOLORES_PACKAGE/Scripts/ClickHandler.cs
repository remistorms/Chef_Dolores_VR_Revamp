using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

	public static ClickHandler instance;

	void Awake(){
		instance = this;
	}

	public void CheckClickProperties(){
	
		if (Input.GetMouseButtonDown(0)) {
			//Debug.Log ("Player has clicked on something.... checkingClickProperties method...");
			bool hasItem = IsHoldingItem ();


			if (RemCaster.instance.obj_in_sight != null) {
				//Debug.Log ("Player has clicked on something");
				GameObject clicked = RemCaster.instance.obj_in_sight;

				switch (clicked.tag) {
				//CASES
					case "ingredient":
					//Debug.Log ("Player has clicked on ingredient; Object in hand=" + hasItem.ToString());
						
						//IF HAS NO ITEM IN HAND GRAB ITEM
						if (hasItem == false) {
						PlayerHand.instance.HoldItem (clicked);
						}

					break;

					case "trash":
					Debug.Log ("Player has clicked on trash; Object in hand=" + hasItem.ToString());
					break;

					case "MixerMachine":
					//Debug.Log ("Player has clicked on MixerMachine; Object in hand=" + hasItem.ToString());
						//IF HAS ITEM; PLACE IT ON MACHINE
					if (hasItem == true) {
						StartCoroutine (DropItemInsideMachine ());
						}
					break;


					default:
					Debug.Log ("Clickin on something else!!!");
					break;
				}

			}
		}
	}

	public bool IsHoldingItem(){
		//Checks if there is an item in hand
		bool boolValue;
		if (PlayerHand.instance.held_item != null) {
			//Debug.Log ("item in hand = " + true);
			boolValue = true;
		} else {
			//Debug.Log ("item in hand = " + false);
			boolValue = false;
		}
		return boolValue;
	}

	IEnumerator DropItemInsideMachine(){
		PlayerHand.instance.DropItem ();
		yield return new WaitForSeconds (0.5f);
		//MixerMachine.instance.ReceiveIngredient (PlayerHand.instance.held_item);
	}
}
