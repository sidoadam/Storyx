using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Adventure1_1 : MonoBehaviour {

	// Use this for initialization
	public MediaPlayerCtrl adminVideo;
	public MediaPlayerCtrl chapterVideo;
	public TakePhotoController photoController;
	public GameObject mainUI;

	void Start () {
		adminVideo.OnEnd += onAdminVideoEnded;
		chapterVideo.OnEnd += onChapterVideoEnded;
		mainUI.SetActive (false);
		chapterVideo.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onAdminVideoEnded()
	{
		adminVideo.OnEnd -= onAdminVideoEnded;
		chapterVideo.gameObject.SetActive (true);
		adminVideo.gameObject.SetActive (false);
		mainUI.SetActive (true);
		photoController.GetImageFromCamera ();
	}

	void playChapterVideo()
	{
		adminVideo.gameObject.SetActive (false);
		mainUI.SetActive (false);
		chapterVideo.Play ();
	}

	void onChapterVideoEnded()
	{
		chapterVideo.OnEnd -= onChapterVideoEnded;
		SceneManager.LoadScene ("Adventure1_2");
	}
}
