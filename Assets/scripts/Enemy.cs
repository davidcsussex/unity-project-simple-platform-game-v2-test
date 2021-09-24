using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("player x position = " + player.transform.position.x);

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

}