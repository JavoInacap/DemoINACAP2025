using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjetivoGolpeable : MonoBehaviour
{
    public UnityEvent<float> alSerGolpeado;
    public bool estaVivo = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEstaVivo(bool nuevoEstado)
    {
        estaVivo = nuevoEstado;
    }

    public void LogPublico(string mensaje)
    {
        Debug.Log(mensaje);
    }
}
