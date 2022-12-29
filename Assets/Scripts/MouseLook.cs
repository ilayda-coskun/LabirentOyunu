using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1000f;

    public Transform playerBody; // karakter vücudu

    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // x i al
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // y yi al

        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // kamera bakış açısı sınırı

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // y ekseninde bakma
        playerBody.Rotate(Vector3.up * mouseX); // x ekseninde bakma
    }
}
