using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalMissionScreenController : MonoBehaviour {


	public GameObject nextBtn;
	private bool NextBtnIsActive = false;
	// Use this for initialization
	void Start () {
		disableNextBtn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void enableNextBtn()
	{
		NextBtnIsActive = true;
		nextBtn.GetComponent <UISprite>().color = Color.green;
		nextBtn.GetComponent <UISprite> ().alpha = 1;
	}

	void disableNextBtn()
	{
		NextBtnIsActive = false;
		nextBtn.GetComponent <UISprite>().color = Color.grey;
		nextBtn.GetComponent <UISprite> ().alpha = 0.7f;
	}

	public void onNext()
	{
		if (NextBtnIsActive) {
			TakePhotoController manager = FindObjectOfType <TakePhotoController> ();
			manager.MissionScreenNext ();
		}
		gameObject.SetActive (false);
	}
}
