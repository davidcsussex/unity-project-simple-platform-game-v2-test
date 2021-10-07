using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    bool isGrounded;
    bool isJumping;
    public GameObject bulletPrefab;
    HelperScript helper;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isJumping = false;

    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        DoLand();
        DoShoot();
        
    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("space") && (isGrounded==true) )
        {
           velocity.y = 25f;    // give the player a velocity of 5 in the y axis
           anim.SetBool("jump",true);
           isJumping = true;
        }

        rb.velocity = velocity;

    }

    

    void DoMove()
    {

        
        Vector2 velocity = rb.velocity;

        

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if ( Input.GetKey("left"))
        {
            velocity.x = -10;
            
        }

        // check for moving right
        
        if (Input.GetKey("right"))
        {
            velocity.x = 10;
        }


        if( velocity.x != 0 )
        {
            anim.SetBool("walk", true );
        }
        else
        {
            anim.SetBool("walk", false );
        }

        
        // make player face left or right depending on whether his velocity is positive or negative
        if( velocity.x < -0.5f )
        {
            HelperScript.FlipObject(gameObject, Left);
            HelperScript.FlipObjectTest(gameObject,  true );
        }
        if( velocity.x > 0.5f )
        {
            HelperScript.FlipObject(gameObject, Right);
        }


        rb.velocity = velocity;
    }


    void DoLand()
    {
        // check for player landing

        if( isJumping && isGrounded && (rb.velocity.y <=0))
        {
            print("landed!");
            // player was jumping and has now hit the ground
            isJumping = false;
            anim.SetBool("jump",false);
        }
    }

    void DoShoot()
    {
        float x,y;
        float xvel;
        if ( Input.GetKeyDown("s"))        
        {
            x = transform.position.x;
            y = transform.position.y+3;



            // if player is facing left, move the bullet left
            if( HelperScript.GetObjectDir(gameObject) == Left )
            {
                xvel = -65;
                

            }
            else
            {
                xvel = 65;
                

            }

            HelperScript.MakeBullet( bulletPrefab, x,y, xvel,0 );
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
