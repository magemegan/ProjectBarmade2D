using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIteract : MonoBehaviour
{
    public float maxDrunk = 100;
    public float currentDrunkness = 0;
    public bool addedDrink = false;
    public ToxicBar toxicBar;
    public float NPCtolerance;
    // value from 0 - 1
    


    private void Start()
    {
        toxicBar.SetDrunkness(currentDrunkness);

        toxicBar.SetMaxDrunkness(100);
    }


    private void Update()
    {
       

    }

    public void AddDrink(int drunk)
    {
        //addedDrink = true;
        //currentDrunkness += drunk;
        float initialToxic = Random.Range(5, drunk);
        float reduceIntoxication = initialToxic * NPCtolerance;
        float finalIntoxication = initialToxic - reduceIntoxication;
        
        currentDrunkness = Mathf.Clamp(currentDrunkness + finalIntoxication, 0, maxDrunk);

        toxicBar.SetDrunkness(currentDrunkness);
    }

}
