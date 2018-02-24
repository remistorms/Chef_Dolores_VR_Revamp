using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerHand : MonoBehaviour {

	public static PlayerHand instance;
	public Transform originalPosition;
	public GameObject held_item;
	public GameObject handMesh;

	void Awake(){
		instance = this;
	}

	//Holds Item
	public void HoldItem(GameObject item){
		StartCoroutine (HoldItemRoutine (item));	
	}

	IEnumerator HoldItemRoutine(GameObject item){

		//Dissables Collider and Hides Outline
		//	fun fact... if you fix this error, player can grab machine too... weird...
			item.GetComponent<Ingredient> ().DisableCollider ();
			item.GetComponent<Ingredient> ().HideOutline ();

		//Tweens hand towards item to grab, objinsight
		DOTween.To (
			() => handMesh.transform.position, 
			x => handMesh.transform.position = x,
			item.transform.position,
			0.5f);
		//Waits until that animation is finished
		yield return new WaitForSeconds (0.5f);

		// Animates hand grab... if time lets us

		//Place Item Inside Hand
		item.transform.SetParent(handMesh.transform);
		held_item = item;
		//Make translucen.... if time lets us

		//Return hand with Item
		DOTween.To (
			() => handMesh.transform.localPosition, 
			x => handMesh.transform.localPosition = x,
			Vector3.zero,
			0.5f);
	}


	//Drops Item
	public void DropItem(){
		StartCoroutine (DropItemRoutine ());

	}

	IEnumerator DropItemRoutine(){
		//Animates towards target
		AnimatesHandTowardsTarget();
	
		yield return new WaitForSeconds (0.5f);

		//disables item collider so player can no longer interact with it
		held_item.GetComponent<Ingredient> ().DisableCollider ();

		//removes item fdrom parent so it stays in machine
		held_item.transform.SetParent(MixerMachine.instance.inputPoint.transform);


		//Return Hand Position
		AnimatesHandReturn();

		//no longer holding item
		yield return new WaitForSeconds (0.5f);

		//Actvate machine receive Ingredient here
		Debug.Log("Here im activating my machine " );
		MixerMachine.instance.ReceiveIngredient(held_item);

		held_item = null;
	}

	void AnimatesHandTowardsTarget(){
		DOTween.To(
			()=> handMesh.transform.position, 
			x=> handMesh.transform.position = x,
			MixerMachine.instance.inputPoint.position,
			0.5f);
	}

	void AnimatesHandReturn(){
		DOTween.To (
			() => handMesh.transform.localPosition, 
			x => handMesh.transform.localPosition = x,
			Vector3.zero,
			0.5f);
	}

}
