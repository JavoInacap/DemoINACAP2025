using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBola : MonoBehaviour
{
    public Rigidbody rigidbody;
    [Range(-1f,1f)]
    public float coeficienteFuerza = 0f;
    [Range(0f,100f)]
    public float durabilidad;
    public int contadorMonedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(0f, 0f, 0.001f);
        rigidbody.AddForce(0f, 0f, 1f * coeficienteFuerza);
    }
}
