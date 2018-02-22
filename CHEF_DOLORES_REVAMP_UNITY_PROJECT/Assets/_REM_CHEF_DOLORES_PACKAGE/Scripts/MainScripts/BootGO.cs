using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class BootGO : MonoBehaviour {

	public static BootGO instance;

	void Awake(){
		InitializeBoot ();
		DisableVR ();
		SceneManager.LoadScene (1);
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

	public void DisableVR(){
		XRSettings.enabled = false;
	}

	public void EnableVR(){
		XRSettings.enabled = true;
	}
}
