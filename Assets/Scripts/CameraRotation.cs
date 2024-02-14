using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
   float sensitivity = 400f, Rotationx = 0f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        Rotationx -= mouseY;
        Rotationx = Mathf.Clamp(Rotationx, -85f, 90);

        Debug.Log(mouseX);

        transform.localRotation = Quaternion.Euler(Rotationx, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}

