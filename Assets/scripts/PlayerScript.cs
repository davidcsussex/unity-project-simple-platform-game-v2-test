using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    bool isGrounded;
    bool isJumping;

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

    void DoFaceLeft( bool faceLeft)
    {
        if( faceLeft == true )
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
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
            DoFaceLeft(true);
        }
        if( velocity.x > 0.5f )
        {
            DoFaceLeft(false);
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
