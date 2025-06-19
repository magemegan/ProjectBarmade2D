using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//READ THIS: MOST, IF NOT ALL OF THE PUBLIC VARIABLES ARE BEING ASSIGNED TO THE GREEN CIRCLE NPCPOINT!


public class NPCObjects : MonoBehaviour
{
    public bool occupied = false;

    public void SetOccupied(bool isOccupied)
    {
        occupied = isOccupied;
    }

    public bool GetOccupied()
    {
        return occupied;
    }
}


/*
 * TODO:
 *  delete unused functions (DONE)
 *  write update variable function (DONE)
 *  seat manager + npc manager (DONE)
 *  put all seat objects under parent object (so that i can loop through) (DONE)
*/