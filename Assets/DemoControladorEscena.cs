using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoControladorEscena : MonoBehaviour
{
    public ControladorMeta controladorMeta;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_EsperaLlegada());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator _EsperaLlegada()
    {
        Debug.Log("ESPERANDO QUE PLAYER LLEGUE A DESTINO");
        yield return new WaitWhile(() => controladorMeta.llegoPlayer == false);
        Debug.Log("CORRUTINA TERMINADA. PLAYER LLEGÓ");
    }
}
