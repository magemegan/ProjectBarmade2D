using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    private PickUp pickUp;
    private Vector3 change;

   void Start()
    {
        
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, -1);
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Verticle");
        if (change.sqrMagnitude > .5f)
        {
            pickUp.Direction = change.normalized;
        }
        
    }


}
