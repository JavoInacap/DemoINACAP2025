using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorCanvas : MonoBehaviour
{
    public ControladorPlayer controladorPlayer;
    public TMP_Text textCoins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textCoins.text = controladorPlayer.contadorMonedas.ToString();
    }
}
