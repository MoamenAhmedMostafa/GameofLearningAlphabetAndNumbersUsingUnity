using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ValueAudioChange : MonoBehaviour {
    AudioSource src;
    public Image img;
    public Sprite[] spr;
    private float MusicVolume = 0.1f;
	// Use this for initialization
	void Start ()
    {
        src = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        src.volume = MusicVolume;
	}
    public  void SetVolume(float vol)
    {

        MusicVolume = vol;
        if (MusicVolume == 0)
        {
            img.sprite = spr[1];
        }
        else
        {
            img.sprite = spr[0];
        }
    }
}
