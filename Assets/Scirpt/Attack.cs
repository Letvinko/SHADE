using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	private float waktuCDattack;
	public float JedaAttack;

	public Transform attackPost;
	public float attackrange;
	public LayerMask whatisEnmy;
	public int damage;

	public GameObject Me;
	public GameObject Ji;
	public GameObject Ku;
	public GameObject Hi;
	public GameObject Bi;
	public GameObject Ni;
	public GameObject U;
	public GameObject Temp;

	public string indicatorWarna;

	// Use this for initialization
	void Start () {
		Temp = null;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Temp = Me;
            Temp.SetActive(false);
            Me.SetActive (true);
			indicatorWarna = Me.ToString();                        
        }
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			Ji.SetActive (true);
			Temp.SetActive(false);
			Temp = Ji;			
			indicatorWarna = Ji.ToString();
		}
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Ku.SetActive(true);
            Temp.SetActive(false);
            Temp = Ku;
            indicatorWarna = Ku.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Hi.SetActive(true);
            Temp.SetActive(false);
            Temp = Hi;
            indicatorWarna = Hi.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Bi.SetActive(true);
            Temp.SetActive(false);
            Temp = Bi;
            indicatorWarna = Bi.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Ni.SetActive(true);
            Temp.SetActive(false);
            Temp = Ni;
            indicatorWarna = Ni.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            U.SetActive(true);
            Temp.SetActive(false);
            Temp = U;
            indicatorWarna = U.ToString();
        }

        if (waktuCDattack <= 0){
				if(Input.GetKeyDown(KeyCode.Mouse0)){
					Collider2D[] enemiesDamage = Physics2D.OverlapCircleAll(attackPost.position,attackrange,whatisEnmy);
					for (int i = 0; i < enemiesDamage.Length ; i++) {
					    enemiesDamage[i].GetComponent<EnmyScript>().TakeDamage(damage);                            
                    }
				}
				waktuCDattack = JedaAttack;
			}else{
				waktuCDattack -= Time.deltaTime;
			}
	}

	void OnDrawGizmosSelected()
	{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(attackPost.position, attackrange);
	}
}
