//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
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
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    //Reticle of timer
    public Image reticle;

    //Timer for gaze pointer
    private float _gazeTime = 0.0f;
    public float _gazeTimer = 2f; //In Seconds

    private bool ready;

    private AudioSource m_MyAudioSource;

    public void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        this.FadeIn();
    }


    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera, different game object.
            //Debug.Log(_gazedAtObject);
            if (_gazedAtObject != hit.transform.gameObject)
            {
                ready = true;
                if (_gazedAtObject?.tag == "IsActivable")
                {
                    _gazedAtObject?.SendMessage("OnPointerExit");
                }                
                _gazedAtObject = hit.transform.gameObject;
                _gazeTime = 0.0f;
            } else if (_gazedAtObject.tag == "IsActivable") { // Check whether tag of gameobject is isActivable, for not having the reticle loading always
                // Detecting same gameObject which is isActivable
                _gazeTime += Time.deltaTime;
            }
            // If time greater than timer, activate
            if (_gazeTime >= _gazeTimer) {
                //only call once to OnPointerEnter
                if (ready) {
                    this.m_MyAudioSource.Play();
                    _gazedAtObject.SendMessage("OnPointerEnter");
                    ready = false;
                }
                _gazeTime = _gazeTimer;
            }
            reticle.fillAmount = _gazeTime / _gazeTimer;
        }
        else
        {
            // No GameObject detected in front of the camera.
            if (_gazedAtObject?.tag == "IsActivable")
            {
                _gazedAtObject?.SendMessage("OnPointerExit");
            }
            ready = true;
            _gazedAtObject = null;
            _gazeTime = 0.0f;
            reticle.fillAmount = _gazeTime / _gazeTimer;
        }
    }

    public void FadeOut()
    {
      CameraFading.CameraFade.Out(2f);
    }

    public void FadeIn()
    {
      CameraFading.CameraFade.In(2f);
    }
}
