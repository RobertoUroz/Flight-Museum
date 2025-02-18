using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneExplorarController : MonoBehaviour
{
    //posibles estados: rotar, escalar, mover (eje de las y), jugador (mover al jugador)
    private string estado = "jugador";

    public GameObject jugador;

    private GameObject punteroActual;

    public GameObject punteroJugador;
    public GameObject punteroMover;
    public GameObject punteroRotar;
    public GameObject punteroEscalar;

    private float sensitivity = 5.0f;
    private float rotationSensitivity = 90.0f;

    private bool isCollision = false;
    private string collidedName = "";
    
    // Start is called before the first frame update
    public void Start()
    {
        //Puntero actual
        punteroActual = punteroJugador;
    }

    // Update is called once per frame
    void Update()
    {

        //Cambiar de estado
        if (StaticClass.exploreMode == true)
        {
            cambioDeEstado();
            //TODO: Para la colision: hacer el cambio de transform (escalar, mover, rotar). 
            //Si choca, deshacerlo en el mismo frame (update), es decir, restando. Hacer una función de check?
            if (estado.Equals("mover")){
                float y = Input.GetAxis("Vertical");
                float x = Input.GetAxis("Horizontal");
                //arriba y abajo
                if (!isCollision || (isCollision && y > 0 && collidedName.Equals("Suelo")) || (isCollision && y < 0 && collidedName.Equals("Techo")))
                    transform.parent.Translate(new Vector3(0, 1.0f, 0) * sensitivity * y * Time.deltaTime, Space.World);
            } else if (estado.Equals("rotar")) {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");
                if (!isCollision)
                    transform.parent.Rotate(y * rotationSensitivity * Time.deltaTime, 0, -1.0f * x * rotationSensitivity * Time.deltaTime);
            } else if (estado.Equals("escalar")) {
                float scale = Input.GetAxis("Vertical");
                Vector3 newScale = transform.parent.localScale + (new Vector3(1, 1, 1) * scale * Time.deltaTime);
                if ((newScale.x > 0.1 && newScale.y > 0.1 && newScale.z > 0.1 && ((isCollision && scale < 0) || !isCollision)))
                    transform.parent.localScale = newScale; 
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        string[] techoColliders = { "Techo arriba", "Techo izquierdo (puerta)", "Techo derecho (puerta)", "Techo" };
        isCollision = true;
        collidedName = collision.collider.name;
        foreach (string s in techoColliders) {
            if (s.Equals(collidedName))
                collidedName = "Techo";
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isCollision = true;
        string[] techoColliders = { "Techo arriba", "Techo izquierdo (puerta)", "Techo derecho (puerta)", "Techo" };
        isCollision = true;
        collidedName = collision.collider.name;
        foreach (string s in techoColliders) {
            if (s.Equals(collidedName))
                collidedName = "Techo";
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isCollision = false;
        collidedName = "";
    }

    private void cambioDeEstado() {
        if (Input.GetButtonDown("R1")) {
            punteroActual.SetActive(false);
            Debug.Log("Antes: " + estado);
            if (estado.Equals("jugador")) {
                estado = "mover";
                punteroActual = punteroMover;
            } else if (estado.Equals("mover")) {
                estado = "rotar";
                punteroActual = punteroRotar;
            } else if (estado.Equals("rotar")) {
                estado = "escalar";
                punteroActual = punteroEscalar;
            } else if (estado.Equals("escalar")) {
                estado = "jugador";
                punteroActual = punteroJugador;
            } else {
                estado = "jugador";
                punteroActual = punteroJugador;
            }
            punteroActual.SetActive(true);
            Debug.Log("Despues: " + estado);
        }
        if (estado.Equals("jugador"))
            jugador.SendMessage("Movimiento");
        else
            jugador.SendMessage("Quieto");
    }
}
