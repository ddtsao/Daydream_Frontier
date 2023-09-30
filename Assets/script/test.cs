using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject but;
    public Camera cam; 
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetStartPos()
    {
        pos = cam.WorldToScreenPoint(but.transform.position);
        Debug.Log(pos);
    }
}
