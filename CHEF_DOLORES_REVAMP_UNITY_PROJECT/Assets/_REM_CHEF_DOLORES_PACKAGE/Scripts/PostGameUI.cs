using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PostGameUI : MonoBehaviour {

	public static PostGameUI instance;
	public Image clockImage;
	public Text pointsLabel, pointsLabelb;
	public int playerScore = 0;

	public GameObject[] inGamePanels;

	void Awake(){
		instance = this;
		DisableInGamePanels ();
		inGamePanels [0].SetActive (true);

	}

	void Start(){
		StartTimer ();

	}

	void StartTimer(){
		pointsLabel.text = "0";
		pointsLabelb.text = "0";
		StartCoroutine (TimerRoutine ());
	}

	public void UpdateScore(int points){

		playerScore += points;
		pointsLabel.text = playerScore.ToString ();
		pointsLabelb.text = playerScore.ToString ();
	}

	IEnumerator TimerRoutine(){

		DOTween.To (
			() => clockImage.fillAmount,
			x => clockImage.fillAmount = x,
			0f,
			120);
		
		yield return new WaitForSeconds (118);

		MixerMachine.instance.transform.GetComponent<DisapearMachine> ().HideMachine ();

		DisableInGamePanels ();
		inGamePanels [1].SetActive (true);

		//SWITCH SCENE
	}

	void DisableInGamePanels(){
		foreach (var item in inGamePanels) {
			item.SetActive (false);
		}
	}
}
