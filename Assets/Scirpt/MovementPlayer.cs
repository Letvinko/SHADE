using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {

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


    // Use this for initialization
    void Start()
    {
        extraJump = extraJumpValue;
        rb2d = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame    

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius,whatisground);
        //Debug.Log(isGrounded);

        float xAxis = Input.GetAxis("Horizontal");        
        //Vector2 direct = new Vector2(xAxis, 0);
        rb2d.velocity = new Vector2(xAxis*(runspeed* Time.fixedDeltaTime),rb2d.velocity.y);

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
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
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
    }

    void Flip() {
        arahKanan = !arahKanan;        
        Vector3 direction = transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;        
    }
}
