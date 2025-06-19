using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
public class ExpandableElement : MonoBehaviour, IPointerClickHandler
{
    [Header("Expansion Settings")]
    [SerializeField] private float collapsedHeight = 100f;
    [SerializeField] private float expandedHeight = 200f;
    [SerializeField] private float animationDuration = 0.3f;
    [SerializeField] private AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    
    [Header("References")]
    [SerializeField] private ExpandableUIManager uiManager;
    
    private RectTransform rectTransform;
    private bool isExpanded = false;
    private Coroutine animationCoroutine;

    public GameObject recipeContainer;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // Initialize with collapsed height
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, collapsedHeight);

        // If uiManager isn't set in the inspector, try to find it
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<ExpandableUIManager>();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleExpansion();
    }

    public void ToggleExpansion()
    {
        isExpanded = !isExpanded;

        // Stop any ongoing animation
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        // Start new animation
        animationCoroutine = StartCoroutine(AnimateHeight(
            isExpanded ? expandedHeight : collapsedHeight
        ));

        foreach (GameObject recipe in recipeContainer.GetComponent<ExpandableUIManager>().expandableElements)
        {
            StartCoroutine(recipe.GetComponent<ExpandableUIElement>().ShiftPosition(false)); 
        }
        
    }
    
    private IEnumerator AnimateHeight(float targetHeight)
    {
        float startHeight = rectTransform.rect.height;
        float time = 0;
        
        while (time < animationDuration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / animationDuration;
            float evaluatedTime = animationCurve.Evaluate(normalizedTime);
            
            float newHeight = Mathf.Lerp(startHeight, targetHeight, evaluatedTime);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
            
            // Update the collider size
            if (TryGetComponent<BoxCollider2D>(out var collider))
            {
                collider.size = new Vector2(rectTransform.rect.width, newHeight);
            }
            
            // Notify the manager that our size changed
            if (uiManager != null)
            {
                uiManager.ElementSizeChanged(gameObject);
            }
            
            yield return null;
        }
        
        // Ensure we end at exactly the target height
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);
        
        // Final collider update
        if (TryGetComponent<BoxCollider2D>(out var finalCollider))
        {
            finalCollider.size = new Vector2(rectTransform.rect.width, targetHeight);
        }
        
        animationCoroutine = null;
    }
    
    public bool IsExpanded()
    {
        return isExpanded;
    }
    
    public float GetCollapsedHeight()
    {
        return collapsedHeight;
    }
    
    public float GetExpandedHeight()
    {
        return expandedHeight;
    }
}