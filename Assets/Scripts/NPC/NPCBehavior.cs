using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    bool moveHorizontally, moveVertically;
    GameObject[] chairs;
    GameObject leavePoint;
    Vector2 destination, position;

    private GameObject seat;

    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        leavePoint = GameObject.Find("LeavePoint"); // good
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeavePoint")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!seat) { return; }

        if (!moveVertically && Mathf.Round(position.x) != Mathf.Round(destination.x))
        {
            moveHorizontally = true;
            moveVertically = false;
        }
        else if (!moveHorizontally && Mathf.Round(position.y) != Mathf.Round(destination.y))
        {
            moveVertically = true;
            moveHorizontally = false;
        }

        if (Mathf.Round(position.x) == Mathf.Round(destination.x)) moveHorizontally = false;
        if (Mathf.Round(position.y) == Mathf.Round(destination.y)) moveVertically = false;


        if (moveHorizontally){
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);
            if (position.x > destination.x){
                position.x = position.x - 0.01f;
                spriteRenderer.flipX = false;
                animator.SetBool("isHorizontal", true);
            }
            else{
                position.x = position.x + 0.01f;
                spriteRenderer.flipX = true;
                animator.SetBool("isHorizontal", true);
            }
        }
        else if (moveVertically){
            animator.SetBool("isHorizontal", false);
            if (position.y > destination.y){
                position.y = position.y - 0.01f;
                animator.SetBool("isDown", true);
            }
            else{
                position.y = position.y + 0.01f;
                animator.SetBool("isUp", true);
            }      
        }

        if (Mathf.Round(position.x) == Mathf.Round(destination.x) && Mathf.Round(destination.y) == Mathf.Round(position.y))
        {
                animator.SetBool("isHorizontal", false);
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", false);
        }

        transform.position = position;
    }
    
    public void SetSeat(GameObject seat)
    {
        this.seat = seat;
        destination = seat.transform.position; //Finds a designated GameObject
        position = transform.position; // NPC's position
    }

    public void Leave()
    {
        if (seat != null)
        {
            seat.GetComponent<NPCObjects>().SetOccupied(false); // Set the seat as unoccupied when NPC is destroyed
            seat = leavePoint;
            destination = seat.transform.position;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0)) {
            Leave();
        }
    }
}
