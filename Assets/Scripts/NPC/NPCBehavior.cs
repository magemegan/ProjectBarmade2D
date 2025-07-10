using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    // Movement variables
    bool moveHorizontally, moveVertically;
    GameObject[] chairs;
    GameObject leavePoint;
    Vector2 destination, position;

    private GameObject seat;

    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Interaction variables
    private float sobering = 1f;
    private float NPCTolerance = 0f;
    private float soberSeconds = 10f; // Time in seconds to sober up
    private float soberTimer = 0f;
    private float currentDrunkness = 0;
    private float maxDrunk = 100;
    private GameObject drunkMeter;
    private ToxicBar toxicBar;


    // Start is called before the first frame update
    void Start()
    {
        leavePoint = GameObject.Find("LeavePoint"); // good
        spriteRenderer = GetComponent<SpriteRenderer>();
        drunkMeter = gameObject.transform.Find("DrunkMeter").gameObject; // Find the drunk meter in the NPC's hierarchy  
        toxicBar = drunkMeter.transform.Find("ToxicBar").GetComponent<ToxicBar>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeavePoint")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() // TODO: We should remove behavior from Update and put into functions
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

        // Handle intoxication
        if (!moveVertically && !moveVertically) // Do not sober up while moving
        {
            drunkMeter.SetActive(true);
            if (currentDrunkness > 0 && toxicBar)
            {
                if (soberTimer >= soberSeconds)
                {
                    currentDrunkness -= sobering;
                    soberTimer = 0f;
                }
                else
                {
                    soberTimer += Time.deltaTime;
                }
                toxicBar.SetDrunkness(currentDrunkness);
            }
        }
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

    public void AddDrink(int drunk)
    {
        float initialToxic = Random.Range(5, drunk); // TODO: rename variable to be more clear
        float reduceIntoxication = initialToxic * NPCTolerance; // TODO: rename variable
        float finalIntoxication = initialToxic - reduceIntoxication;

        currentDrunkness = Mathf.Clamp(currentDrunkness + finalIntoxication, 0, maxDrunk);
        toxicBar.SetDrunkness(currentDrunkness);
    }

    public void SetDrunkMeter(GameObject meter)
    {
        drunkMeter = meter;
        meter.transform.parent = gameObject.transform; // Set the meter as a child of the NPC
        toxicBar = drunkMeter.GetComponent<ToxicBar>();
    }
}
