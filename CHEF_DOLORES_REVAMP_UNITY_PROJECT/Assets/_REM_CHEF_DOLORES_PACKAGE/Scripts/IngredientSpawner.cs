using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour {

	public static IngredientSpawner instance;

	public GameObject[] ingredientsToSpawn;
	public Transform[] spawningPoints;
	public List<GameObject> spawnedIngredients;

	void Awake(){
		instance = this;
		ClearIngredients ();
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.R)) {
			ClearIngredients ();
			PlaceIngredients ();
		}
	}
	void Start()
	{
		PlaceIngredients ();
	}

	void PlaceIngredients(){
		ClearIngredients ();
		StartCoroutine (SpawnIngredientsRoutine ());
	}

	IEnumerator SpawnIngredientsRoutine(){
		for (int i = 0; i < ingredientsToSpawn.Length; i++) {

			GameObject spawnedIngredient = Instantiate (ingredientsToSpawn [i], spawningPoints [i].position, Quaternion.identity) as GameObject;
			spawnedIngredient.name = spawnedIngredient.GetComponent<Ingredient> ().name;
			spawnedIngredients.Add (spawnedIngredient);
			yield return new WaitForSeconds (0.1f);
		}
	}

	public void ClearIngredients(){
		foreach (var item in spawnedIngredients) {
			Destroy (item);
		}
		spawnedIngredients.Clear ();
	}
}
