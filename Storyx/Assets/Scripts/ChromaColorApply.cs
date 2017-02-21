using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaColorApply : MonoBehaviour {

	UITexture t;

	bool isSet = false;
	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent <UITexture>();
	}

	void OnEnable()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		if (t.drawCall != null) {
			if (!isSet) {
				//isSet = true;
				t.drawCall.dynamicMaterial.SetColor ("_KeyColor",MainDataHolder.currentChromaColor);
			}
		}
	}
}
