using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private int executeTime;
    
    public int minSpawnWait;
    public int maxSpawnWait;
    public GameObject NPCObject;
    public GameObject spawnPoint;

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
                    Vector2 spawnPosition = spawnPoint.transform.position; // Get the spawn position from the spawn point
                    GameObject NPC = Instantiate(NPCObject, spawnPosition, Quaternion.identity);
                    NPC.GetComponent<NPCBehavior>().SetSeat(seat); // Give NPC seat property
                    NPC.SetActive(true); // Show NPC
                    seat.GetComponent<NPCObjects>().SetOccupied(true); // Set seat as occupied
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
 * set seat occupied to true (DONE)
 * create function to despawn npc (DONE)
*/
