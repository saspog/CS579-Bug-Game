using System;
using UnityEngine;

//Generalized physical object class under gravitational field
public class physObj
{
    GameObject obj; //Given Object
    bool gravchk; //Affected by gravity?
    float[] coordsvec; //center of mass coordinates obj storage
    float[,] omeg; //object bounds
    float[] vvec; //velocity of obj
    const float g = 0.2f; //gravity in m/s

    //Constructs point physObj with a 0 velocity given a position
    public physObj(float[] coords, bool grav)
    {
        this.coordsvec = coords;
        this.gravchk = grav;
        this.omeg = new float[1, 3];
        this.vvec = new float[3];
        for (int i = 0; i < 3; i++)
        {
            this.omeg[0, i] = this.coordsvec[i];
        }
    }   

    public void setObj(GameObject obj) {this.obj = obj;}

    public GameObject getObj() {return this.obj;}

    public void setGrav(bool grav) {this.gravchk = grav;}

    public bool getGrav() {return this.gravchk;}

    public void setCoords(float[] coords) {this.coordsvec = coords;}

    public float[] getCoords() {return this.coordsvec;}

    public void setBounds(float[,] omeg) {this.omeg = omeg;}

    public float[,] getBounds() {return this.omeg;}

    public void setVel(float[] vvec) {this.vvec = vvec;}

    public float[] getVel() {return this.vvec;}

    //Updates coordvecs with a given graviational field as perscribed in universal gravity model
    public void gravUpd()
    {
        int fps = (int)Math.Floor(1.0f / Time.deltaTime);
        float gNorm = g / fps;
        this.vvec[1] = this.vvec[1] - gNorm;
        this.coordsvec[1] += this.vvec[1];
    }
}
