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
<<<<<<< Updated upstream:Assets/Scripts/NPCPoint.cs
        //Debug.Log("Current in-game time: " + Mathf.Round(Time.time)); 
        
=======
        Debug.Log("Current in-game time: " + Mathf.Round(Time.time)); 
>>>>>>> Stashed changes:Assets/Scripts/SpawnerController.cs
    }
}
