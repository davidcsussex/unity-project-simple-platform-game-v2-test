using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;


public class HelperScript : MonoBehaviour
{

    public static void FlipObjectTest(GameObject obj, bool faceLeft)
    {

    }

    public static void FlipObject( GameObject obj, int objectDirection )
    {
        

        if( objectDirection == Left )
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
    
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
    
        }

    
        
    }

    public static int GetObjectDir( GameObject obj )
    {
        float ang = obj.transform.eulerAngles.y;
        if( ang == 180 )
        {
            return Left;
        }
        else
            return Right;
    }


}
