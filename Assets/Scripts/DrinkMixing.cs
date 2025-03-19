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
    [SerializeField]
    private float iceCubePositionOffset = 30f;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn ice cubes in the tray based on the ice tray volume
        populateIceTray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);
    }

    private void populateIceTray() {
        iceVolume = iceTray.GetComponent<IceTray>().iceTrayVolume;
        float containerWidth = iceTrayUI.GetComponent<RectTransform>().rect.width;
        float containerHeight = iceTrayUI.GetComponent<RectTransform>().rect.height;
        float xCounter = 0f;
        float yCounter = 0f;
        Debug.Log(iceVolume);
        Vector3 cubePosition = iceSprite.transform.position;
        Vector3 ogPosition = cubePosition;
        for(float i = 0f;i < iceVolume; i+=2.5f) {
            if(xCounter < containerWidth) {
                GameObject iceCube = Instantiate(iceSprite, cubePosition ,iceSprite.transform.rotation, iceTrayUI);
                cubePosition.x += iceCubePositionOffset;
                iceCube.SetActive(true);
                xCounter += iceCubePositionOffset;
            } else if(yCounter < containerHeight) {
                yCounter += iceCubePositionOffset;
                cubePosition.y += iceCubePositionOffset;
                cubePosition.x = ogPosition.x;
                xCounter = 0f;
            }
        }
    }
}
