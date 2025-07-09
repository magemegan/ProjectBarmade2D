using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTray : MonoBehaviour
{
    public float iceTrayVolume = 0f; // TODO: Instead of being public we should have a getter/setter. 
    public float iceMachineVolume = 100f;
    [SerializeField] private Animator animator;


    void Update()
    {
        if (!animator)
        {
            return;
        }
        if (iceTrayVolume <= 100f && iceTrayVolume > 50f)
        {
            animator.SetBool("isHalfEmpty", false); // TODO: This can definetley be optimized. Also this should be in a function not in the update function
            animator.SetBool("isFull", true);
        }
        else if (iceTrayVolume <= 50f && iceTrayVolume > 0f)
        {
            animator.SetBool("isFull", false);
            animator.SetBool("isHalfEmpty", true);
        }
        else
        {
            animator.SetBool("isHalfEmpty", false);
            animator.SetBool("isFull", false);
        }

        // TODO: IceTray should inherit from interaction controller. Therefore we will also need private void increaseTrayVolume(amount) and decreaseTrayVolume(amount)
        if (Input.GetKeyDown(KeyCode.E)){ //temp way to increase value
            if (iceTrayVolume < 100f)
            {
                iceTrayVolume += 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)){ //temp way to decrease value
            if (iceTrayVolume > 0f)
            {
                iceTrayVolume -= 1f;
            }
        }    

    }
}
