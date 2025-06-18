using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIteract : MonoBehaviour
{
    [SerializeField]private float sobering = 1f;

    public float maxDrunk = 100;
    public float currentDrunkness = 0;
    public bool addedDrink = false;
    public ToxicBar toxicBar;
    [SerializeField]private float NPCtolerance;
    private float soberTimer = 0f;
    [SerializeField] private float soberSeconds;


private void Update()
{
    soberTimer += Time.deltaTime;
    if (currentDrunkness > 0)
    {
        if (soberTimer >= soberSeconds)
        {
            currentDrunkness -= sobering;
            toxicBar.SetDrunkness(currentDrunkness);
            soberTimer = 0f;
        }
        
    }

}
private void Start()
    {
        toxicBar.SetDrunkness(currentDrunkness);

        toxicBar.SetMaxDrunkness(50);
    }




    public void AddDrink(int drunk)
    {
       
        float initialToxic = Random.Range(5, drunk);
        float reduceIntoxication = initialToxic * NPCtolerance;
        float finalIntoxication = initialToxic - reduceIntoxication;
        
        currentDrunkness = Mathf.Clamp(currentDrunkness + finalIntoxication, 0, maxDrunk);

        toxicBar.SetDrunkness(currentDrunkness);
    }

}
