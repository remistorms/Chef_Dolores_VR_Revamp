using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MixerMachine : MonoBehaviour {

	public int[] multipicadores = new int[4];

	public static MixerMachine instance;
	public Transform inputPoint;
	public List<GameObject> ingredientsInsideMachine; 
	public int currentSlot = 0;
	public bool isMaxedOut = false;
	public CanvasGroup panelCanvas;
	public GameObject buttonMesh;
	public bool canMix = true;
	public MachineAnimations machineController;
	public Transform insideMachine;
	public Transform trayPosition;
	public FinishedDish finishedDishReference;

	public float firstSlotMutl, secondSlotMult,thirdSlotMult, fourthSlotMult, fifthSlotMult;
	public float totalPoints = 0;

	public Color disabledColor, enabledColor;

	Recipies recipiesReference;

	//UI STUFF
	[SerializeField]
	Image[] itemSlotsUI;
	[SerializeField]
	Button machineButton;
	public Transform buttonHoverPosition;
	public Slider processSlider;

	void Awake(){
		instance = this;
		gameObject.tag = "MixerMachine";
		foreach (var item in itemSlotsUI) {
			item.GetComponent<Image> ().enabled = false;

		}
		buttonMesh.GetComponent<Renderer> ().material.color = disabledColor;
		recipiesReference = GetComponent<Recipies> ();
		//MeshButtonCheck ();
	}

	void FixedUpdate(){
		MeshButtonCheck ();
	}

	//	Method to receive indredient
	public void ReceiveIngredient(GameObject ingredient){
			Debug.Log ("MixerMachine received an ingredient just now");

			//Animates ingredient entering machine
		DOTween.To(
			()=> ingredient.transform.position,
			x=> ingredient.transform.position = x,
			insideMachine.transform.position,
			0.2f
		);

		DOTween.To(
			()=> ingredient.transform.localScale,
			x=> ingredient.transform.localScale = x,
			Vector3.zero,
			0.2f
		);

			//Add ingredient to queue at current Slot and to the recipy script
			ingredientsInsideMachine.Add(ingredient);
			recipiesReference.ingredientsGO.Add (ingredient);

			//Add sprite to UI
			itemSlotsUI[currentSlot].GetComponent<Image>().enabled = true;
			itemSlotsUI[currentSlot].sprite = ingredientsInsideMachine[currentSlot].GetComponent<Ingredient>().icon;

			//Checks if machine is full
			currentSlot ++;
			MeshButtonCheck ();
			if (currentSlot == 5) {
				isMaxedOut = true;
				//MixIngredients ();
			}
	}

	// METHOD TO MIX INGREDIENTS
	public void MixIngredients(){

		if (canMix) {
			StartCoroutine (MixIngredientsRoutine ());
		} else {
			Debug.Log ("Mixer is Not ready");
		}

	}


	//MIX INGREEDIENTS ROUTINE
	IEnumerator	MixIngredientsRoutine(){


		canMix = false;
		float multiplyer = 8;
		List <float> sltPnts = new List<float>();
		float totalProcessTime = 0f;
		recipiesReference.GetIngredients ();




		//START ANIMATIONS and show UI
		machineController.ShakeMachine();

		DOTween.To (
			()=> processSlider.value,
			x=> processSlider.value = x,
			1,
			totalProcessTime
		);
		yield return new WaitForSeconds (totalProcessTime);

		//HERE GOES THE CODE TO MAKE THE DISJ AND PUT IT ON BONE
		GetPoints();
		finishedDishReference.CreateDish(ingredientsInsideMachine[1].name);

	
		machineController.DeliverPlate ();


		Debug.Log ("DONE");

		//CLEAR INGREDIENTS
		EmptyMachine();

		canMix = true;

	}

	//Check usability of button
	void MeshButtonCheck(){
		if (ingredientsInsideMachine.Count >= 2 && canMix == true) {
			buttonMesh.GetComponent<Collider> ().enabled = true;
			//buttonMesh.GetComponent<Renderer> ().material.color = enabledColor;

			DOTween.To (
				() => buttonMesh.GetComponent<Renderer> ().material.color,
				x => buttonMesh.GetComponent<Renderer> ().material.color = x,
				enabledColor,
				0.25f);
		} 
		else 
		{
			buttonMesh.GetComponent<Collider> ().enabled = false;
			//buttonMesh.GetComponent<Renderer> ().material.color = disabledColor;
			DOTween.To (
				() => buttonMesh.GetComponent<Renderer> ().material.color,
				x => buttonMesh.GetComponent<Renderer> ().material.color = x,
				disabledColor,
				0.25f);
		}
	}

	void EmptyMachine(){
		
		foreach (var item in ingredientsInsideMachine) {
			Destroy (item);
		}
		//clear ingredients from array
		ingredientsInsideMachine.Clear();

		//delete sprites from UI

		foreach (var item in itemSlotsUI) {
			item.GetComponent<Image> ().enabled = false;
		}
		//resets current slot
		currentSlot = 0;
		totalPoints = 0;

	}


	public void GetPoints(){


		//Debug.Log ("ingredients inside machine:" + ingredientsInsideMachine.Count);

		switch (ingredientsInsideMachine.Count) {

			
			case 2:
			totalPoints = (ingredientsInsideMachine [0].GetComponent<Ingredient> ().points * multipicadores[0]) +
				(ingredientsInsideMachine [1].GetComponent<Ingredient> ().points * multipicadores[1]);
			Debug.Log ("Fired case 2");
			break;

			case 3:
			totalPoints = (ingredientsInsideMachine [0].GetComponent<Ingredient> ().points * multipicadores[0]) +
				(ingredientsInsideMachine [1].GetComponent<Ingredient> ().points * multipicadores[1]) +
				(ingredientsInsideMachine [2].GetComponent<Ingredient> ().points * multipicadores[2]);
			Debug.Log ("Fired case 3");
			break;

			case 4:
			totalPoints = (ingredientsInsideMachine [0].GetComponent<Ingredient> ().points * multipicadores[0]) +
				(ingredientsInsideMachine [1].GetComponent<Ingredient> ().points * multipicadores[1]) +
				(ingredientsInsideMachine [2].GetComponent<Ingredient> ().points * multipicadores[2]) +
				(ingredientsInsideMachine [3].GetComponent<Ingredient> ().points * multipicadores[3]);
			Debug.Log ("Fired case 4");
			break;

			case 5:
			totalPoints = (ingredientsInsideMachine [0].GetComponent<Ingredient> ().points * multipicadores[0]) +
				(ingredientsInsideMachine [1].GetComponent<Ingredient> ().points * multipicadores[1]) +
				(ingredientsInsideMachine [2].GetComponent<Ingredient> ().points * multipicadores[2]) +
				(ingredientsInsideMachine [3].GetComponent<Ingredient> ().points * multipicadores[3]) +
				(ingredientsInsideMachine [4].GetComponent<Ingredient> ().points * multipicadores[4]);
			Debug.Log ("Fired case 5");
			break;

			default:
			break;
		}


		totalPoints = Mathf.RoundToInt (totalPoints);
		Debug.Log ("getting points.... calculating..... points = " + totalPoints);

		//THIS GOES IN CASE SOMETHING BREAKS
		/*for (int i = 0; i < ingredientsInsideMachine.Count; i++) 
		{
			totalProcessTime += ingredientsInsideMachine [i].GetComponent<Ingredient> ().timeToProcess;
			sltPnts.Add(ingredientsInsideMachine[i].GetComponent<Ingredient>().points * multiplyer);
			Debug.Log ("multiplier = " + multiplyer );
			multiplyer = multiplyer / 2;
			totalPoints += sltPnts [i];
		}*/
	}

}
