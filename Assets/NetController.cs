using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : MonoBehaviour
{
    public float swingAngle = -36f;
    public float swingDuration = 10f;

    private Quaternion originalRotation;
    private bool swinging = false;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swinging)
        {
            StartCoroutine(SwingNet());
        }
    }

    System.Collections.IEnumerator SwingNet()
    {
        swinging = true;
        float elapsed = 0f;
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(swingAngle, 0, 0));

        while (elapsed < swingDuration)
        {
            transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, elapsed / swingDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation;
        swinging = false;
    }
}