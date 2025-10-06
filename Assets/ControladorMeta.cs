using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControladorMeta : MonoBehaviour
{
    public bool llegoPlayer = false;
    public int contadorFinal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (llegoPlayer == true)
        {
            Debug.Log("TERMINO LA PARTIDA. TOTAL DE MONEDAS = " + contadorFinal);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER LLEGO A LA META");
            llegoPlayer = true;

            contadorFinal = other.gameObject.GetComponent<ControladorPlayer>().contadorMonedas;
        }
    }
}
