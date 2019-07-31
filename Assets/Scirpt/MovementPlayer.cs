using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementPlayer : MonoBehaviour {
    private GameController gc;
    public int Heakth;
    public GameObject deathPlyr;
    public static bool HealtBonus1;
    public static bool InfoGameover;
    public static int infodarah;

    private Rigidbody2D rb2d;

    public float runspeed = 40f;

    public float jumpforce;

    private bool arahKanan = true ;

    private Animator anm;

    private int extraJump;
    public int extraJumpValue;

    private bool isGrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;

    /*public bool Cekhit = false;
    public Vector2 resMove;
    private float temp;
    public float Knockback;*/
    public Vector2 resMove;
    public float Knockback;
    public float KnockbackLength;
    public float KnockbackCount;
    public bool knockFromRight;

    // Use this for initialization
    void Start()
    {
        extraJump = extraJumpValue;
        rb2d = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
        gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius,whatisground);

        float xAxis = Input.GetAxis("Horizontal");
        resMove = new Vector2(xAxis*(runspeed* Time.fixedDeltaTime),rb2d.velocity.y);
        //Vector2 direct = new Vector2(xAxis, 0);
        //temp = xAxis;
        if(KnockbackCount <= 0){
          rb2d.velocity = resMove;
        }else{
          if (knockFromRight)
            rb2d.velocity = new Vector2(-Knockback,Knockback);
          if(!knockFromRight)
            rb2d.velocity = new Vector2(Knockback,Knockback);
          KnockbackCount -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.W)) {
            anm.SetTrigger("TakeOf");            
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){
          anm.SetBool("SetAttack",true);
        }else if (Input.GetKeyUp(KeyCode.Mouse0)){
          anm.SetBool("SetAttack",false);
        }

        if(xAxis > 0) {
            anm.SetBool("Setlari", true);
        }
        else if (xAxis == 0)
        {
            anm.SetBool("Setlari", false);
        }

        if (xAxis < 0)
        {
            anm.SetBool("Setlari", true);
        }
        else if (xAxis == 0)
        {
            anm.SetBool("Setlari", false);
        }


        if (arahKanan == false && xAxis > 0)
        {
            Flip();
        }
        else if (arahKanan == true && xAxis < 0) {
            Flip();
        }

        //cekKnock(Cekhit,temp);
    }

    void Update()
    {
        //int randgent = Random.Range(0,2);
        //Debug.Log(randgent);
        infodarah = Heakth;
        if (HealtBonus1) {
            Heakth+=2;
            HealtBonus1 = false;
        }


        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
            anm.SetBool("SetJump", false);
        }
        else if (isGrounded == false)
        {
            anm.SetBool("SetJump", true);
        }


        if ((Input.GetButtonDown("Jump") || Input.GetKey(KeyCode.W)) && extraJump > 0)
        {
            rb2d.velocity = Vector2.up * jumpforce;
            extraJump--;
        }



        if (Input.GetKeyDown(KeyCode.S))
        {
            rb2d.gravityScale = 40f;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb2d.gravityScale = 7f;
        }

        if (Heakth < 1)
        {
            deathPlyr.SetActive(true);
            GameObject exp = Instantiate(deathPlyr, transform.position, transform.rotation);
            Destroy(exp, 3.5f);
            Destroy(this.gameObject);
            InfoGameover = true;
        }
        else{
            InfoGameover = false;
        }

    }

    void Flip() {
        arahKanan = !arahKanan;
        Vector3 direction = transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }

    public void TakeDamage(int damage)
    {
        Heakth -= damage;        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hitarea") {
            Debug.Log("Damage Taken");
            rb2d.velocity = Vector2.left * 400f;
        }
    }*/

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPost.position, attackrange);
    }*/

    /*public void cekKnock(bool cek,float temp)
    {
        if(cek == false){
          rb2d.velocity = resMove;
          Cekhit = false;
        }else{
          if(temp > 0){
            transform.Translate(Vector2.right * 20f * Time.deltaTime);
          }else if(temp < 0){
            transform.Translate(Vector2.left * 20f * Time.deltaTime);
          }
        }
    }*/

}
