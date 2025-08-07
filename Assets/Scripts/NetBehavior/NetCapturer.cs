using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetCapturer : MonoBehaviour
{
    //script to put on net
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Spider")
        {
            Debug.Log("Spider caught by NetRotator!");
            Destroy(other.gameObject);
            //gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Butterfly")
        {
            Debug.Log("Butterfly caught by NetRotator!");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DragonFly")
        {
            Debug.Log("Dragon Fly caught by NetRotator!");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Stickbug")
        {
            Debug.Log("Stickbug caught by NetRotator!");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Nothing Happened");
        }
    }
}
