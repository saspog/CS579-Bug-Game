using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        // Get input from WASD
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float vertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down arrows

        // Calculate direction vectors relative to the camera's current rotation
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Zero out the y component to prevent moving vertically
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate movement vector
        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        // Move the camera
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
