using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    private void Update()
    {
        ChangeName();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        GetComponent<EdgeCollider2D>().enabled = false;
        GetComponent<Dialogue>().enabled = true;
        GetComponent<Dialogue>().Page.SetActive(true);
        GetComponent<Dialogue>().StartDialogue();    
    }
    void ChangeName()
    {
        int i = GetComponent<Dialogue>().index;
        if(i == 0 || i == 1 || i == 3 ||  i== 5 || i == 7 || i == 8 || i == 9 || i == 10 || i == 12 || i == 14 || i == 15)
        {
            GetComponent<Dialogue>().name.text = "我";
        }
        else
        {
            GetComponent<Dialogue>().name.text = "皢銘";
        }
    }
}
