using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandableUIManager : MonoBehaviour
{
    [Tooltip("List of all UI elements that can be expanded/collapsed")]
    [SerializeField] private List<GameObject> expandableElements = new List<GameObject>();

    [Tooltip("Distance between UI elements when not expanded")]
    [SerializeField] private float defaultSpacing = 10f;

    [Tooltip("Spacing buffer when elements expand")]
    [SerializeField] private float expansionBuffer = 5f;

    private Dictionary<GameObject, ExpandableUIElement> elementScripts = new Dictionary<GameObject, ExpandableUIElement>();
    private Dictionary<GameObject, RectTransform> elementRects = new Dictionary<GameObject, RectTransform>();

    private void Awake()
    {
        // Initialize and setup all expandable elements
        foreach (GameObject element in expandableElements)
        {
            // Make sure each element has the ExpandableUIElement script
            if (!element.TryGetComponent<ExpandableUIElement>(out var expandableScript))
            {
                expandableScript = element.AddComponent<ExpandableUIElement>();
            }

            elementScripts[element] = expandableScript;
            elementRects[element] = element.GetComponent<RectTransform>();

            // Make sure each element has a BoxCollider2D
            if (!element.TryGetComponent<BoxCollider2D>(out var collider))
            {
                collider = element.AddComponent<BoxCollider2D>();
                collider.isTrigger = true;
            }

            // Size the collider to match the RectTransform
            UpdateColliderSize(element);
        }

        // Arrange the elements with default spacing
        //ArrangeElements();
    }

    //!Also useless function
    /*public void ArrangeElements()
    {
        float currentY = 0;

        foreach (GameObject element in expandableElements)
        {
            RectTransform rectTransform = elementRects[element];

            // Position the element
            Vector2 position = rectTransform.anchoredPosition;
            position.y = currentY;
            rectTransform.anchoredPosition = position;

            // Update position for next element
            currentY -= (rectTransform.rect.height + defaultSpacing);
        }
    }*/

    private void UpdateColliderSize(GameObject element)
    {
        if (element.TryGetComponent<BoxCollider2D>(out var collider) &&
            element.TryGetComponent<RectTransform>(out var rectTransform))
        {
            // Size the collider to match the RectTransform
            collider.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);

            // Center the collider
            collider.offset = new Vector2(0, 0);
        }
    }

    // Call this whenever an element's size changes
    public void ElementSizeChanged(GameObject element)
    {
        if (expandableElements.Contains(element))
        {
            UpdateColliderSize(element);
        }
    }
    
    //!Potentially not needed function
    // Method to expand/collapse a specific UI element
    /*public void ToggleElementExpansion(GameObject element, bool expanded)
    {
        Debug.Log("Expanded element");
        if (!expandableElements.Contains(element))
            return;
            
        RectTransform rect = elementRects[element];
        
        // Your expansion/collapse animation or size change logic here
        // Example: changing height of element
        float newHeight = expanded ? 200f : 100f; // Change these values as needed
        
        // Resize the element
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
        
        // Update the collider size to match
        UpdateColliderSize(element);
    }*/
}