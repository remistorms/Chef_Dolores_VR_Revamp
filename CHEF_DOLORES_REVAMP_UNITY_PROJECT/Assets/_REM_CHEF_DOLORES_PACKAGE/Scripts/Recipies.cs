using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipies : MonoBehaviour {

	public List<GameObject> ingredientsGO;
	public List<Ingredient> ingredientsSC;
	public int totalIngredients = 0;
	public GameObject sandwich, burguer, riceball, tortitas, jitomateRelleno;

	//Clears lists
	public void ClearLists(){
		ingredientsGO.Clear ();
		ingredientsSC.Clear ();
	}

	public void GetIngredients(){
		for (int i = 0; i < ingredientsGO.Count; i++) {
			ingredientsSC.Insert (i, ingredientsGO [i].GetComponent<Ingredient> ());
			totalIngredients++;
		}
	}

}
