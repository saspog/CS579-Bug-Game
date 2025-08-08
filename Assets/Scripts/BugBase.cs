using System;
using UnityEngine;

public class BugBase : MonoBehaviour
{
    bool move;
    bool caught;
    Vector3 takeoff;
    System.Random rand;

    //Caught getter
    public bool getCaught() { return this.caught; }

    //Set catch
    public void setCaught(bool caught) { this.caught = caught; }
    
    //Collision removal
    void OnCollisionEnter(Collision col)
    {
        //Not detecting collisions for some reason, look into 
        this.move = false;
        this.takeoff = Vector3.zero;
        ContactPoint[] cp = new ContactPoint[1];
        int j = col.GetContacts(cp);
        for (int i = 0; i < j; i++)
        {
            this.takeoff += cp[i].normal;
        }
        Vector3.Normalize(this.takeoff);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rand = new System.Random();
        this.move = true; //starts the bug on movement right away
        this.GetComponent<Rigidbody>().linearVelocity = Vector3.forward / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.move) 
        {
            if (this.rand.Next(500) == 0)
            {
                this.move = true;
                this.transform.eulerAngles = this.takeoff;
                this.GetComponent<Rigidbody>().linearVelocity = Vector3.forward / 5;
            }
        } else
        {
            if (this.rand.Next(30) == 0)
            {
                float randx = (float)this.rand.NextDouble() * 10f;
                float randy = (float)this.rand.NextDouble() * 10f;
                float randz = (float)this.rand.NextDouble() * 10f;
                this.transform.Rotate(randx, randy, randz);
            }
        }
        this.transform.Translate(GetComponent<Rigidbody>().linearVelocity);
    }
}
