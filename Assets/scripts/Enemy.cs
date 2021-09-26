using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            DoFaceLeft(true);
        }
        else
        {
            DoFaceLeft(false);
        }
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

    void DoThrow()
    {
        float x, y;

        x = transform.position.x;
        y = transform.position.y+3;

        GameObject newSpear = Instantiate(spear, new Vector3(x,y,0), Quaternion.identity);

        Rigidbody2D rb = newSpear.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(-25, 3, 0);

        DoFaceLeft(newSpear, true);
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
