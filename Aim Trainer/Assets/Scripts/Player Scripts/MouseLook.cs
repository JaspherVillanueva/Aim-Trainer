using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    bool isInvertYAxis = false;
    float mouseY;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (isInvertYAxis == false)
        {
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }
        else
        {
            mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }

        xRotation -= mouseY;
        //locks camera rotation to 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //changes local rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void Addsense()
    {
        mouseSensitivity += 10;
    }

    public void Reducesense()
    {
        mouseSensitivity -= 10;
    }

    public void enableInvertYAxis()
    {
        if (isInvertYAxis == false)
        {
            isInvertYAxis = true;
        }
        else
        {
            isInvertYAxis = false;
        }
    }
}

