using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject player;
  

    
    void Update()
    {
        transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity, 0, 0);
        player.transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
    }
}
