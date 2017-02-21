using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Adventure1_4 : MonoBehaviour {

	public MediaPlayerCtrl adminVideo;
	public MediaPlayerCtrl adminVideo2;
	public MediaPlayerCtrl adminVideo3;
	public MediaPlayerCtrl chapterVideo;
	public TakePhotoController photoController;
	public GameObject mainUI;
	public GameObject physicalMissionScreen;
	public AudioSource missionSFX;
	// Use this for initialization
	void Start () {
		physicalMissionScreen.SetActive (false);
		adminVideo.OnEnd += onAdminVideoEnded;
		adminVideo2.OnEnd += onAdminVideo2Ended;
		adminVideo3.OnEnd += onAdminVideo3Ended;
		chapterVideo.OnEnd += onChapterVideoEnded;
		adminVideo2.gameObject.SetActive (false);
		adminVideo3.gameObject.SetActive (false);
		//chapterVideo.gameObject.SetActive (false);
	}

	void onAdminVideoEnded()
	{
		adminVideo.Stop ();
		adminVideo.UnLoad ();
		adminVideo.OnEnd -= onAdminVideoEnded;
		mainUI.SetActive (true);
		physicalMissionScreen.SetActive (true);

		playAdminVideo3 ();
		//disableAdminVideo ();
	}

	void onAdminVideo2Ended()
	{
		adminVideo2.Stop ();
		adminVideo2.UnLoad ();
		//adminVideo2.gameObject.SetActive (false);
		adminVideo2.OnEnd -= onAdminVideo2Ended;
		mainUI.SetActive (true);
		photoController.GetImageFromCamera ();
	}

	void onAdminVideo3Ended()
	{
		adminVideo3.Stop ();
		adminVideo3.UnLoad ();
		adminVideo3.OnEnd -= onAdminVideo3Ended;
		adminVideo3.gameObject.SetActive (false);

		mainUI.SetActive (true);
		missionSFX.Play ();
		//photoController.GetImageFromCamera ();
	}

	void disableAdminVideo()
	{
		adminVideo.gameObject.SetActive (false);
	}

	void disableAdminVideo2()
	{
		adminVideo2.gameObject.SetActive (false);
	}

	void playAdminVideo3()
	{
		mainUI.SetActive (false);
		adminVideo3.gameObject.SetActive (true);
		//disableAdminVideo ();
		adminVideo3.Play ();
	}

	void playAdminVideo2()
	{
		missionSFX.Stop ();
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

		Resources.UnloadUnusedAssets ();
		System.GC.Collect ();

		SceneManager.LoadScene ("Adventure1_5");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
