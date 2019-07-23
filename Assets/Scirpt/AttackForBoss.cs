using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackForBoss : MonoBehaviour {
    private float waktuCDattack;
    public float JedaAttack;

    public Transform attackPost;
    public float attackrange;
    public LayerMask whatisEnmy;
    public int damage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (waktuCDattack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] enemiesDamage = Physics2D.OverlapCircleAll(attackPost.position, attackrange, whatisEnmy);
                for (int i = 0; i < enemiesDamage.Length; i++)
                {                    
                    enemiesDamage[i].GetComponent<BossStage>().TakeDamage(damage);
                }
            }
            waktuCDattack = JedaAttack;
        }
        else
        {
            waktuCDattack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPost.position, attackrange);
    }

}
