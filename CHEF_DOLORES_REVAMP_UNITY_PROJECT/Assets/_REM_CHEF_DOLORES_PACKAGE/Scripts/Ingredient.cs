using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

	public string name;
	public int points;
	public Sprite icon;
	public GameObject outlineMesh;

	void OnEnable(){
		HideOutline ();
		gameObject.layer = 8;
	}

	public void ShowOutline(){
			outlineMesh.SetActive(true);
	}

	public void HideOutline(){
		outlineMesh.SetActive(false);
	}

	public void DisableCollider(){
		GetComponent<Collider> ().enabled = false;
	}
}
