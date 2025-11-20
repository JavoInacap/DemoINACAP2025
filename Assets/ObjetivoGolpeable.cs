using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjetivoGolpeable : MonoBehaviour
{
    public UnityEvent alSerGolpeado;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogPublico(string mensaje)
    {
        Debug.Log(mensaje);
    }
}
