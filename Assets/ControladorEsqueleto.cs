using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation.Samples;
using UnityEngine;
using UnityEngine.Events;

public class ControladorEsqueleto : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////
    
    #region PARAMETROS

    // Salud del esqueleto
    [Range(0f,100f)]
    public float salud = 100f;
    public float saludMax = 100f;
    public Animator animator;
    public Animator barraVida;
    public CustomRandomWalk randomWalk;
    public ControladorArma arma;

    [Header("Deteccion Player")]
    public float rangoDeteccion = 10f;
    public LayerMask layerDeteccion;
    public Transform posicionOjos;
    public Transform playerDetectado;
    

    public UnityEvent alMorir;

    #endregion

    //////////////////////////////////////////////////////////////////////////////////

    #region CALLBACKS

    void Start()
    {
        StartCoroutine(_EsperaMuerte());
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.SetFloat("vida", salud/saludMax);

        if(salud <= 0f)
            return;
        if(randomWalk.enabled == false)
            return;

        // Si el esqueleto tiene salud, entonces trata de detectar al Player

        Vector3 direccion = posicionOjos.forward;

        Debug.DrawRay(posicionOjos.position, direccion*rangoDeteccion, Color.magenta);

        RaycastHit hit;
        if(Physics.Raycast(posicionOjos.position, direccion, out hit, rangoDeteccion, layerDeteccion))
        {
            Debug.Log("MIRE UN OBJETO: " + hit.collider.gameObject.name);
            playerDetectado = hit.collider.gameObject.transform;
        }

        if(playerDetectado != null)
        {
            randomWalk.caminataRandom = false;
            randomWalk.velocidadAgente.actualMax = randomWalk.velocidadAgente.correr;
            if(Vector3.Distance(this.transform.position, playerDetectado.position) > 2f)
                randomWalk.SetDestino(playerDetectado.position);
            else
            {
                randomWalk.velocidadAgente.actualMax = 0f;

                if(randomWalk.velocidadAgente.actual == 0f)
                {
                    if(arma.objetivoGolpeado != null)
                    {
                        animator.SetBool("ataque", arma.objetivoGolpeado.estaVivo);

                        if(arma.objetivoGolpeado.estaVivo == false)
                        {
                            arma.objetivoGolpeado = null;
                            playerDetectado = null;
                            randomWalk.velocidadAgente.actualMax = randomWalk.velocidadAgente.caminata;
                            randomWalk.caminataRandom = true;
                        }
                    }
                    else
                        animator.SetBool("ataque", true);    
                }
            }
                
        }
    }

    #endregion

    //////////////////////////////////////////////////////////////////////////////////

    #region METODOS

    public void RandomizaClipAnimator()
    {
        animator.SetTrigger("golpe");
        animator.SetInteger("golpeIndice", Random.Range(1, 6));
    }

    public void Ataque()
    {
        if(arma.objetivoGolpeado != null)
        {
            arma.objetivoGolpeado.alSerGolpeado.Invoke(arma.ataque);
        }
        else
            Log("OBJETIVO GOLPEADO ES NULO");
    }

    public void TomaDanio(float danio)
    {
        if(salud > 0f)
            salud -= danio;
        
        if(salud < 0f)
            salud = 0f;
    }


    #endregion

    //////////////////////////////////////////////////////////////////////////////////

    #region UTILITARIOS

    public void Log(string mensaje)
    {
        Debug.Log(mensaje);
    }

    #endregion

    //////////////////////////////////////////////////////////////////////////////////
    
    #region CORRUTINAS

    IEnumerator _EsperaMuerte()
    {
        yield return new WaitWhile(()=> salud > 0f);
        animator.SetBool("muerte", true);
        alMorir.Invoke();
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(this.gameObject);
    }

    #endregion

    //////////////////////////////////////////////////////////////////////////////////

    #region DEFINICIONES DATOS

    #endregion

    //////////////////////////////////////////////////////////////////////////////////
}
