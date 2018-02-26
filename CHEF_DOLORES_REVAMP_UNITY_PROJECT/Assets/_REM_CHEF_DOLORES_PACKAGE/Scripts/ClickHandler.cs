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

			//BEST DEBUGGER
			Debug.Log ("Player has clicked on " + RemCaster.instance.obj_in_sight.name + "; item in hand = " + IsHoldingItem().ToString());

			//Checks if there is an object in sight
			if (RemCaster.instance.obj_in_sight != null) {
				
				GameObject clicked = RemCaster.instance.obj_in_sight;

				switch (clicked.tag) {
					//CASES
					case "ingredient":
					if (IsHoldingItem() == false) {
						PlayerHand.instance.HoldItem (clicked);
					}
					break;

					case "MixerMachine":
					if (IsHoldingItem() == true) {
						PlayerHand.instance.DropItem ();
					}
					break;


					case "trash":
					break;


					case "FinishedDish":
					//Debug.Log ("Player has clicked on MixerMachine; Object in hand=" + hasItem.ToString());
					//IF HAS ITEM; PLACE IT ON MACHINE
					if (IsHoldingItem() == false) {
						Debug.Log ("CLicking on finished dish");
						clicked.GetComponent<FinishedDish> ().GrabDish ();
					}
					break;


					default:
					break;
				}

			}
		}
	}

	bool IsHoldingItem(){
		if (PlayerHand.instance.held_item == null) {
			return false;	
		} else {
			return true;
		}
	}
}
