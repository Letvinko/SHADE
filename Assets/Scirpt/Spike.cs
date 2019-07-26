using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var plyr = collision.GetComponent<MovementPlayer>();
        if (collision.tag == "Player") {
            plyr.Heakth = 0;
        }
    }
}
