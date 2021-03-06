using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class notes : MonoBehaviour
{
	public  AudioSource C;
	public  AudioSource Db;
	public  AudioSource D;
	public  AudioSource Eb;
	public  AudioSource E;
	public  AudioSource F;
	public  AudioSource Gb;
	public  AudioSource G;
	public  AudioSource Ab;
	public  AudioSource A;
	public  AudioSource Bb;
	public  AudioSource B;
	public AudioSource Audio;
	public string lastChord;
	bool[] notesDown = new bool[12];// 0: C, 1: Db, 2: D, 3: Eb, 4: E, 5: F, 6: Gb, 7: G, 8: Ab, 9: A, 10: Bb, 11: B
	public bool fsminDone = false;
	public bool bmajDone = false;
	public bool csminDone = false;
	public bool emajDone = false;
	public bool bminDone = false;
	public bool eminDone = false;
	public bool cmajDone = false;
	public bool dmajDone = false;
	public bool dminDone = false;
	public bool bfmajDone = false;
	public bool aminDone = false;
	public bool gmajDone = false;
	public bool fmajDone = false;
	public bool amajDone = false;
	void Start ()
	{
		C = GameObject.Find ("C").GetComponent<AudioSource> ();
		Db = GameObject.Find ("Db").GetComponent<AudioSource> ();
		D = GameObject.Find ("D").GetComponent<AudioSource> ();
		Eb = GameObject.Find ("Eb").GetComponent<AudioSource> ();
		E = GameObject.Find ("E").GetComponent<AudioSource> ();
		F = GameObject.Find ("F").GetComponent<AudioSource> ();
		Gb = GameObject.Find ("Gb").GetComponent<AudioSource> ();
		G = GameObject.Find ("G").GetComponent<AudioSource> ();
		Ab = GameObject.Find ("Ab").GetComponent<AudioSource> ();
		A = GameObject.Find ("A").GetComponent<AudioSource> ();
		Bb = GameObject.Find ("Bb").GetComponent<AudioSource> ();
		B = GameObject.Find ("B").GetComponent<AudioSource> ();
		//playChord (CMajor);
	}
	
	// Update is called once per frame
	void Update ()
	{
		soundOnMultiTouch ();
		if (checkChordAgainstPlayerInput (lastChord)) {
			Debug.Log ("correct:"+lastChord);
			//lastChord = null;
			notesDown = new bool[12];
		}
	}

	void soundOnMultiTouch ()
	{
		for (int i = 0; i < Input.touchCount; i++) {
			AudioSource note; 
			Touch currentTouch = Input.GetTouch (i);
			Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position); 
			Vector2 touchRay2D = new Vector2 (touchWorldPos.x, touchWorldPos.y);
			RaycastHit2D hit = Physics2D.Raycast (touchRay2D, Vector2.zero);
			if (hit) {
				note = hit.collider.gameObject.GetComponent<AudioSource> ();
				if (currentTouch.phase == TouchPhase.Began) {
					playNote (note);
					toggleNoteDown (note);
					note.SetScheduledEndTime (AudioSettings.dspTime + 1.5f);
				} else if (currentTouch.phase != TouchPhase.Began && currentTouch.phase != TouchPhase.Ended) {
					note.SetScheduledEndTime (AudioSettings.dspTime + 1.5f);
				} else if (currentTouch.phase == TouchPhase.Ended && note.time > 1.5f) {
					playNote (note, false);
					toggleNoteDown (note);
				}
				//soundOnClick p = (soundOnClick)hit.collider.gameObject.GetComponent (typeof(soundOnClick));
				//p.playSelf ();
			}
		}
	}
	void toggleNoteDown(AudioSource note){// 0: C, 1: Db, 2: D, 3: Eb, 4: E, 5: F, 6: Gb, 7: G, 8: Ab, 9: A, 10: Bb, 11: B
		switch (note.name) {
		case "C":{
			notesDown[0] = ! notesDown[0];
				break;
			}
		case "Db":{
				notesDown[1] = ! notesDown[1];
				break;
			}
		case "D":{
				notesDown[2] = ! notesDown[2];
				break;
			}
		case "Eb":{
				notesDown[3] = ! notesDown[3];
				break;
			}
		case "E":{
				notesDown[4] = ! notesDown[4];
				break;
			}
		case "F":{
				notesDown[5] = ! notesDown[5];
				break;
			}
		case "Gb":{
				notesDown[6] = ! notesDown[6];
				break;
			}
		case "G":{
				notesDown[7] = ! notesDown[7];
				break;
			}
		case "Ab":{
				notesDown[8] = ! notesDown[8];
				break;
			}
		case "A":{
				notesDown[9] = ! notesDown[9];
				break;
			}
		case "Bb":{
				notesDown[10] = ! notesDown[10];
				break;
			}
		case "B":{
				notesDown[11] = ! notesDown[11];
				break;
			}
		}
	}
	void playNote (AudioSource note, bool play = true)
	{
		//Debug.Log (note);
		if (play) {
			note.Play ();
			Debug.Log (note);
			note.SetScheduledEndTime (AudioSettings.dspTime + 1.5f);
		} else {
			note.Stop ();
		}
	}
	public bool checkChordAgainstPlayerInput(string chord){
		// 0= C, 1= Db, 2= D, 3= Eb, 4= E, 5= F, 6= Gb, 7= G, 8= Ab, 9= A, 10= Bb, 11= B
		bool res = false;

		int downCount = 0;
		foreach (bool n in notesDown) {
			if (n) {
				downCount += 1;
			}
		}

	//	if (downCount != 3) {
	//		return false;
	//	}
		switch (chord) {
		case "CMaj":
				if (notesDown [0] && notesDown [4] && notesDown [7]) {
					res = true;
				cmajDone = true;
				}//ceg
					break;
		case "FMaj":
				if (notesDown [5] && notesDown [9] && notesDown [0]) {
					res = true;
				fmajDone = true;
				}//fac
			break;
		case "GMaj":
				if (notesDown [7] && notesDown [11] && notesDown [2]) {
					res = true;
				gmajDone= true;
				}//gbd

			break;
		case "AMin":
				if (notesDown [9] && notesDown [0] && notesDown [4]) {
					res = true;
				aminDone = true;
				}//ace
			break;

		case "BbMaj":
			if (notesDown [10] && notesDown [2] && notesDown [5]) {
				res = true;
				bfmajDone = true;
			}//Bbdf
			break;
		case "DMin":
			if (notesDown [2] && notesDown [5] && notesDown [9]) {
				res = true;
				dminDone = true;
			}//dfa
			break;
		case "DMaj":
			if (notesDown [2] && notesDown [6] && notesDown [9]) {
				res = true;
				dmajDone = true;
			}//dgba
			break;
		case "AMaj":
			if (notesDown [9] && notesDown [1] && notesDown [4]) {
				res = true;
				amajDone = true;
			}//adbe
			break;
		case "EMin":
			if (notesDown [4] && notesDown [7] && notesDown [11]) {
				res = true;
				eminDone = true;
			}//egb
			break;
		case "BMin":
			if (notesDown [11] && notesDown [2] && notesDown [6]) {
				res = true;
				bminDone = true;
			}//bdgb must be higher
			break;
		case "EMaj":
			if (notesDown [4] && notesDown [8] && notesDown [11]) {
				res = true;
				emajDone = true;
			} //eabb
			break;
		case "C#Min": if (notesDown [1] && notesDown [4] && notesDown [8]) {
				res = true;
				csminDone = true;
			} //dbeab
			break;
		case "BMaj": if (notesDown [6] && notesDown [3] && notesDown [11]) {
				res = true;
				bmajDone = true;
			} //bebgb
			break;
		case "F#Min": if (notesDown [6] && notesDown [9] && notesDown [1]) {
				res = true;
				fsminDone = true;
			} //gbadb
			break;
		default:
			break;	
		}
	
		return res;
	}
	public void playChord (string chord)
	{ // for reference: https://www.piano-keyboard-guide.com/basic-piano-chords.html
		if (lastChord != chord) {
			lastChord = chord;
			Debug.Log ("matching against:" + chord);
			switch (chord) {
			case "CMaj":
				playNote (C);
				playNote (E);
				playNote (G);
				break;
			case "FMaj":
				playNote (F);
				playNote (A);
				playNote (C);
				break;
			case "GMaj":
				playNote (G);
				playNote (B);
				playNote (D);
				break;
			case "AMin":
				playNote (A);
				playNote (C);
				playNote (E);
				break;
			case "BbMaj":
				playNote (Bb);
				playNote (D);
				playNote (F);
				break;
			case "DMin":
				playNote (D);
				playNote (F);
				playNote (A);
				break;
			case "DMaj":
				playNote (D);
				playNote (Gb);
				playNote (A);
				break;
			case "AMaj":
				playNote (A);
				playNote (Db);
				playNote (E);
				break;
			case "EMin":
				playNote (E);
				playNote (G);
				playNote (B);
				break;
			case "BMin":
				playNote (B);
				playNote (D);
				playNote (Gb); //must be higher
				break;
			case "EMaj":
				playNote (E);
				playNote (Ab);
				playNote (B);
				break;
			case "C#Min":
				playNote (Db);
				playNote (E);
				playNote (Ab);
				break;
			case "BMaj":
				playNote (B);
				playNote (Eb);
				playNote (Gb);
				break;
			case "F#Min":
				playNote (Gb);
				playNote (A);
				playNote (Db);
				break;
			default:
				break;	
			}
		}
	}
	public void resetBools(){
		fsminDone = false;
		bmajDone = false;
		csminDone = false;
		emajDone = false;
		bminDone = false;
		eminDone = false;
		cmajDone = false;
		dmajDone = false;
		dminDone = false;
		bfmajDone = false;
		aminDone = false;
		gmajDone = false;
		fmajDone = false;
		amajDone = false;
	}
}
