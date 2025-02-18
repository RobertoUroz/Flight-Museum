using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlane : MonoBehaviour
{
    public float forwardSpeed = 5.0f, strafeSpeed = 7.5f, hoverSpeed = 5f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 20.0f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 2.0f, rollAcceleration = 1.0f;

    public Camera camera;

    void Start()
    {
    }

    void Update()
    {
        rollInput = Mathf.Lerp(rollInput, -1.0f * Input.GetAxisRaw("Horizontal"), rollAcceleration * Time.deltaTime);

        transform.Rotate(Input.GetAxisRaw("Vertical") * lookRateSpeed * Time.deltaTime, Input.GetAxisRaw("Yaw") * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Yaw") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        //Return to nivel principal
        if (Input.GetButtonDown("L1")) {
            camera.SendMessage("FadeOut");
            CustomSceneManager.OnLoadSceneAsync("NivelPrincipal");
        }
    }
}
