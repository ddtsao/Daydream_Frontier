using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalllAudio : MonoBehaviour
{
    public List<AudioSource> audioSources;

    void WallAudio()
    {
        audioSources[0].Play();
    }
}
