using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;


public class HelperScript : MonoBehaviour
{
    int direction;

    public void FlipObject( GameObject obj, int objectDirection )
    {
        if( objectDirection == Left )
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction = Left;
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction = Right;
        }
    }

    public int GetObjectDir()
    {
        return direction;
    }


}
