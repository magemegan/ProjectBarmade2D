using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PickUp pickUp;
    public float moveSpeed; // TODO: Serialzie
    Rigidbody2D rb; // TODO: Needs to be renamed 
    private Vector2 movement;
    // TODO: Either make private or serialize variables below
    public bool movementEnabled;
    public bool collidingWithDishwasher = false; // TODO: We should not be handling this here
    public bool touchingSink = false; // TODO: We should not be handling this here

    private Animator mAnimator; // TODO: rename

    // Start is called before the first frame update
    void Start()
    {
        // Interactable setup
        pickUp = gameObject.GetComponent<PickUp>();
        rb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get keyboard input
        movement.x = Input.GetAxisRaw("Horizontal"); // TODO: These should be put in a function
        movement.y = Input.GetAxisRaw("Vertical");
        // Discover what the player is looking at
        if (movement.sqrMagnitude > .1f)
        {
            //pickUp.Direction = movement.normalized;
        }

        movement = movement.normalized;// Normalize movement to prevent faster diagonal movement

        // Handle animations 
        if (mAnimator) // TODO: Handle animations should be in a function
        {
            mAnimator.SetBool("isBack", Input.GetKey(KeyCode.W));
            mAnimator.SetBool("isRight", Input.GetKey(KeyCode.D));
            mAnimator.SetBool("isForward", Input.GetKey(KeyCode.S));
            mAnimator.SetBool("isLeft", Input.GetKey(KeyCode.A));
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // TODO: Just delete these
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


    void FixedUpdate() // TODO: what is this???? Clarify
    {
        if(movementEnabled) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}

