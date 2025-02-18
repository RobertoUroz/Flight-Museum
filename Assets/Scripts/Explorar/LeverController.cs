using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{

    public GameObject punteroJugador;

    public GameObject punteroMover;

    public GameObject jugador;

    public Animation animation;

    //Estado de la puerta del hangar
    private bool isClosed;

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        isClosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticClass.leverMode)
        {
            float y = Input.GetAxis("Vertical");
            if ((this.transform.parent.localRotation.x < 0.38268f && this.transform.parent.localRotation.x > -0.38268f)
                || (this.transform.parent.localRotation.x >= 0.38268f && y < 0)
                || (this.transform.parent.localRotation.x <= -0.38268f && y > 0)) 
            {
                this.transform.parent.Rotate(y * 10.0f * Time.deltaTime, 0, 0);
            }
            if (this.transform.parent.localRotation.x >= 0.37f)
            {
                //animation close
                if (!isClosed) {
                    audio.Play();
                    isClosed = true;
                    animation.Play("Close");
                    animation["Close"].speed = 2.0f;
                }
            } else if (this.transform.parent.localRotation.x <= -0.37f){
                //animation open
                if (isClosed) {
                    audio.Play();
                    isClosed = false;
                    animation.Play("Open");
                    animation["Open"].speed = 2.0f;
                }
            }
        }
        
    }

    void OnPointerEnter()
    {
        //cuando el usuario entra en el modo, cambiar puntero a subir y bajar y el usuario no se puede mover al no ser que aparte la mirada
        //o complete lo de subir
        //si no lo completa
        //Cuando lo completa, pasa a ser no activable
        //Se mira si está abierto o no en la clase static para no tener que hacerlo cada vez

        //cambiar puntero jugador a mover arriba y abajo
        jugador.SendMessage("Quieto");
        punteroJugador.SetActive(false);
        punteroMover.SetActive(true);
        StaticClass.exploreMode = false;
        StaticClass.leverMode = true;

        //cuando jugador acaba de realizarlo, completar, poner el tag a no activable y poder dejar el usuario que se mueva

    }

    void OnPointerExit()
    {
        jugador.SendMessage("Movimiento");
        punteroJugador.SetActive(true);
        punteroMover.SetActive(false);
        StaticClass.exploreMode = true;
        StaticClass.leverMode = false;
    }
}
