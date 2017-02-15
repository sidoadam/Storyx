using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Adventure1_4 : MonoBehaviour {

	public MediaPlayerCtrl adminVideo;
	public MediaPlayerCtrl adminVideo2;
	public MediaPlayerCtrl chapterVideo;
	public TakePhotoController photoController;
	public GameObject mainUI;
	public GameObject physicalMissionScreen;
	// Use this for initialization
	void Start () {
		physicalMissionScreen.SetActive (false);
		adminVideo.OnEnd += onAdminVideoEnded;
		adminVideo2.OnEnd += onAdminVideo2Ended;
		chapterVideo.OnEnd += onChapterVideoEnded;
		adminVideo2.gameObject.SetActive (false);
		//chapterVideo.gameObject.SetActive (false);
	}

	void onAdminVideoEnded()
	{
		adminVideo.OnEnd -= onAdminVideoEnded;
		mainUI.SetActive (true);
		physicalMissionScreen.SetActive (true);
		//disableAdminVideo ();
	}

	void onAdminVideo2Ended()
	{
		//adminVideo2.gameObject.SetActive (false);
		adminVideo2.OnEnd -= onAdminVideo2Ended;
		mainUI.SetActive (true);
		photoController.GetImageFromCamera ();
	}

	void disableAdminVideo()
	{
		adminVideo.gameObject.SetActive (false);
	}

	void disableAdminVideo2()
	{
		adminVideo2.gameObject.SetActive (false);
	}

	void playAdminVideo2()
	{
		mainUI.SetActive (false);
		adminVideo2.gameObject.SetActive (true);
		disableAdminVideo ();
		adminVideo2.Play ();
	}

	void playChapterVideo()
	{
		adminVideo2.gameObject.SetActive (false);
		chapterVideo.gameObject.SetActive (true);
		disableAdminVideo ();
		chapterVideo.Play ();
	}

	void enableNextBtn()
	{
		physicalMissionScreen.SendMessage ("enableNextBtn");
	}

	public void onChapterVideoEnded()
	{
		chapterVideo.OnEnd -= onChapterVideoEnded;
		SceneManager.LoadScene ("Adventure1_5");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
