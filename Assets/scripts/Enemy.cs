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
    HelperScript helper;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        helper = GetComponent<HelperScript>();

        

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
            helper.FlipObject(gameObject,Left);
        }
        else
        {
            helper.FlipObject(gameObject, Right);
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
        if( helper.GetObjectDir() == Left )
        {
            rb.velocity = new Vector3(-35, 4, 0);
            helper.FlipObject(newSpear, Left);
        }
        else
        {
            rb.velocity = new Vector3(35, 4, 0);
            helper.FlipObject(newSpear, Right);
        }


        
    }

    void DoFaceLeft(GameObject obj, bool faceLeft)
    {
        if (faceLeft == true)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }


}
