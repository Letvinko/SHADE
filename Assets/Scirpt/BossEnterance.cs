using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnterance : MonoBehaviour {
    public Transform Checker;
    public float rangecage;
    public LayerMask whatistplyr;
    private bool playerEnter;
    public static bool temp;

	// Use this for initialization
	void Start () {
        playerEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
        playerEnter = Physics2D.OverlapCircle(Checker.position,rangecage,whatistplyr);

        if (playerEnter) {
            temp = playerEnter;
        }		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Checker.position, rangecage);
    }
}
