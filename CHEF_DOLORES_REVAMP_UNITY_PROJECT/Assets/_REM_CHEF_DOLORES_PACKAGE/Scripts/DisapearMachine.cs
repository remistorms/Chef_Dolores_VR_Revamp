using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisapearMachine : MonoBehaviour {

	public void HideMachine(){
	
		transform.GetComponent<MixerMachine> ().enabled = false;

		DOTween.To (
			()=> transform.parent.transform.localScale,
			x=> transform.parent.transform.localScale = x,
			Vector3.zero,
			0.5f);
	}
}
