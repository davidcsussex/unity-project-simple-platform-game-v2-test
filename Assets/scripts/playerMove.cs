using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// added a physicsmaterial2d with zero friction to player to stop him sticking to objects

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject camera;
    public int lives = 1;
    bool faceLeft=false;    
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    bool jumping;
    public LayerMask platformLayerMask;


    bool isGrounded;

    public bool isDead;

    SpriteRenderer sr;
    public Sprite standSprite;
    public Sprite jumpSprite;


    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>(); 
        

        isDead = false;
        jumping = false;


    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerDead();

        Vector2 velocity = rb.velocity;

        
        //Debug.Log("ig="+isGrounded);
        if(  isGrounded == true )
        {
            
            if (Input.GetKey("j") && (jumping==false))
            {
                Debug.Log("grounded do jump  vel="+velocity.y);
                if( velocity.y < 0.01 )
                {
                    velocity.y=24;
                    jumping = true;
                }
            }

        }        

        
            
        // move player left/right
        if (Input.GetKey("left"))
        {
            // registers a key held down and returns true
            velocity.x = -8.0f;
            faceLeft = true;
        }
        else if (Input.GetKey("right"))
        {
            // registers a key held down and returns true
            velocity.x = 8;
            faceLeft = false;
        
        }
        else
        {
            velocity.x=0;
            

        }
        

        // copy velocity values into the player RigidBody   
        rb.velocity = velocity;

        // set the player to face in the correct direction
        if( faceLeft == true )
        {
            
            //transform.localScale = new Vector3(-1,1,1);
        }
        else
        {
            
            //transform.localScale = new Vector3(1,1,1);
        }


        

        // set jump animation when player begins to fall
        if( (velocity.y > 0.01f) && jumping )
        {
            sr.sprite = jumpSprite;
        }
        else
        {
            sr.sprite = standSprite;        
        }
        

        //ui_text.Debug("hello");

    }


    void FixedUpdate()
    {
        CheckPlayerIsGrounded();

    }



    // ************** Boxcast code to check if player is grounded ********************************
    //  tutorial on boxcast/raycast  https://www.youtube.com/watch?v=c3iEl5AwUF8
    public void CheckPlayerIsGrounded()
    {


        //disable boxcollider if player has a positive y velocity to make him jump through platforms
        if( rb.velocity.y > 0.1f )
            bc.enabled = false;
        else
            bc.enabled = true;            


        float extraHeight = 0.5f;
        // make sure background objects are on their own layer, or collision will register with player
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center,bc.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask );

        // debug code to show the boxray
        Color rayColor;
        if(raycastHit.collider != null )
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeight), Vector2.right * (bc.bounds.extents.x * 2f), rayColor);

        //Debug.Log(raycastHit.collider);

        if( raycastHit.collider)
        {
            
            isGrounded=true;
            jumping = false;
        }
        else
        {
            isGrounded=false;
        }
        
        
    }

    void checkPlayerDead()
    {
        if( isDead == true )
        {
            transform.localScale=new Vector2(0.5f, 0.5f);
            //Debug.Log("i am dead!!");
        }
    }
}
