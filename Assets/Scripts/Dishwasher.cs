using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishwasher : MonoBehaviour
{
    public GameObject Itemholder;

    private bool CollidingWithPlayer = false;
    private int ItemsHeld = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if player is colliding with dishwasher and presses E
        if (Input.GetKeyDown(KeyCode.E) && CollidingWithPlayer)
        {
            ItemsHeld = Itemholder.transform.childCount;
            if (ItemsHeld > 0)
            {
                // check if glass is dirty
                if (Itemholder.transform.GetChild(0).GetComponent<Glass>().dirtyGlass)
                {
                    Debug.Log("Glass is dirty");
                    //use coroutine to simulate an actual dishwasher similar to threads
                    StartCoroutine(WashDishes());

                    //clean glass
                    Itemholder.transform.GetChild(0).GetComponent<Glass>().dirtyGlass = false;
                }
                else
                {
                    Debug.Log("Glass is clean");
                }

                Debug.Log("placing item in dishwasher");
                //transfer glass from player to dishwasher
                Itemholder.transform.GetChild(0).SetParent(gameObject.transform);
            }
            else
            {
                Debug.Log("Player not holding anything");
                if(gameObject.transform.childCount > 0)
                {
                    Debug.Log("picking item from dishwasher");
                    //transfer glass from dishwasher to player
                    gameObject.transform.GetChild(0).SetParent(Itemholder.transform);
                }
            }
                //move glass to the correct position
                //Itemholder.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);

        }
    }

    IEnumerator WashDishes()//similar to threads but this is unity version.
    { //the IEnumerator is important for coroutine.
        //this is a coroutine that simulates washing dishes
        Debug.Log("Washing dishes...");
        yield return new WaitForSeconds(5);//simialr to .Next(5000) which means 5 secs
        Debug.Log("Dishes are clean");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollidingWithPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollidingWithPlayer = false;
        }
    }
}
