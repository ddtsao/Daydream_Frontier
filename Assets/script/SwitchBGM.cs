using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Animator anim;
    public string s;

    private void Update() 
    {
        Switcher();
    }
    public void Switcher()
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.93f) && anim.GetCurrentAnimatorStateInfo(0).IsName(s))
        {
            if(audioSource.clip != audioClip)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                audioSource.pitch = 1.0f;
            }
        }
    }
}
