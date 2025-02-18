using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    //Camera needed for giving new position
    public Camera camera;

    private float offset;

    private Vector3 positionDesired;
    private Vector3 forwardDesired;

    //Boolean which stablishes only change position once
    private bool ready;

    // Start is called before the first frame update
    void Start()
    {
        offset = 1.2601f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready) {
            this.transform.position = positionDesired + forwardDesired * offset;
            ready = false;
        }
        this.transform.rotation = Quaternion.LookRotation(camera.transform.position - this.transform.position);
    }

    void GetNewPosition()
    {
        positionDesired = camera.transform.position;
        forwardDesired = camera.transform.forward;
        ready = true;
    }
}
