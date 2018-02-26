using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

	public static ClickHandler instance;

	void Awake(){
		instance = this;
	}

	void CheckClickProperties(){
	
		if (Input.GetMouseButtonDown(0)) {
			//Checks if there is an object in sight
			if (RemCaster.instance.obj_in_sight != null) {
				Debug.Log ("Player has clicked on something");
				GameObject clicked = RemCaster.instance.obj_in_sight;

				switch (clicked.tag) {
				//CASES
					case "ingredient":
					break;

					case "trash":
					break;

					case "machine":
					break;


					default:
					break;
				}

			}
		}
	}
}
