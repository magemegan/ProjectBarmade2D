using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public float fullness;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fullness <= 100f && fullness > 50f)
        {
            animator.SetBool("isFull", true);
        }
        else
        {
            animator.SetBool("isFull", false);
        }

        // if (Input.GetKeyDown(KeyCode.E)){ //temp way to increase value
        //     fullness = 100f;
        // }

        // if (Input.GetKeyDown(KeyCode.Q)){ //temp way to decrease value
        //     fullness = 0f;
        // } 
    }

    public void addFullness(int num){
        fullness += num;
        Debug.Log("Trash Filled");
    }
}
