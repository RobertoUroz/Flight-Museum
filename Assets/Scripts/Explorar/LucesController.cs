using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesController : MonoBehaviour
{
    public GameObject punteroJugador;

    public GameObject punteroMover;

    public GameObject jugador;

    //Estado de las luces
    private bool isDay;

    public AudioSource audio;

    public Material dayMaterial;

    public Material nightMaterial;

    public Light luzDia;

    public Light luzNoche;

    // Start is called before the first frame update
    void Start()
    {
        isDay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticClass.lucesMode)
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
                //lever posicion arriba
                if (!isDay) {
                    audio.Play();
                    RenderSettings.skybox=dayMaterial;
                    luzDia.intensity = 1;
                    luzNoche.intensity = 0;
                    isDay = true;
                }
            } else if (this.transform.parent.localRotation.x <= -0.37f){
                //lever posicion abajo
                if (isDay) {
                    audio.Play();
                    RenderSettings.skybox=nightMaterial;
                    luzDia.intensity = 0;
                    luzNoche.intensity = 1;
                    isDay = false;
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
        StaticClass.lucesMode = true;

        //cuando jugador acaba de realizarlo, completar, poner el tag a no activable y poder dejar el usuario que se mueva

    }

    void OnPointerExit()
    {
        jugador.SendMessage("Movimiento");
        punteroJugador.SetActive(true);
        punteroMover.SetActive(false);
        StaticClass.exploreMode = true;
        StaticClass.lucesMode = false;
    }
}
