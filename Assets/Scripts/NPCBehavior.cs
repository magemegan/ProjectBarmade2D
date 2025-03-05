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
    public GameObject leavePoint;
    bool finished;

    void Awake(){
        foundChair = false;
        finished = false;
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
        Vector2 pointPos = chairChoose.transform.position; //Finds a designated GameObject
        Vector2 position = transform.position; // NPC's position

        if (finished == true){
            chairChoose = leavePoint;
            pointPos = chairChoose.transform.position;
        }
        

        if ((chairs[index].GetComponent<NPCObjects>().occupied == false && foundChair == false) || finished == true){
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
        else{
                chairs[index].GetComponent<NPCObjects>().occupied = false;
        }//Prototype for leaving a space open after the NPC leaves. NPCS go a little crazy if occupied during their trip to a space.

        if (Input.GetKeyDown(KeyCode.Space)){
            finished = true;
            chairs[index].GetComponent<NPCObjects>().occupied = false;
            chairChoose = leavePoint;
            pointPos = chairChoose.transform.position;
        } //Works, but affects all NPCs, which may just be something that we'll have to wait to fix.

        transform.position = position;
    }
}
