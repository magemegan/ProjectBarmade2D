using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private int executeTime;
    
    public int minSpawnWait;
    public int maxSpawnWait;
    public GameObject NPCObject;
    
    void Start()
    {
        // Set inital start spawn time
        executeTime = Mathf.RoundToInt(Time.time) + Random.Range(minSpawnWait, maxSpawnWait); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.RoundToInt(Time.time) == executeTime){
            // Check for open seat
            foreach (GameObject seat in GameObject.FindGameObjectsWithTag("Seat"))
            {
                // Check if the seat is occupied
                if (!seat.GetComponent<NPCObjects>().GetOccupied())
                {
                    Vector2 spawnPosition = new Vector2(0, 3);
                    Instantiate(NPCObject, spawnPosition, Quaternion.identity);
                    break;
                }
            }
            executeTime = executeTime + Random.Range(minSpawnWait, maxSpawnWait);
        }
    }
}

/* 
 * ***** TODO ***** 
 * change interval variable name (DONE)
 * use world time instead of counter (DONE)
 * set seat occupied to true
 * create function to despawn npc
*/
