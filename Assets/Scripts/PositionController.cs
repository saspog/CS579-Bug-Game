using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
     public Transform cameraTransform; // Assign the camera in the Inspector
    public float distanceFromCamera; // Set the desired distance

    void Update()
    {
        Vector3 resultingPosition = cameraTransform.position + cameraTransform.forward * distanceFromCamera;
        transform.position = resultingPosition;
    }
}
