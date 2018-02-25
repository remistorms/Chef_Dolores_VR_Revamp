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
	public GameObject buttonMesh;
	public bool canMix = true;

	public float firstSlotMutl, secondSlotMult,thirdSlotMult, fourthSlotMult, fifthSlotMult;
	public float totalPoints = 0;

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
			item.GetComponent<Image> ().enabled = false;
			CheckMachineButton ();
		}
		MeshButtonCheck ();
	}

	//	Method to receive indredient
	public void ReceiveIngredient(GameObject ingredient){
			Debug.Log ("MixerMachine received an ingredient just now");

			//Animates ingredient enterin machine

			//Add ingredient to queue at current Slot
			ingredientsInsideMachine.Add(ingredient);

			//Add sprite to UI
			itemSlotsUI[currentSlot].GetComponent<Image>().enabled = true;
			itemSlotsUI[currentSlot].sprite = ingredientsInsideMachine[currentSlot].GetComponent<Ingredient>().icon;

			//Checks if machine is full
			currentSlot ++;
		CheckMachineButton ();
		MeshButtonCheck ();
			if (currentSlot == 5) {
				isMaxedOut = true;
				MixIngredients ();
			}
	}

	// METHOD TO MIX INGREDIENTS
	public void MixIngredients(){
		StartCoroutine (MixIngredientsRoutine ());
	}

	void CheckMachineButton(){
		Debug.Log (ingredientsInsideMachine.Count.ToString() + " ingredients inside machine");
		if (ingredientsInsideMachine.Count == 0) {
			//machineButton.interactable = false;
			panelCanvas.blocksRaycasts = false;
		} else if (ingredientsInsideMachine.Count >= 2) {
			//machineButton.interactable = true;
			panelCanvas.blocksRaycasts = true;
		}
			
	}

	void MeshButtonCheck(){
		if (ingredientsInsideMachine.Count >= 2) {
			buttonMesh.GetComponent<Collider> ().enabled = true;
			buttonMesh.GetComponent<Renderer> ().material.color = Color.green;
		} 
		else 
		{
			buttonMesh.GetComponent<Collider> ().enabled = false;
			buttonMesh.GetComponent<Renderer> ().material.color = Color.grey;
		}
	}

	//MIX INGREEDIENTS ROUTINE
	IEnumerator	MixIngredientsRoutine(){
		canMix = false;
		float multiplyer = 8;
		List <float> sltPnts = new List<float>();
		float totalProcessTime = 0f;

		//Get points
		for (int i = 0; i < ingredientsInsideMachine.Count; i++) 
		{
			totalProcessTime += ingredientsInsideMachine [i].GetComponent<Ingredient> ().timeToProcess;
			sltPnts.Add(ingredientsInsideMachine[i].GetComponent<Ingredient>().points * multiplyer);
			Debug.Log ("multiplier = " + multiplyer );
			multiplyer = multiplyer / 2;
			totalPoints += sltPnts [i];

		}

		Debug.Log ("Total Waiting time: " + totalProcessTime.ToString());
		yield return new WaitForSeconds (totalProcessTime);
		Debug.Log ("DONE");

	}
}
