using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BigWind : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Update() 
    {
        ChangeVolume();
    }
    void ChangeVolume()
    {
        if(GameObject.Find("MainCharacter").transform.position.y >= 10.371f)
        {
            Debug.Log("k");
            audioMixer.SetFloat("Wind", 15f);
        }
    }
}
