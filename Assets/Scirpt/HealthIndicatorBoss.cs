using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicatorBoss : MonoBehaviour {
    public int healthInfo;

    public GameObject health10;
    public GameObject health9;
    public GameObject health8;
    public GameObject health7;
    public GameObject health6;
    public GameObject health5;
    public GameObject health4;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    public GameObject health0;
    public GameObject tempHealth;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthInfo = BossStage.Health;

        if (healthInfo == 10) {
            health10.SetActive(true);
            tempHealth = health10;
        }
        if (healthInfo == 9)
        {
            tempHealth.SetActive(false);
            health9.SetActive(true);
            tempHealth = health9;
        }
        if (healthInfo == 8)
        {
            tempHealth.SetActive(false);
            health8.SetActive(true);
            tempHealth = health8;
        }
        if (healthInfo == 7)
        {
            tempHealth.SetActive(false);
            health7.SetActive(true);
            tempHealth = health7;
        }
        if (healthInfo == 6)
        {
            tempHealth.SetActive(false);
            health6.SetActive(true);
            tempHealth = health6;
        }
        if (healthInfo == 5)
        {
            tempHealth.SetActive(false);
            health5.SetActive(true);
            tempHealth = health5;
        }
        if (healthInfo == 4)
        {
            tempHealth.SetActive(false);
            health4.SetActive(true);
            tempHealth = health4;
        }
        if (healthInfo == 3)
        {
            tempHealth.SetActive(false);
            health3.SetActive(true);
            tempHealth = health3;
        }
        if (healthInfo == 2)
        {
            tempHealth.SetActive(false);
            health2.SetActive(true);
            tempHealth = health2;
        }
        if (healthInfo == 1)
        {
            tempHealth.SetActive(false);
            health1.SetActive(true);
            tempHealth = health1;
        }
        if (healthInfo == 0)
        {
            tempHealth.SetActive(false);
            health0.SetActive(true);
            tempHealth = health0;
        }
    }
}
