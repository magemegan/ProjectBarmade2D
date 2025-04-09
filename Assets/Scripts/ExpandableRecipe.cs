using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExpandableRecipe : MonoBehaviour, IPointerClickHandler
{
    private bool expanded = false;
    [SerializeField]
    private GameObject collapsedRecipePanel;
    [SerializeField]
    private GameObject expandedRecipePanel;
    // Start is called before the first frame update
    void Start()
    {
        expanded = !collapsedRecipePanel.activeInHierarchy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("UI Image clicked: " + gameObject.name);
        if(!expanded) {
            Debug.Log("Expanding");
            expanded = true;
            collapsedRecipePanel.SetActive(false);
            expandedRecipePanel.SetActive(true);
        } else {
            Debug.Log("Collapsing");
            expanded = false;
            collapsedRecipePanel.SetActive(true);
            expandedRecipePanel.SetActive(false);
        }
    }
}
