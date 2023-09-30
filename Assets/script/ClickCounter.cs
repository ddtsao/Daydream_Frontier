using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickCounter : MonoBehaviour
{
    public Animator anim;

    private void Update() 
    {

    }
    public void CountClick()
    {
        GameManager.instance.OnLongClickCount += 1;
    }  
}
