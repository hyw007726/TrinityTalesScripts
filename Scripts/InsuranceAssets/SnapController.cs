using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public delegate void DragEndedDelegate(InsuranceDraggable draggableObject);

    public List<Transform> snapPoints;
    public List<InsuranceDraggable> draggableObjects;
    public float snapRange = 20f;
    private Dictionary<string, string> correctAssignments = new Dictionary<string, string>
    {
        { "A", "iv" },
        { "B", "iii" },
        { "C", "ii" },
        { "D", "i" },
        { "E", "ii" }
    };
    void Start()
    {
        foreach (InsuranceDraggable draggable in draggableObjects)
        {
            draggable.dragEndedCallBack = OnDragEnded;
        }
    }

   private void OnDragEnded(InsuranceDraggable draggable)
{
    float closestDistance = -1;
    Transform closestSnapPoint = null;

    foreach (Transform snapPoint in snapPoints)
    {
        float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
        if (closestSnapPoint == null || currentDistance < closestDistance)
        {
            closestSnapPoint = snapPoint;
            closestDistance = currentDistance;
        }
    }

    if (closestSnapPoint != null && closestDistance <= snapRange)
    {
        draggable.transform.localPosition = closestSnapPoint.localPosition;
        draggable.assignedCompanyId = closestSnapPoint.GetComponent<SnapPoint>().companyId;
    }
        if (draggable.assignedCompanyId == null || draggable.assignedCompanyId != correctAssignments[draggable.characterId])
        {
            draggable.ResetPosition();
        }
            // Call the modified CheckAssignments here and pass in the draggable character
            FindObjectOfType<GameController>().CheckAssignments(draggable);
}
}

