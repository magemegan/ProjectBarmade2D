using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : CollidableObjects
{
    protected override void OnCollided(GameObject collidedObject)
    {
        if (Input.GetKey(KeyCode.E))
        {

        }
    }

    private void OnInteract()
    {

    }

}
