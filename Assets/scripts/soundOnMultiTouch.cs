using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnMultiTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position); 
				Vector2 touchRay2D = new Vector2 (touchWorldPos.x, touchWorldPos.y);
				RaycastHit2D hit = Physics2D.Raycast (touchRay2D, Vector2.zero);
				if (hit) {
					Debug.Log (hit.collider.gameObject.name);
					soundOnClick p = (soundOnClick)hit.collider.gameObject.GetComponent (typeof(soundOnClick));
					p.playSelf ();
				}
			}
		}
	}
}
