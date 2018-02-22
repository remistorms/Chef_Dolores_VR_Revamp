using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BootGO : MonoBehaviour {

	public static BootGO instance;

	void Awake(){
		InitializeBoot ();
	}

	void InitializeBoot(){
		//Makes sure only one BootGO Exists
		if (BootGO.instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
			Debug.Log ("Previously created boot already exists, destroying original one...SAD");
		}
		DontDestroyOnLoad (this.gameObject);
	}
}
