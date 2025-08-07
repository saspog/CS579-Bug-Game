using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    public float sensitivity = 15f;

    // Update is called once per frame
    void Update()
    {
        // Get input from Mouse
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;

        // Calculate direction vectors
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Zero out the y component to prevent moving vertically
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        //transform.position += transform.localEulerAngles * sensitivity * Time.deltaTime;
    }
}
