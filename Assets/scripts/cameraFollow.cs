using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0, 0);
    // Start is called before the first frame update

     // drag player object to followTransform variable in inspector 
    public Transform followTransform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = offset + new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);   
    }
}
