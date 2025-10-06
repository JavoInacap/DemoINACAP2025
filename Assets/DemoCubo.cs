using UnityEngine;

public class DemoCubo : MonoBehaviour
{
    public int salud = 0;
    public string nombrePersonaje = "juan";

    [SerializeField]
    private float experiencia;
    public bool esInvencible = false;
    public Vector3 posicionSpawn;
    public float velocidad;
    public GameObject objetoSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionSpawn = objetoSpawn.transform.position;
        Debug.Log("HOLA, ESTOY EN EL START");
        this.transform.position = posicionSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HOLA, ESTOY EN EL UPDATE");
        Debug.Log("POSICION DEL OBJETO: " + this.transform.position);
        Debug.Log("SALUD DEL CUBO: " + salud);
        Debug.Log("NOMBRE DEL PERSONAJE: " + nombrePersonaje);

        Vector3 cantidadDesplazamiento = new Vector3(0.1f, 0f, 0f);
        this.transform.Translate(velocidad * cantidadDesplazamiento);

        Debug.Log("ROTACION RADIANA DEL OBJETO: " + this.transform.rotation);
        Debug.Log("ROTACION EULER DEL OBJETO: " + this.transform.eulerAngles);

        this.transform.Rotate(0f, 0.1f, 0f);
    }
}
