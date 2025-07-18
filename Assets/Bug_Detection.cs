using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug_Detection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Net"))
        {
            Debug.Log("Caught a bug"!);
            Destroy(gameObject);
        }
    }

}
