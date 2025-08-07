using UnityEngine;
using UnityEditor;
using System;

public class NewMonoBehaviourScript : MonoBehaviour
{
    physObj bug;
    float[] facing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject temp = GameObject.Find("TestPt");
        //later add randomizer for now, set positions
        temp.transform.position = new Vector3(0, 10, 0);
        float[] temp2 =
        {
            temp.transform.position.x,
            temp.transform.position.y,
            temp.transform.position.z
        };
        bug = new physObj(temp2, true);
        this.bug.setObj(temp);
    }

    // Update is called once per frame
    void Update()
    {
        this.bug.gravUpd();
        float[] tempcoords = this.bug.getCoords();
        this.bug.getObj().transform.position = new Vector3(tempcoords[0], tempcoords[1], tempcoords[2]);
    }
}
