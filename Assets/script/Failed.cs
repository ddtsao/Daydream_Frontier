using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failed : MonoBehaviour
{
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IsFailed()
    {
        btn.GetComponent<HpRune>().onLongClickCount = 0;
    }
    public void Failled()
    {
        btn.GetComponent<HpRune>().isFailed = false;
    }
}
