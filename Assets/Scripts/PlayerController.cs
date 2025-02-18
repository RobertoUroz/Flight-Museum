using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject explorarParent;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = StaticClass.playerCoords;
        this.transform.rotation = StaticClass.playerOrientation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
