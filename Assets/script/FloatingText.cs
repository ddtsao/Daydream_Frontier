using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public bool active;
    public GameObject go;
    public TextMeshProUGUI txt;
    public Image hp_Potion;
    public Vector3 motion;
    public float duration;
    public float lastshown;

    public void Show()
    {
        active = true;
        lastshown = Time.time;
        go.SetActive(active);
    }
    
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    public void UpdateMoveFloat()
    {
        if(!active)
        {
            return;
        }

        if(Time.time - lastshown > duration)
        {
            Hide();
        }
        go.transform.position+=motion*Time.deltaTime;
    }
}
