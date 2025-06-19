using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider2D))]
public class ExpandableUIElement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float movementThreshold = 0.1f;

    private BoxCollider2D myCollider;
    [SerializeField] private Vector2 originalPosition;
    private float yOffsetAmount = 0f;
    private bool isMoving = false;

    //testing
    public GraphicRaycaster raycaster;
    public EventSystem eventSystem;
    public RectTransform rectTransform;
    bool collidingWithRecipe = false;


    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();

        // Make sure this is set up as a trigger
        myCollider.isTrigger = true;

        // Store original position
        originalPosition = transform.position;

        rectTransform = GetComponent<RectTransform>();

        raycaster = GetComponent<GraphicRaycaster>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Get the bottom edge of the other collider
        float otherTop = other.bounds.max.y;
        // Get the top edge of my collider
        float myBottom = myCollider.bounds.min.y;

        // Calculate how much we need to shift down
        float overlapAmount = otherTop - myBottom;
        Debug.Log(originalPosition);
        if (overlapAmount > 0)
        {
            // Add a little extra space
            yOffsetAmount = overlapAmount * 1.2f;

            // Start shifting down
            //StopAllCoroutines();
            StartCoroutine(ShiftPosition(true));
        }

        collidingWithRecipe = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if there are any remaining colliders overlapping
        Collider2D[] overlappingColliders = new Collider2D[5];
        int count = myCollider.OverlapCollider(new ContactFilter2D().NoFilter(), overlappingColliders);

        if (count <= 0)
        {
            // Start shifting back up
            //StopAllCoroutines();
            StartCoroutine(ShiftPosition(false));
        }

        collidingWithRecipe = false;
    }

    public IEnumerator ShiftPosition(bool shiftDown)
    {
        isMoving = true;
        Vector2 targetPosition;
        
        if (shiftDown)
        {
            //Debug.Log("Moving down");
            // Move down
            targetPosition = new Vector2(originalPosition.x, originalPosition.y - yOffsetAmount/2);
        }
        else
        {
            //Debug.Log("Moving up");
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