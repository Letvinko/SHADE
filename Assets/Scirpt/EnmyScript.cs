using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnmyScript : MonoBehaviour {
    public AIPath aipath;
    

    public LayerMask whatisPlayer;
    public Transform attackPost;
    public float attackrange;
    public bool Hitcek;
    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (aipath.desiredVelocity.x >= 0.01f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        } else if (aipath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

       Hitcek = Physics2D.OverlapCircle(attackPost.position,attackrange,whatisPlayer);

	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPost.position, attackrange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("Damage Taken");
            Debug.Log(Hitcek);
        }
    }
}
