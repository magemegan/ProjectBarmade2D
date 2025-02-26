using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIce : MonoBehaviour
{
    public bool withIce = false;
    public GameObject Icetray;
    public GameObject IceMachine;

    private bool CollidingWithIceTray = false;
    private bool CollidingWithIceMachine = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CollidingWithIceMachine)
        {
            FromIceMachine();
            withIce = true;
            //Debug.Log("Refilling from ice machine");
        }
        if (Input.GetKeyDown(KeyCode.E) && CollidingWithIceTray)
        {
            if (withIce)
            {
                RefillIceTray();
                withIce = false;
                Debug.Log("refilling ice tray...");
            }
            else
            {
                Debug.Log("need ice from machine first....");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ice Tray"))
        {
            CollidingWithIceTray = true;
        }
        if (other.gameObject.CompareTag("Ice Machine"))
        {
            CollidingWithIceMachine = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ice Tray"))
        {
            CollidingWithIceTray = false;
        }
        if (other.gameObject.CompareTag("Ice Machine"))
        {
            CollidingWithIceMachine = false;
        }
    }

    void RefillIceTray()
    {
        //this refills the ice trays
        Icetray.GetComponent<IceTray>().iceTrayVolume = 100f;
    }

    void FromIceMachine()
    {
        //this refills the ice from machine
        Debug.Log("Refilling from ice machine");
        //Icetray.GetComponent<IceTray>().iceMachineVolume = 0f;
    }
}
