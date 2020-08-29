using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dest : MonoBehaviour {

	// Use this for initialization
         float time=0;
	void Start () {
		 Destroy(gameObject,50.0f);
	}
	
	// Update is called once per frame
	void Update () {

        
	}
 void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.name.Equals("Char"))
        {
            if(gameObject.name.Equals("TNT(Clone)"));
            else Destroy(gameObject);
        }
     
    }
}
