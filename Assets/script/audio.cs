using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;

    private void Update() 
    {
        ChangeVolume();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.Play();
    }
    public void PlayAudio()
    {
        audioSource.Play();
    }
    void ChangeVolume()
    {
        if(GameObject.Find("MainCharacter") != null)
        {
            if(GameObject.Find("MainCharacter").transform.position.y >= 10.371f)
            {
                audioMixer.SetFloat("Wind", 15f);
            }
        }
    }
}
