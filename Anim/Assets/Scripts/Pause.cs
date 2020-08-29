using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    //public Panel p;
    // Use this for initialization
    public static bool paused = false;
    public GameObject Panel;
    void Start () {
		
	}	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                Time.timeScale = 1;
                Panel.gameObject.SetActive(false);
            }

            else
            {
                Time.timeScale = 0;
                Panel.gameObject.SetActive(true);
            }
                paused = !paused;
        }
    }
}
