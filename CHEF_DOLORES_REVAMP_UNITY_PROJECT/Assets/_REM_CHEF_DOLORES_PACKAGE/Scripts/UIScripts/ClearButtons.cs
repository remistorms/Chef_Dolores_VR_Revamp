using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearButtons : MonoBehaviour {

	public void DeleteButtons(){
		for (int i = 0; i < transform.childCount; i++) {
			Destroy (transform.GetChild (i).gameObject);
		}
	}
}
