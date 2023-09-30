using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float BoundX = 0.03f;
    public float BoundY = 0.03f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltaX = lookAt.position.x-transform.position.x;
        if(deltaX>BoundX||deltaX<-BoundX)
        {
            if(transform.position.x<lookAt.position.x)
            {
                delta.x=deltaX-BoundX;
            }
            else
            {
                delta.x=deltaX+BoundX;
            }
        }
        float deltaY = lookAt.position.y-transform.position.y;
        if(deltaY>BoundY||deltaY<-BoundY)
        {
            if(transform.position.y<lookAt.position.y)
            {
                delta.y=deltaY-BoundY;
            }
            else
            {
                delta.y=deltaY+BoundY;
            }
        }
        transform.position+=new Vector3(delta.x,delta.y,0);
    }
}
