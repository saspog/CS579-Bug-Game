using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NetCapturer : MonoBehaviour
{
    private NetController netController;
    /**
    void Start()
    {
        netController = GetComponentInParent<NetController>();

        if (netController == null)
        {
            Debug.LogError("NetController not found in heirarchy");
        }
    }
    **/

    //script to put on net
    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Spider":
                Debug.Log("Spider caught by NetRotator!");
                Destroy(other.gameObject);
                break;
            case "Butterfly":
                Debug.Log("Butterfly caught by NetRotator!");
                Destroy(other.gameObject);
                break;
            case "DragonFly":
                Debug.Log("Dragon Fly caught by NetRotator!");
                Destroy(other.gameObject);
                break;
            case "Stickbug":
                Debug.Log("Stickbug caught by NetRotator!");
                Destroy(other.gameObject);
                break;
            default:
                Debug.Log("Nothing happened");
                break;
        }

        /**
        if (other.gameObject.tag == "Spider")
        {
            Debug.Log("Spider caught by NetRotator!");
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Butterfly")
        {
            Debug.Log("Butterfly caught by NetRotator!");
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "DragonFly")
        {
            Debug.Log("Dragon Fly caught by NetRotator!");
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Stickbug")
        {
            Debug.Log("Stickbug caught by NetRotator!");
            other.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing Happened");
        }
        **/
    }
}
