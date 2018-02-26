using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SphereCollider))]
public class Ingredient : MonoBehaviour {

	public bool esAtunDolores = false;

	public string name;
	public int points;
	public float timeToProcess;
	public Sprite icon;

	//[SerializeField]
	float rotateSpeed = 1f;
	SphereCollider myCollider;
	Vector3 originalScale;
	//public GameObject outlineMesh;


	void OnEnable(){

		name = this.gameObject.name;
		originalScale = transform.localScale;
		myCollider = GetComponent<SphereCollider> ();
		myCollider.radius = 0.5f;
		myCollider.center = new Vector3 (0, 0.5f, 0);
		HideOutline ();
		gameObject.layer = 8;

	}

	void FixedUpdate(){
		transform.RotateAround(Vector3.up, rotateSpeed * Time.deltaTime);
	}

	public void ShowOutline(){
			//outlineMesh.SetActive(true);
			GrowIngredient();
	}

	public void HideOutline(){
		//outlineMesh.SetActive(false);
		ReturnSize();
	}

	public void DisableCollider(){
		myCollider.enabled = false;
	}

	void GrowIngredient(){
		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x,
			new Vector3 (transform.localScale.x + 0.1f,
				transform.localScale.y + 0.1f,
				transform.localScale.z + 0.1f),
			0.3f);
	}

	void ReturnSize(){
		DOTween.To (
			() => transform.localScale,
			x => transform.localScale = x,
			originalScale,
			0.3f);
	}
}
