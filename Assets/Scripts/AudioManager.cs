using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource randomSound;

    public AudioClip[] audioSources;

    AudioClip lastClip;

    public AudioClip RandomClip()
    {
        int attempts = 3;
        AudioClip newClip = audioSources[Random.Range(0, audioSources.Length)];
        while (newClip == lastClip && attempts > 0)
        {
            newClip = audioSources[Random.Range(0, audioSources.Length)];
            attempts--;
        }
        lastClip = newClip;
        return newClip;
    }
}
