using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    //Vector3 localscale;
    private Transform healthBar;

	// Use this for initialization
	void Start () {
        healthBar = transform.Find("Bar");
	}
	
	// Update is called once per frame
	public void Setsize (float sizeNormalized ) {
        healthBar.localScale = new Vector3(sizeNormalized,1f);
	}
}
