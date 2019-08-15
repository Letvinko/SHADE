using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class BossStage : MonoBehaviour {
    public AIPath AIpath;
    public static int Health;
    public int health;

    public GameObject deathBoss;
    private Animator anm;
    private Rigidbody2D rb2d;

    public float Rangedetector;
    public Transform Detectorplyr;
    public LayerMask whatisplyr;
    public int damage;
    private bool detectorplyr;


    private float waktuCDattack;
    public float JedaAttack;
    public Transform attackPost;
    public float attackrange;
    public LayerMask whatisplayer;

    // Use this for initialization
    void Start () {
        health = 10;
        AIpath.maxSpeed = 0;
        anm = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (AIpath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (AIpath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (BossEnterance.temp)
        {
            AIpath.maxSpeed = 4;
            anm.SetTrigger("Run");
        }

        Health = health;
        detectorplyr = Physics2D.OverlapCircle(Detectorplyr.position,Rangedetector,whatisplyr);
        if (detectorplyr)
        {
            int tempRand = Random.RandomRange(0, 2);
            if (tempRand == 0)
            {
                // boss idle chance buat nyerang boss  
                AIpath.maxSpeed = 0;
                anm.SetTrigger("Idle");

            }
            if (tempRand == 1)
            {
                //boss attack forward
                AIpath.maxSpeed = 0;
                anm.SetTrigger("FowrdAttck");
                attckforward(detectorplyr);
            }
            
        }

        if (health < 1) {
            deathBoss.SetActive(true);
            FindObjectOfType<Sound>().play("DeathBoss");
            GameObject exp = Instantiate(deathBoss, transform.position, transform.rotation);
            Destroy(exp, 2f);
            Destroy(this.gameObject);
            
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var plyr = collision.GetComponent<MovementPlayer>();
        plyr.KnockbackCount = plyr.KnockbackLength;

        if (collision.tag == "Player")
        {
            plyr.Heakth = plyr.Heakth - 1;
            plyr.knockFromRight = true;
        }
        else
        {
            plyr.knockFromRight = false;
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health < 1) {
            Destroy(this.gameObject);
        }               
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Detectorplyr.position, Rangedetector);
    }

    void attckforward(bool x) {
        if (waktuCDattack <= 0)
        {
            if (x)
            {                
                Collider2D[] enemiesDamage = Physics2D.OverlapCircleAll(attackPost.position, attackrange, whatisplayer);
                for (int i = 0; i < enemiesDamage.Length; i++)
                {
                    enemiesDamage[i].GetComponent<MovementPlayer>().TakeDamage(damage);
                }
                FindObjectOfType<Sound>().play("HitBoss");
            }
            waktuCDattack = JedaAttack;
        }
        else
        {
            waktuCDattack -= Time.deltaTime;
        }
    }

}
