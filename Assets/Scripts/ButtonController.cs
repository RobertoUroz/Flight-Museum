using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text nombreAvion;

    public CharacterController controller;

    public Camera camera;

    public GameObject player;

    public GameObject explorarParent;

    public GameObject planes;

    public GameObject modeloCargado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        //Mira que nombre tiene y va a la escena indicada con el valor del texto que tiene el nombre avion
        camera.SendMessage("Quieto");
        camera.SendMessage("FadeOut");
        if (this.name.Equals("Explorar")) {
            planes.SendMessage("CargarAvionCorrecto");
            camera.SendMessage("FadeIn");
            camera.SendMessage("Movimiento");
            modeloCargado.SendMessage("BeginFadeInFadeOut");
        }
        else  {
            CustomSceneManager.OnLoadSceneAsync("Subirse");
        }
    }

    public void OnPointerExit()
    {
        Debug.Log("OnPointerExit button");
    }
}
