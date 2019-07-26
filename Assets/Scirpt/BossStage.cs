using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStage : MonoBehaviour {
    public static int Health;
    public int health;
    [SerializeField]
    private HealthBar HB;

    // Use this for initialization
    void Start () {
        health = 10;
	}
	
	// Update is called once per frame
	void Update () {
        Health = health;		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health < 1) {
            Destroy(this.gameObject);
        }               
    }
}
