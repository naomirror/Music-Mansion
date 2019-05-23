using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accuracy : MonoBehaviour {
	public float accuracyScore = 100.0f;
	public float notesHit = 0.0f;
	public float notesTotal = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float calculatedAccuracy(){
			Debug.Log ("ratio:" + notesHit.ToString() + "/" +notesTotal.ToString());
		if (notesTotal > 0) {
			accuracyScore = 100 * (notesHit / notesTotal);
		} else {
			accuracyScore = 100;
		}
		    Debug.Log("acc"+Mathf.Round(accuracyScore));
	return Mathf.Round(accuracyScore);
}
}