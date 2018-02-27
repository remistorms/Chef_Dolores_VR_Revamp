using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class ManagerWeb : MonoBehaviour {

	public static ManagerWeb instance;

	public string get_premio_url = "http://www.ispinnova.com.mx/app/get_premios.php?";
	public string insert_premio_url = "http://www.ispinnova.com.mx/app/insert_premio.php?";

	public string plazasString;
	public List<string> plazaList;
	public string[] stringSeparators = new string[] {",", " ", "."};

	public string stringToSplit;

	public string phrase = "The quick  brown fox, jumped over the fence and ate a small cute chicken...";
	public string[] words;

		public void Initialize()
	{
		instance = this;
	}
		
	void Start(){
		//StartCoroutine (GetText());
		Split ();
	}

	IEnumerator GetText(){
		UnityWebRequest www = UnityWebRequest.Get("http://www.ispinnova.com.mx/app/get_premios.php?");
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			Debug.Log(www.downloadHandler.text);

			// Or retrieve results as binary data
			byte[] results = www.downloadHandler.data;

		}
	}

	public void Split(){
	
		

		words = phrase.Split(stringSeparators, System.StringSplitOptions.RemoveEmptyEntries);


		//words = phrase.Split((string[]) null, StringSplitOptions.RemoveEmptyEntries);

		//words = phrase.Split(null as string[], StringSplitOptions.RemoveEmptyEntries);

	}

}
