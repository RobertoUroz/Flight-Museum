using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLightsController : MonoBehaviour
{

  public float totalSeconds;
  public float maxIntensity;
  public Light luzIzquierda;

  public Light luzDerecha;

  private bool encendiendoIzquierda;

public void Start()
{
    encendiendoIzquierda = true;
    luzIzquierda.intensity = 0;
    luzDerecha.intensity = 3;
}
  public void Update()
  {
    if (encendiendoIzquierda)
    {
      luzIzquierda.intensity += Time.deltaTime / totalSeconds;
      luzDerecha.intensity -= Time.deltaTime / totalSeconds;
      if (luzIzquierda.intensity >= maxIntensity)
      {
        encendiendoIzquierda = false;
      }
    }
    else
    {
      luzIzquierda.intensity -= Time.deltaTime / totalSeconds;
      luzDerecha.intensity += Time.deltaTime / totalSeconds;
      if (luzIzquierda.intensity <= 0)
      {
        encendiendoIzquierda = true;
      }
    }
  }
}