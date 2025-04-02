using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickUpMask;
    public LayerMask npcMask;
    public Vector3 Direction { get; set; }
    private GameObject itemHolding;
    public bool touchingDrink = false;
    int toxicMeter = 0;
    //public NPCIteract toxicBar;
    public GameObject NPC;
    
  

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                Collider2D NPC = Physics2D.OverlapCircle(transform.position + Direction, 1f, npcMask);
                if (NPC)
                {
                    HandleCollisionWithNpc();
                }
                else
                {
                    DropItem();
                }
                
            }
            else if(touchingDrink)
            {
                
                Debug.Log("Picked up: " + gameObject.name);
                itemHolding = gameObject;
                itemHolding.transform.position = holdSpot.position;
                itemHolding.transform.parent = holdSpot;
                Rigidbody2D rb = itemHolding.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }
            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("touching drink");
            touchingDrink = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            touchingDrink = false;
        }
    }

    void DropItem()
    {
        Debug.Log("Dropping item.");
        itemHolding.transform.position = transform.position + Direction;
        itemHolding.transform.parent = null;
        Rigidbody2D rb = itemHolding.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        itemHolding = null;
        Destroy(rb);
    }
    void HandleCollisionWithNpc()
    {
        Debug.Log("Handling collision with NPC.");
        Collider2D npcCollider = Physics2D.OverlapCircle(transform.position + Direction, 1f, npcMask);
        if (npcCollider != null)
        {
          
            GiveItemToNpc(npcCollider.gameObject);
        }
    }

    void GiveItemToNpc(GameObject npc)
    {
        //toxicBar.AddDrink(10);
        Debug.Log("Giving item to NPC.");
        //Destroy(itemHolding);
        
        itemHolding.transform.position = new Vector3(1000, 1000, 0);
        itemHolding.SetActive(false);
        itemHolding = null;

        NPC.GetComponent<NPCIteract>().AddDrink(10);


    }

    
}

