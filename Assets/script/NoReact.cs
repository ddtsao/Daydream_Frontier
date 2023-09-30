using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoReact : MonoBehaviour
{
    public GameObject title;
    private void Update()
    {
        noReact();    
    }
    public void noReact()
    {
        if(GetComponent<Image>().sprite == null)
        {
            GetComponent<Button>().enabled = false;
            if(title != null)
            {
                title.SetActive(false);
            }
        }
        else
        {
            GetComponent<Button>().enabled = true;
            if(title != null)
            {
                title.SetActive(true);
            }
        }
    }
}
