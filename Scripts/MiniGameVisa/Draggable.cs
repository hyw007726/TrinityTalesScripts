using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;  // To store the original position of the object
    private bool dragging = false;

    public bool isCorrectFile = true;  // Set this in the inspector for each file object

    private void Awake()
    {
        originalPosition = transform.position; // Set the original position on Awake
    }

    public bool IsDragging()
    {
        return dragging;
    }


    private void OnMouseDrag()
    {
        // If mouse is clicked and dragged over the object
        if (dragging)
        {

            float distanceToCamera = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera);

            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

private void OnMouseDown()
{
        float distanceToCamera = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // If mouse is clicked over the object
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCamera));
    dragging = true;

    // Bring the dragged object to the front
    GetComponent<SpriteRenderer>().sortingOrder = 1;

    transform.localScale *= 1.1f; // Increase the scale slightly when dragging starts
}

private void OnMouseUp()
{
    // When mouse button is released
    dragging = false;

    // Reset the sorting order
    GetComponent<SpriteRenderer>().sortingOrder = 0;
    
    if (GetComponent<SnapToCenter>().IsCloseEnough())
    {
        GetComponent<SnapToCenter>().SnapToTarget();
    }
    transform.localScale /= 1.1f; // Reset the scale when dragging ends
}

    public void ResetPosition()
    {
        transform.position = originalPosition;  // Reset the position to its original location
    }
}
