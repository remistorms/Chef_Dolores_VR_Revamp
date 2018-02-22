using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour {

	private RectTransform panelRectTransform;
	private CanvasGroup panelCanvasGroup;
	private float transitionTime = 0.5f;
	public Image backgroundImageGuide;
	public bool isHomeMenu = false;

	void Awake(){
		backgroundImageGuide.enabled = false;
		panelRectTransform = GetComponent<RectTransform> ();
		panelCanvasGroup = GetComponent<CanvasGroup> ();
		panelRectTransform.offsetMin = panelRectTransform.offsetMax = new Vector2(1920,0);
		panelCanvasGroup.interactable = false;
		panelCanvasGroup.alpha = 0;

		if (isHomeMenu) {
			panelRectTransform.offsetMin = panelRectTransform.offsetMax = new Vector2(0,0);
			panelCanvasGroup.interactable = true;
			panelCanvasGroup.alpha = 1;
		}

	}

	//SLIDE TRANSITIONS
	#region transitions

		public void SlideInFromLeft(){

			panelRectTransform.offsetMax = panelRectTransform.offsetMin = new Vector2 (-1920, 0);
			panelCanvasGroup.alpha = 0;
			panelCanvasGroup.interactable = false;

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMax, 
				x=> panelRectTransform.offsetMax = x,
				new Vector2(0, 0),
				transitionTime
			);

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMin, 
				x=> panelRectTransform.offsetMin = x,
				new Vector2(0, 0),
				transitionTime
			);

			DOTween.To(

				()=> panelCanvasGroup.alpha,
				x=> panelCanvasGroup.alpha = x, 
				1,
				0.5f
			);

			panelCanvasGroup.interactable = true;
		}

		public void SlideInFromRight(){

			panelRectTransform.offsetMax = panelRectTransform.offsetMin = new Vector2 (1920, 0);
			panelCanvasGroup.alpha = 0;
			panelCanvasGroup.interactable = false;

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMax, 
				x=> panelRectTransform.offsetMax = x,
				new Vector2(0, 0),
				transitionTime
			);

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMin, 
				x=> panelRectTransform.offsetMin = x,
				new Vector2(0, 0),
				transitionTime
			);

			DOTween.To(

				()=> panelCanvasGroup.alpha,
				x=> panelCanvasGroup.alpha = x, 
				1,
				0.5f
			);

			panelCanvasGroup.interactable = true;
		}

		public void SlideOutToLeft(){

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMax, 
				x=> panelRectTransform.offsetMax = x,
				new Vector2(-1920, 0),
				transitionTime
			);

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMin, 
				x=> panelRectTransform.offsetMin = x,
				new Vector2(-1920, 0),
				transitionTime
			);

			DOTween.To(
			
				()=> panelCanvasGroup.alpha,
				x=> panelCanvasGroup.alpha = x, 
				0,
				0.5f
			);

			panelCanvasGroup.interactable = false;
		}

		public void SlideOutToRight(){

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMax, 
				x=> panelRectTransform.offsetMax = x,
				new Vector2(1920, 0),
				transitionTime
			);

			DOTween.To (

				//DOTWEEN for OFFSET MAX
				()=> panelRectTransform.offsetMin, 
				x=> panelRectTransform.offsetMin = x,
				new Vector2(1920, 0),
				transitionTime
			);

			DOTween.To(

				()=> panelCanvasGroup.alpha,
				x=> panelCanvasGroup.alpha = x, 
				0,
				0.5f
			);

			panelCanvasGroup.interactable = false;
		}

	#endregion
}
