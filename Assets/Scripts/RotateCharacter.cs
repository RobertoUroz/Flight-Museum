using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    private float xRotation = 0f;

    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(DeviceRotation.Get());

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(90f, yRotation, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
    }
}
