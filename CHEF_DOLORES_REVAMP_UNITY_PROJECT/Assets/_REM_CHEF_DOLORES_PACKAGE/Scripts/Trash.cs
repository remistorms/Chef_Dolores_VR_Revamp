using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {


	Animator trashAnimator;
	void Awake(){
		trashAnimator = GetComponentInChildren<Animator> ();
	}

	public void OpenLid(){
		trashAnimator.SetBool ("isLidOpen", true);
	}
	public void CloseLid(){
		trashAnimator.SetBool ("isLidOpen", false);
	}
}
