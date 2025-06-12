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
    public float time; //Reads time accurately without spamming the debug log. Will try to find a way to make it to debug, but for now this will work.
    //You can view time by inspecting the Spawner GameObject.
    // Start is called before the first frame update
    void Start()
    {
        spawnNPC = true;
        startTime = startTime + Random.Range(changeInterval1, changeInterval2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(Time.time) == startTime && spawnNPC == true){
        

        Vector2 spawnPosition = new Vector2(0, 3);


        Instantiate(NPC, spawnPosition, Quaternion.identity);

        startTime = startTime + Random.Range(changeInterval1, changeInterval2);
        }

        time = Mathf.Round(Time.time);

        // Debug.Log("Time Passed: " + Mathf.Round(Time.time));
        // Leaving this here in case you want to see time on debug log. Reasoning above.
    }
}

/* 
 * ***** TODO ***** 
 * change interval variable name
 * use world time instead of counter
 * set seat occupied to true
 * create function to despawn npc
*/
