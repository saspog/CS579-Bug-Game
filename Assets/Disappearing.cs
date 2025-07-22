using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Net")
        {
            Debug.Log("Bug caught by NetRotator!");
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing Happened");
        }
    }
}
