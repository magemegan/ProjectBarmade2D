using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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