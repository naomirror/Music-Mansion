using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnClick : MonoBehaviour {
    AudioSource self;
	// Use this for initialization
	void Start () {
        self = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void playSelf()
    {
        self.Play();
        self.SetScheduledEndTime(AudioSettings.dspTime + 1.50f);

    }
}
