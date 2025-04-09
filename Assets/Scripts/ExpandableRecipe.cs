using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExpandableRecipe : MonoBehaviour, IPointerClickHandler
{
    private bool expanded;
    [SerializeField]
    private GameObject collapsedRecipePanel;
    [SerializeField]
    private GameObject expandedRecipePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);
        if(expanded) {
            collapsedRecipePanel.SetActive(false);
            expandedRecipePanel.SetActive(true);
        } else {
            collapsedRecipePanel.SetActive(true);
            expandedRecipePanel.SetActive(false);
        }
    }
}
