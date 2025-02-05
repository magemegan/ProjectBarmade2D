using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObjects : MonoBehaviour
{
    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

        // Generate a random position on the screen

        Vector2 spawnPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));



        // Instantiate the enemy at the spawn position

        Instantiate(NPC, spawnPosition, Quaternion.identity);
        }
    }
}
