using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 12f;
    private float gravity = -999.81f;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //Para ver si se puede mover o esta en un modo alternativo de explorar
    bool canMove;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (canMove) {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

    }

    void Movimiento() {
        canMove = true;
    }

    void Quieto() {
        canMove = false;
    }


}
