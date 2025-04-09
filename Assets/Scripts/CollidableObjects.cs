using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObjects : MonoBehaviour
{
    private Collider2D z_Collider;
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects;

    private void Start()
    {
        z_Collider = GetComponent<Collider2D>();

    }

    private void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
        foreach(var o in z_CollidedObjects)
        {
            Debug.Log("Colliede with " + o.name);
        }
    }

}
