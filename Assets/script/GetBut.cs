using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBut : MonoBehaviour
{
    public GameObject Pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(Pos.transform.position);
    }
}
