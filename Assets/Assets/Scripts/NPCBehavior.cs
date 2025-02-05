using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public bool xHigher;
    public bool yHigher;
    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pointPos = GameObject.Find("NpcPoint2").transform.position; //Finds a designated GameObject. Will be changed later, since we need to find multiple objects
        Vector2 position = transform.position; // NPC's position
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
        transform.position = position;
    }
}
