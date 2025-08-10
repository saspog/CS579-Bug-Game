using System;
using UnityEngine;

public class BugBase : MonoBehaviour
{
    bool move;
    bool caught;
    Vector3 takeoff;
    Vector3 v;
    System.Random rand;

    //Caught getter
    public bool getCaught() { return this.caught; }

    //Set catch
    public void setCaught(bool caught) { this.caught = caught; }
    
    //Collision removal
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "NetCollider")
        {
            this.transform.Translate(-this.v);
            this.transform.Rotate(0, 180, 0);
            this.v = Vector3.zero;
            this.move = false;
        } else
        {
            this.setCaught(true);
            this.v = Vector3.zero;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rand = new System.Random();
        this.move = true; //starts the bug on movement right away
        this.v = Vector3.back / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.move) 
        {
            if (this.rand.Next(500) == 0)
            {
                this.move = true;
                this.v = Vector3.back / 100;
            }
        } else
        {
            if (this.rand.Next(20) == 0)
            {
                float randx = (float)this.rand.NextDouble() * 2 - 1;
                float randy = (float)this.rand.NextDouble() * 30f - 15f;
                float randz = (float)this.rand.NextDouble() * 2 - 1;
                this.transform.Rotate(randx, randy, randz);
            }
        }
        this.transform.Translate(this.v);
    }
}
