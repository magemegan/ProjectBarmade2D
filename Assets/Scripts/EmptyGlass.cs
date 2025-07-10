using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGlass : MonoBehaviour // TODO: Rename to EmptyGlass
{
    private bool isDirty = true; 

    bool IsDirty
    {
        get { return isDirty; }
        set { isDirty = value; }
    }
}

// TODO: This should inherit from a HoldableObject class and have behavior allowing it to interact with player holder