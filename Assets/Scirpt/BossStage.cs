using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStage : MonoBehaviour {
    public Slider HealthBar;
    public int Health;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HealthBar.value = Health;
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void TakeDamage(int damage) {
        Health -= damage;
    }
}
