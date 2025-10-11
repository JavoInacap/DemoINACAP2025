using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuInicioController : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMasterVolumen(float newMasterVolumen)
    {
        audioMixer.SetFloat("masterVolumenAM", newMasterVolumen);
    }

    public void SetMusicVolumen(float newMusicVolumen)
    {
        audioMixer.SetFloat("musicVolumenAM", newMusicVolumen);
    }

    public void SetAmbientalVolumen(float newAmbientalVolumen)
    {
        audioMixer.SetFloat("ambientalVolumenAM", newAmbientalVolumen);
    }
    
    public void CargaEscena(int indiceEscena)
    {
        SceneManager.LoadScene(indiceEscena);
    }
}
