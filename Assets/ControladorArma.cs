using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    public ObjetivoGolpeable objetivoGolpeado;
    // Cantidad de daño en ataque que hace el arma;
    public float ataque = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ObjetivoGolpeable>())
        {
            Debug.Log("ENCONTRE AL PLAYER");
            objetivoGolpeado =  other.gameObject.GetComponent<ObjetivoGolpeable>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        //objetivoGolpeado = null;
    }
}
