using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCapturer : MonoBehaviour
{
    //script to put on net
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bug")
        {
            Debug.Log("Bug caught by NetRotator!");
            Destroy(other.gameObject);
            //gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing Happened");
        }
    }
}
