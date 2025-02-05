using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        Vector2 position2;
        position2.x = -6;
        position2.y = 0;

        if (position.x > position2.x){
            position.x = position.x - 0.01f;
        }
        
        if (position.x < position2.x){
            position.x = position.x + 0.01f;
        }

        
        if (position.y > position2.y){
             position.y = position.y - 0.01f;
        }
        
        if (position.y < position2.y){
            position.y = position.y + 0.01f;
        }
        transform.position = position;
    }
}
