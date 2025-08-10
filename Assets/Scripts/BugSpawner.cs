using System;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    float lastSpawn; //ticker
    const int secCheck = 1; //How many seconds before it attempts to spawn another bug
    const int maxBugs = 10; //Max allowed bugs to spawn
    System.Random rand = new System.Random(146); //Seed gets 1 on first rand(1,101)
    System.Random locRand = new System.Random(); //Seedless to determine new experience each gameloop
    [SerializeField] GameObject[] tBugList = new GameObject[3]; //Add via editor until have less problems finding prefabs
    List<GameObject> inField;
    List<GameObject> caught;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //do we want max bugs spawned on start and to replace them?
        this.lastSpawn = secCheck;
        this.inField = new List<GameObject>(10);
        this.caught = new List<GameObject>();
    }

    // Update is called once per frame
    //collision detection for spawn done in start script of bug, allows for spawning inside items then remove into bounds
    void Update()
    {
        if (this.lastSpawn >= secCheck) //time passed, random determ
        {
            lastSpawn = 0; //reset ticker
            if(this.rand.Next(1,101) <= (maxBugs - this.inField.Count)) {
                //consider spawn not being able to happen within radius of player of player view for imersion (future project)
                float x = (float)this.rand.NextDouble()*8;
                float y = (float)this.rand.NextDouble() + 1f;
                float z = (float)this.rand.NextDouble()*10-54;
                this.inField.Add(GameObject.Instantiate(this.tBugList[0],
                                                        new Vector3(x, y, z), //change this vector to better encompass area
                                                        Quaternion.identity)
                );

            }
        } else { //not enough time since last check
            this.lastSpawn += Time.deltaTime;
        }
        for (int i = 0; i < this.inField.Count; i++)
        {
            if (!this.inField[i].GetComponent<BugBase>().getCaught()) { this.inField[i].SetActive(true); } else 
            {
                this.caught.Add(this.inField[i]);
                this.inField.RemoveAt(i);
            }
        }
        for (int i = 0; i < this.caught.Count; i++)
        {
            this.caught[i].SetActive(false);
        }
    }
}
