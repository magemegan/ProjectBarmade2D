using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFloorCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) {
            BoxCollider2D collider = child.gameObject.GetComponent<BoxCollider2D>();
            if(collider != null) {
                collider.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
