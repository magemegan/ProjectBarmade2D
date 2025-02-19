using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//READ THIS: MOST, IF NOT ALL OF THE PUBLIC VARIABLES ARE BEING ASSIGNED TO THE GREEN CIRCLE NPCPOINT!


public class NPCObjects : MonoBehaviour
{
    public GameObject NPC;
    private bool spawnNPC;
    public int startTime;
    public int changeInterval1;
    public int changeInterval2;
    public bool occupied = false;
    public bool mainPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnNPC = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(Time.time) == startTime && spawnNPC == true && mainPoint == true){
        
        // Generate a random position on the screen

        Vector2 spawnPosition = new Vector2(0, 4);



        // Instantiate the enemy at the spawn position

        Instantiate(NPC, spawnPosition, Quaternion.identity);

        startTime = startTime + Random.Range(changeInterval1, changeInterval2);
        }
        Debug.Log("Current in-game time: " + Mathf.Round(Time.time)); 
        
    }
}
