using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ControladorPlayer : MonoBehaviour
{
    [Min(0)]
    public int contadorMonedas = 0;
    public float salud = 100f;
    public float saludMax = 100f;
    public Animator animator;
    public Animator barraVida;

    public UnityEvent alMorir;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_EsperaMuerte());
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.SetFloat("vida", salud/saludMax);
    }

    public void TomaDanio(float danio)
    {
        if(salud > 0f)
            salud -= danio;
        
        if(salud < 0f)
            salud = 0f;
    }

    IEnumerator _EsperaMuerte()
    {
        yield return new WaitWhile(()=> salud > 0f);
        animator.SetBool("muerte", true);
        alMorir.Invoke();
    }
}
