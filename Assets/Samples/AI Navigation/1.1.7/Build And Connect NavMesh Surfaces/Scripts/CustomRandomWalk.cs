using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Walk to a random position and repeat
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class CustomRandomWalk : MonoBehaviour
    {
        public float m_Range = 25.0f;
        NavMeshAgent m_Agent;
        // Animator de movimiento del agente
        public Animator animator;
        public Velocidad velocidadAgente;
        public bool caminataRandom = true;
        public List<Transform> puntosPatrulla;
        public TipoPatrulla tipoPatrulla;
        public int ultimoPunto = 0;

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            velocidadAgente.actual = 0f;
            velocidadAgente.actualMax = velocidadAgente.caminata;
        }

        void Update()
        {
            m_Agent.speed = velocidadAgente.actual;
            if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
            {
                if(m_Agent.remainingDistance > 0.1f)
                {
                    if(velocidadAgente.actual < velocidadAgente.actualMax)
                    {
                        velocidadAgente.actual += Time.deltaTime*velocidadAgente.aceleracion;
                        if(velocidadAgente.actual > velocidadAgente.actualMax)
                            velocidadAgente.actual = velocidadAgente.actualMax;
                    }
                    else if(velocidadAgente.actual > velocidadAgente.actualMax)
                    {
                        velocidadAgente.actual -= Time.deltaTime*velocidadAgente.aceleracion*5;
                        if(velocidadAgente.actual < velocidadAgente.actualMax)
                            velocidadAgente.actual = velocidadAgente.actualMax;
                    }
                    
                    animator.SetFloat("velocidad", velocidadAgente.actual);
                }
                return;
            }
                
            if(caminataRandom == true)
                SetPatrullaje();
                //m_Agent.destination = m_Range * Random.insideUnitCircle;
        }

        public void SetPatrullaje()
        {
            switch(tipoPatrulla)
            {
                case TipoPatrulla.random:
                    m_Agent.destination = m_Range * Random.insideUnitCircle;
                    break;
                case TipoPatrulla.patrullaEnOrden:
                    if(puntosPatrulla != null)
                    {
                        if(puntosPatrulla.Count > 0)
                        {
                            Debug.Log("VOY AL PUNTO: " + puntosPatrulla[ultimoPunto < puntosPatrulla.Count-1 ? ultimoPunto + 1 : 0].name);
                            m_Agent.destination = puntosPatrulla[ultimoPunto < puntosPatrulla.Count-1 ? ultimoPunto + 1 : 0].position;
                            ultimoPunto = ultimoPunto < puntosPatrulla.Count-1 ? ultimoPunto + 1 : 0;
                        }
                        else
                            tipoPatrulla = TipoPatrulla.random;
                    }
                    else
                        tipoPatrulla = TipoPatrulla.random;
                    break;
                case TipoPatrulla.patrullaAlAzar:
                    if(puntosPatrulla != null)
                    {
                        if(puntosPatrulla.Count > 0)
                        {
                            
                            int indexAux = Random.Range(0, puntosPatrulla.Count);

                            Debug.Log("VOY AL PUNTO: " + puntosPatrulla[indexAux].name);

                            m_Agent.destination = puntosPatrulla[indexAux].position;
                        }
                        else
                            tipoPatrulla = TipoPatrulla.random;
                    }
                    else
                            tipoPatrulla = TipoPatrulla.random;
                    break;
            }
        }

        public void SetDestino(Vector3 nuevoDestino)
        {
            m_Agent.destination = nuevoDestino;
        }

        [System.Serializable]
        public struct Velocidad
        {
            public float actual;
            public float actualMax;
            public float caminata;
            public float correr;
            [Range(0f,1f)]
            public float aceleracion;
        }

        public enum TipoPatrulla {random, patrullaEnOrden, patrullaAlAzar};
    }
}