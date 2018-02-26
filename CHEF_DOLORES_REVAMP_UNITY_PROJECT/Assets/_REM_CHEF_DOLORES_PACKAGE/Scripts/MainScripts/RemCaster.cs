using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemCaster : MonoBehaviour {

	public static RemCaster instance;

	public GameObject obj_in_sight;
	RaycastHit myHit, machineHit;
	public LayerMask machineLayer, itemsLayer;
	public bool machineInSight = false;

	void Start(){
		instance = this;
	}
	void Update(){
		
		ShootRay ();
		ShootRayMachineLayer ();
		//CLICKS FOR ITEM
		//ClickOnItem ();
		//CLICKS FOR MACHINE
		ClickHandler.instance.CheckClickProperties();
	}

	void ShootRay(){
		Ray myRay = new Ray (transform.position, transform.forward);

			//THERE IS AN ITEM IN SIGHT
			if (Physics.Raycast (myRay, out myHit, 20, itemsLayer)) {
				obj_in_sight = myHit.collider.gameObject;
			} 
			//NOTHING IN SIGHT
			else {
			obj_in_sight = null;
			}
			
		}

	void ShootRayMachineLayer(){

		Ray myRay = new Ray (transform.position, transform.forward);

		////MIXER MACHINE RAYCASTER
		/// 
		//PLAYER IS LOOKING AT MACHINE WITH EMPTY HANDS
		if (Physics.Raycast (myRay, out machineHit, 20, machineLayer) && PlayerHand.instance.held_item == null) {
			//Debug.Log("Player is looking at machine while NOT holding an item");
			obj_in_sight = machineHit.collider.gameObject;

			//Player clicks on mouse button
			if (Input.GetMouseButtonDown(0)) {
				//Debug.Log("Player is clicking at machine while NOT holding an item");	
			}
		} 

		//PLAYER IS LOOKING AT MACHINE WHILE HOLDING AN ITEM
		if (Physics.Raycast (myRay, out machineHit, 20, machineLayer) && PlayerHand.instance.held_item != null) {
			Debug.Log("Player is looking at machine while holding an item");
			obj_in_sight = machineHit.collider.gameObject;
			//Player clicks on mouse button
			if (Input.GetMouseButtonDown(0)) {
				Debug.Log("Player is clicking at machine while holding " + PlayerHand.instance.held_item.name);	
			}
		} 

	}

		
	void ClickOnItem(){
		//Player clicks-on mouse when not holding an item in hand
		if (Input.GetMouseButtonDown(0) && PlayerHand.instance.held_item == null && obj_in_sight != null) {
			Debug.Log ("Grabbing " + obj_in_sight.name);
			PlayerHand.instance.HoldItem (obj_in_sight);
		}

		//Player clicks-on mouse when holding an item in hand, also checks if machines is not maxed out
		if (Input.GetMouseButtonDown(0) && PlayerHand.instance.held_item != null && obj_in_sight.tag == "MixerMachine" && MixerMachine.instance.isMaxedOut == false) {

			PlayerHand.instance.DropItem ();
		}
			
	}
		
}
