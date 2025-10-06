using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAlambre : MonoBehaviour
{
    public float danioInicial = 10f;
    public float danioIterativo = 5f;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ALGO CHOCO CONMIGO");
        animator.SetTrigger("hurt");

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ERA LA BOLA PLAYER. SU NOMBRE DE OBJETO ES: " + collision.gameObject.name);

            collision.gameObject.GetComponent<ControladorBola>().durabilidad -= danioInicial;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ControladorBola>().durabilidad -= danioIterativo;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("MENOS MAL ME SALÍ");
        }
    }
}
