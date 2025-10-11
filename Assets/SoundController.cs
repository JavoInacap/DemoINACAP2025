using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioMixer audioMixer;
    [Range(-80f, 20f)]
    public float masterVolumen = 0f;
    [Range(-80f, 20f)]
    public float musicVolumen = 0f;
    [Range(-80f, 20f)]
    public float ambientalVolumen = 0f;
    [Range(-80f, 20f)]
    public float sfxVolumen = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioMixer.SetFloat("masterVolumenAM", masterVolumen);
        audioMixer.SetFloat("musicVolumenAM", musicVolumen);
        audioMixer.SetFloat("ambientalVolumenAM", ambientalVolumen);
        audioMixer.SetFloat("sfxVolumenAM", sfxVolumen);
    }
}
