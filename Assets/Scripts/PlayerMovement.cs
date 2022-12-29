using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0) //karakter yerde ve zıplamıyorsa
        {
            velocity.y = 0f;           // hareket yok
        }

        float x = Input.GetAxis("Horizontal"); // x ekseninde hareket
        float z = Input.GetAxis("Vertical"); // z ekseninde hareket

        Vector3 move = transform.right * x + transform.forward * z; //hareket vektörü
        controller.Move(move * speed * Time.deltaTime);// hareket(x ve z ekseninde)

        velocity.y += gravity * Time.deltaTime; // hareket hızı
        controller.Move(velocity * Time.deltaTime); // hareket(y ekseninde)
    }
}
