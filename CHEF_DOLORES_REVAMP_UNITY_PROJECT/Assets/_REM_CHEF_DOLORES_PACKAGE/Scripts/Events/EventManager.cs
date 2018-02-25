using UnityEngine;
using System.Collections;
using System;

public class EventManager : MonoBehaviour {

	public static EventManager instance;

	//THIS ARE THE EVENTS
	public Action EVT_Button_Pressed;
	public Action<Collider2D> EVT_Bullet_Hit;
	public Action EVT_Enemy_Destroyed;
	public Action<GameObject> EVT_LookingAtObject;
	public Action EVT_MouseClick;
	public Action EVT_HoverOverButton;

	void Awake () 
	{
		instance = this;
	}


	public void Fire_EVT_MouseCLick(){
		if (EVT_MouseClick != null) {
			
		}
	}

	public void Fire_EVT_Button_Pressed()
	{
		if (EVT_Button_Pressed != null) 
		{
			Debug.Log ("Event: 'EVT_Button_Pressed' has been fired");
			EVT_Button_Pressed ();
		}
	}

	public void Fire_EVT_BulletHit(Collider2D other)
	{
		if (EVT_Bullet_Hit != null) 
		{
			EVT_Bullet_Hit (other);	
		}
	}

	public void Fire_EVT_Enemy_Destroyed()
	{
		if (EVT_Enemy_Destroyed != null) 
		{
			Debug.Log("EVT_Enemy_Destroyed has been triggered");
			EVT_Enemy_Destroyed ();	
		}
	}

	public void Fire_EVT_HoverOverButton(){
		if (EVT_HoverOverButton != null) 
		{
			Debug.Log("Fire_EVT_HoverOverButton");
			EVT_HoverOverButton ();
		}
	}

}