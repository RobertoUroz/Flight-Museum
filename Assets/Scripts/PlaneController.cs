//-----------------------------------------------------------------------
// <copyright file="PlaneController.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class PlaneController : MonoBehaviour
{
    
    //Menu for selection, will stay there
    public GameObject menu;
    public GameObject buttonSubirse;

    //nombre del avion
    public Text nombreAvion;
    private string _namePlane;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _namePlane = transform.parent.name;
        //Conseguir el nombre del avion para luego pasarlo a la escena X
        //Apagar la pantalla por si acaso
    }

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        //Se abre la pantalla del menu con la info del avion
        nombreAvion.text = _namePlane;
        StaticClass.CrossSceneInformation = _namePlane;
        switch (_namePlane) {
            case "Fighter Interceptor":
                buttonSubirse.SetActive(true);
                break;
            default:
                buttonSubirse.SetActive(false);
                break;
        }
        menu.SendMessage("GetNewPosition");

        //SetMaterial(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        Debug.Log("OnPointerExit Plane");
    }
}
