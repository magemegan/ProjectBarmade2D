using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class ExpandableUIElement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float movementThreshold = 0.1f;
    
    [Header("Debug")]
    [SerializeField] private bool showDebugLogs = false;

    private BoxCollider2D myCollider;
    private Vector2 originalPosition;
    private float yOffsetAmount = 0f;
    private bool isMoving = false;

    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
        
        // Make sure this is set up as a trigger
        myCollider.isTrigger = true;
        
        // Store original position
        originalPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (showDebugLogs)
            Debug.Log($"{gameObject.name}: {other.gameObject.name} entered my collider");
        
        // Get the bottom edge of the other collider
        float otherBottom = other.bounds.min.y;
        // Get the top edge of my collider
        float myTop = myCollider.bounds.max.y;
        
        // Calculate how much we need to shift down
        float overlapAmount = myTop - otherBottom;
        
        if (overlapAmount > 0)
        {
            // Add a little extra space
            yOffsetAmount = overlapAmount + 5f;
            
            if (showDebugLogs)
                Debug.Log($"Need to shift down by {yOffsetAmount}");
            
            // Start shifting down
            StopAllCoroutines();
            StartCoroutine(ShiftPosition(true));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (showDebugLogs)
            Debug.Log($"{gameObject.name}: {other.gameObject.name} exited my collider");
        
        // Check if there are any remaining colliders overlapping
        Collider2D[] overlappingColliders = new Collider2D[5];
        int count = myCollider.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);
        
        if (count <= 0)
        {
            // Start shifting back up
            StopAllCoroutines();
            StartCoroutine(ShiftPosition(false));
        }
    }

    private IEnumerator ShiftPosition(bool shiftDown)
    {
        isMoving = true;
        Vector2 targetPosition;
        
        if (shiftDown)
        {
            // Move down
            targetPosition = new Vector2(originalPosition.x, originalPosition.y - yOffsetAmount);
        }
        else
        {
            // Move back up to original position
            targetPosition = originalPosition;
            yOffsetAmount = 0f;
        }
        
        while (Vector2.Distance((Vector2)transform.position, targetPosition) > movementThreshold)
        {
            transform.position = Vector2.Lerp(
                transform.position, 
                targetPosition, 
                movementSpeed * Time.deltaTime
            );
            yield return null;
        }
        
        // Make sure we end at exactly the target position
        transform.position = targetPosition;
        isMoving = false;
    }

    // Public method to check if this element is currently moving
    public bool IsMoving()
    {
        return isMoving;
    }
}