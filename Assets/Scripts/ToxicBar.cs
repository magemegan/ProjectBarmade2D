using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToxicBar : MonoBehaviour
{
    public Slider slider;
    
    
    public void SetMaxDrunkness(float toxic)
    {
        slider.maxValue = toxic;
        slider.value = 0;
        
    }

    public void SetDrunkness(float toxic)
    {
        slider.value = toxic;

        
    }

}
