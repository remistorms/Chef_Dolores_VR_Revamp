using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class ManagerWeb : MonoBehaviour {

	public static ManagerWeb instance;

		public void Initialize()
	{
		instance = this;
	}
		
	void Start(){

	}

	IEnumerator GetResponse(string url){
		UnityWebRequest www = UnityWebRequest.Get(url);
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			Debug.Log(www.downloadHandler.text);
		}
	}

	public static IEnumerator<string> GetServerData(string url){
	
		UnityWebRequest www = UnityWebRequest.Get(url);
		//yield return www.SendWebRequest();
		yield return www.downloadHandler.text;

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			//Debug.Log(www.downloadHandler.text);
			//return www.downloadHandler.text;
			Debug.Log("Connection success");
		}
	}
}
