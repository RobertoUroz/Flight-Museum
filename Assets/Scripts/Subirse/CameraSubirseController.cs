using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSubirseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      CameraFading.CameraFade.In(2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
      CameraFading.CameraFade.Out(2f);
    }
}
