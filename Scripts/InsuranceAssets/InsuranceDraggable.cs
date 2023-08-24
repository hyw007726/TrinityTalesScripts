using UnityEngine;
using UnityEngine.SceneManagement;

public class InsuranceDraggable : MonoBehaviour
{
    public bool isCorrectFile = true; // Set this in the inspector for each file object

    public delegate void DragEndedDelegate(InsuranceDraggable draggableObject);
    public DragEndedDelegate dragEndedCallBack;
    private Vector3 originalPosition;  // To store the original position of the object

    public string characterId; // Character identifier
    public string assignedCompanyId; // Insurance company identifier
    public bool isActuallyDraggable = true; // Set this to true for character cards and false for insurance cards in the inspector

    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void Awake()
    {
        originalPosition = transform.position; // Set the original position on Awake

        if (SceneManager.GetActiveScene().name != "InsuranceGameScene")
        {
            this.enabled = false;  // Disable this script
            return;
        }
    
    }

    private void OnMouseDown()
    {
        if (isActuallyDraggable)
        {
            //Debug.Log("Mouse down on " + gameObject.name);
            isDragged = true;
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPosition = transform.localPosition;
            FindObjectOfType<GameController>().ClearMessageBox();  // Clearing the message box when new card is picked up
        }
    }

    private void OnMouseDrag()
    {
        if (isActuallyDraggable && isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        if (isActuallyDraggable)
        {
            isDragged = false;
            dragEndedCallBack?.Invoke(this);  // The ? here checks for null before invoking the delegate
        }
    }
    public void ResetPosition()
    {
        transform.position = originalPosition;  // Reset the position to its original location
    }
}
