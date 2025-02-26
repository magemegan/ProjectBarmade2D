using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    bool xHigher;
    bool yHigher;
    public GameObject[] chairs;
    int index = 0;
    bool foundChair;

    void Awake(){
        foundChair = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, chairs.Length);
    }
    //chairs[index].GetComponent<NPCObjects>().occupied = true; <- Code for future me to use to set a position as occupied
    // Update is called once per frame
    void Update()
    {
        GameObject chairChoose = chairs[index];
        Vector2 pointPos = chairChoose.transform.position; //Finds a designated GameObject. Will be changed later, since we need to find multiple objects
        Vector2 position = transform.position; // NPC's position
        if (chairs[index].GetComponent<NPCObjects>().occupied == false && foundChair == false){
            if (Mathf.Round(position.x) != Mathf.Round(pointPos.x) && yHigher == false){
                xHigher = true;
            }
            else if (Mathf.Round(position.y) != Mathf.Round(pointPos.y) && xHigher == false){
                yHigher = true;
            }
            else if (Mathf.Round(position.x) == Mathf.Round(pointPos.x)){
                xHigher = false;
            }
            else if (Mathf.Round(position.y) == Mathf.Round(pointPos.y)){
                yHigher = false;
            }

            if (xHigher == true){
                if (position.x > pointPos.x){
                    position.x = position.x - 0.01f;
                }
                else{
                    position.x = position.x + 0.01f;
                }
            }
            if (yHigher == true){
                if (position.y > pointPos.y){
                    position.y = position.y - 0.01f;
                }
                else{
                    position.y = position.y + 0.01f;
                }      
            }
        }
        else{
            index = Random.Range(0, chairs.Length);
            chairChoose = chairs[index];
            pointPos = chairChoose.transform.position;
        }
        if (chairs[index].GetComponent<NPCObjects>().occupied == false && Mathf.Round(position.x) == Mathf.Round(pointPos.x) && Mathf.Round(pointPos.y) == Mathf.Round(position.y)){
            chairs[index].GetComponent<NPCObjects>().occupied = true;
            foundChair = true;
        }
        transform.position = position;
    }
}
