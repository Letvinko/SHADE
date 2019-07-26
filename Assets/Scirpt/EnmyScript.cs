using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnmyScript : MonoBehaviour {
    public AIPath aipath;
    public GameObject death;    

    public LayerMask whatisPlayer;
    public Transform attackPost;
    public float attackrange;
    //private bool Hitcek;
    public bool IndicatorHit;

    private float dazedTime;
    public float StartDazedTime;

    public GameObject Warna;
    protected string Cekwarna;


    // Use this for initialization
    void Start () {
      //IndicatorHit = Hitcek;

    }

	// Update is called once per frame
	void Update () {
        if (aipath.desiredVelocity.x >= 0.01f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        } else if (aipath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

       IndicatorHit = Physics2D.OverlapCircle(attackPost.position,attackrange,whatisPlayer);

       if(dazedTime <= 0){
            aipath.maxSpeed = 3;
       }else{
            aipath.maxSpeed = 0;
            dazedTime -= Time.deltaTime;
       }
        
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPost.position, attackrange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var plyr = collision.GetComponent<MovementPlayer>();
        var attck = collision.GetComponent<Attack>();
        Cekwarna = attck.indicatorWarna;
        plyr.KnockbackCount = plyr.KnockbackLength;

        if (collision.tag == "Player") {
            plyr.Heakth = plyr.Heakth - 1;
            plyr.knockFromRight = true;
        }else{
            plyr.knockFromRight = false;
        }
    }

    public void TakeDamage(int damage){
       dazedTime = StartDazedTime;
        if (Warna.ToString() == Cekwarna) {
            death.SetActive(true);
            GameObject exp = Instantiate(death, transform.position, transform.rotation);
            Destroy(exp, 1f);
            Destroy(this.gameObject);
            MovementPlayer.HealtBonus1 = true;            
      }
      Debug.Log(Cekwarna);
    }
}
