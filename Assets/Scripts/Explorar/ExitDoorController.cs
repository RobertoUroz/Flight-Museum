using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorController : MonoBehaviour
{
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        //Se abre la pantalla del menu para salir
        menu.SendMessage("GetNewPosition");
    }

    public void OnPointerExit()
    {
        Debug.Log("OnPointerExit door");
    }
}
