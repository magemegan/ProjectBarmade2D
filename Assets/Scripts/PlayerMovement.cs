using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PickUp pickUp;
    public float moveSpeed;
    Rigidbody2D rb;
    private Vector2 movement;
    public bool movementEnabled;
    public bool collidingWithDishwasher = false;
    public bool touchingSink = false;

    // Start is called before the first frame update
    void Start()
    {
        // Interactable setup
        pickUp = gameObject.GetComponent<PickUp>();
        //pickUp.Direction = new Vector2(0, -1);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get keyboard input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Discover what the player is looking at
        if (movement.sqrMagnitude > .1f)
        {
            //pickUp.Direction = movement.normalized;
        }

        movement = movement.normalized;// Normalize movement to prevent faster diagonal movement
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dishwasher"))
        {
            Debug.Log("touching dishwasher");
            collidingWithDishwasher = true;
        }
        else if (collision.gameObject.CompareTag("Sink"))
        {
            touchingSink = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dishwasher"))
        {
            collidingWithDishwasher = false;

        }
        else if (collision.gameObject.CompareTag("Sink"))
        {
            touchingSink = false;
        }
    }


    void FixedUpdate()
    {
        if(movementEnabled) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}

