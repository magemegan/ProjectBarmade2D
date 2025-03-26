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
    private float objPositionOffset = 30f;

    [Header("Ice Values")]
    [SerializeField]
    private int limesVolume;
    [SerializeField]
    private GameObject limeSprite;
    [SerializeField]
    private Transform limeTrayUI;


    // Start is called before the first frame update
    void Start()
    {
        //Spawn ice cubes in the tray based on the ice tray volume
        populateTray(iceTray.GetComponent<IceTray>().iceTrayVolume, iceTrayUI, iceSprite);

        //Spawn limes in the tray based on the lime tray volume
        populateTray(limesVolume, limeTrayUI, limeSprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);
    }

    private void populateTray(float volume, Transform UI, GameObject sprite) {
        float containerWidth = UI.GetComponent<RectTransform>().rect.width;
        float containerHeight = UI.GetComponent<RectTransform>().rect.height;
        float xCounter = 0f;
        float yCounter = 0f;
        Vector3 position = sprite.transform.position;
        Vector3 ogPosition = position;
        //Generate as many ice cubes as there are ice in ice tray
        for(float i = 0f;i < volume; i+=2.5f) {
            if(xCounter < containerWidth) {//Fill line with ice
                float randomRotation = Random.Range(0f, 360f);
                GameObject obj = Instantiate(sprite, position, Quaternion.Euler(0,0,randomRotation), UI);
                position.x += objPositionOffset;
                obj.SetActive(true);
                xCounter += objPositionOffset;
            } else if(yCounter < containerHeight) {//Start generating ice on a new line
                yCounter += objPositionOffset;
                position.y += objPositionOffset;
                position.x = ogPosition.x;
                xCounter = 0f;
            }
        }
    }
}
