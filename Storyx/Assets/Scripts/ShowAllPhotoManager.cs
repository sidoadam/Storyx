using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAllPhotoManager : MonoBehaviour {

	// Use this for initialization
	public int photoCount = 1;
	public GameObject target;
	public GameObject scenarioObject;

	private int currentSection = 0;

	void Start () {
		animateContainer ();	
	}

	void animateContainer()
	{
		TweenPosition.Begin (target, 1, new Vector3(-2100*(currentSection+1),0)).delay =  3;
		Invoke ("finishAnimate",4.1f);
	}

	void finishAnimate()
	{
		if (currentSection < photoCount - 2) {
			currentSection++;
			animateContainer ();
		} else {
			scenarioObject.SendMessage ("onPlayChapter");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
