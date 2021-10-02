using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;




public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    private Animator anim;
    public GameObject spear;
    

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        

        

    }

    // Update is called once per frame
    void Update()
    {

        //trigger enemy throw

        if( Input.GetKey("t"))
        {
            anim.Play("throw");
        }

        //print("player x position = " + player.transform.position.x);

        if ( player.transform.position.x < transform.position.x )
        {
            HelperScript.FlipObject(gameObject,Left);
        }
        else
        {
            HelperScript.FlipObject(gameObject, Right);
        }
    }



    void DoThrow()
    {
        float x, y;

        x = transform.position.x;
        y = transform.position.y+3;

        GameObject newSpear = Instantiate(spear, new Vector3(x,y,0), Quaternion.identity);

        Rigidbody2D rb = newSpear.GetComponent<Rigidbody2D>();

        // if enemy is facing left, throw the spear to the left
        if( HelperScript.GetObjectDir(gameObject) == Left )
        {
            rb.velocity = new Vector3(-35, 4, 0);
            HelperScript.FlipObject(newSpear, Left);
        }
        else
        {
            rb.velocity = new Vector3(35, 4, 0);
            HelperScript.FlipObject(newSpear, Right);
        }


        
    }


    void OnCollisionEnter2D( Collision2D col )
    {
        print("tag=" + col.gameObject.tag );
        
        if( col.gameObject.tag == "Bullet")
        {
            print("I've been hit by a bullet!");

        }
    }

    void OnTriggerEnter2D( Collider2D col )
    {
        print("col=" + col.isTrigger );
        if( col.tag == "Bullet")
        {
            print("Trigger - I've been hit by a bullet!");
            Destroy(col.gameObject);
        }
    }

}
