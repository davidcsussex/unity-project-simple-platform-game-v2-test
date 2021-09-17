using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        print(isGrounded);
    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("space") && isGrounded )
        {
            if (velocity.y < 0.01f )
            {
                velocity.y = 25f;    // give the player a velocity of 5 in the y axis
                
            }
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
            anim.Play("walk");
        }

        // check for moving right
        if (Input.GetKey("right"))
        {
            velocity.x = 10;
        }


        if( velocity.x != 0 )
        {
            anim.Play("walk");
        }
        else
        {
            anim.Play("idle");
        }

        rb.velocity = velocity;

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