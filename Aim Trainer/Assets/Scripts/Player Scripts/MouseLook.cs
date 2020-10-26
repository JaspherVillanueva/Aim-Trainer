using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //set cursor to lock

    }

    // Update is called once per frame
    void Update()
    {
        //change x axis of mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //change y axis of mouse
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


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
}
