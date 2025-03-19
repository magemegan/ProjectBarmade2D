using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrinkMixing : MonoBehaviour, IPointerClickHandler
{
    public enum DrinkType { Alcohol, Soda }
    public GameObject[] AlcoholBottles;
    public GameObject[] SodaBottles;

    [Header("Ice Values")]
    [SerializeField]
    private GameObject iceTray;
    private float iceVolume;
    [SerializeField]
    private GameObject iceSprite;
    [SerializeField]
    private Transform iceTrayUI;

    // Start is called before the first frame update
    void Start()
    {
        iceVolume = iceTray.GetComponent<IceTray>().iceTrayVolume;
        Debug.Log(iceVolume);
        for(int i = 0;i < iceVolume; i+=5) {
            Instantiate(iceSprite, iceSprite.transform.position, iceSprite.transform.rotation, iceTrayUI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);
    }
}
