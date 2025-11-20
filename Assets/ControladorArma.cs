using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    public ObjetivoGolpeable objetivoGolpeado;

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
        if(other.gameObject.tag == "ObjetivoGolpeable")
        {
            objetivoGolpeado =  other.gameObject.GetComponent<ObjetivoGolpeable>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        objetivoGolpeado = null;
    }
}
