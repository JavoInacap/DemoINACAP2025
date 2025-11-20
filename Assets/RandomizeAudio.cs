using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips;

    void Start()
    {
        if(audioSource == null)
            audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    public void RandomizeClip()
    {
        int randomIndex = Random.Range(0, audioClips.Count);

        audioSource.clip = audioClips[randomIndex];
    }

    public void PlayRandomClip()
    {
        RandomizeClip();
        audioSource.Play();
    }
}
