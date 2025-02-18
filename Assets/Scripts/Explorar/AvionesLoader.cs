using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionesLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CargarAvionCorrecto()
    {
        //Mirar si es el avion elegido por el usuario
        foreach (Transform child in transform)
        {
            if (StaticClass.CrossSceneInformation.Equals(child.name)) {
                child.gameObject.SetActive(true);
            } else {
                child.gameObject.SetActive(false);
            }
        }
    }
}
