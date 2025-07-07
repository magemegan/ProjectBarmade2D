using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private bool spawnNPC;
    int startTime;
    public int changeInterval1;
    public int changeInterval2;
    public GameObject NPC;
    
    void Start()
    {
        spawnNPC = true;
        startTime = startTime + Random.Range(changeInterval1, changeInterval2);
    }


    void Update()
    {
        if (Mathf.Round(Time.time) == startTime && spawnNPC == true){
        

        Vector2 spawnPosition = new Vector2(0, 3);


        Instantiate(NPC, spawnPosition, Quaternion.identity);

        startTime = startTime + Random.Range(changeInterval1, changeInterval2);
        }
    }
}
