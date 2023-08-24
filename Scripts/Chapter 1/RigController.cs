using System.Collections;
using UnityEngine;

public class RigController : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 300.0f;
    private float animationDuration = 0f;
    private float elapsedTime = 0f;

    public float rotationDuration = 0.5f;  // Time taken for 180-degree rotation to complete.
    public float incrementalRotationAngle = 240.0f;  // Rotation per frame while arrow key is held.
    private bool isRotating = false;

    private bool isColliding = false;

    //private Vector3 targetPosition; // Destination point to move to
    //private bool isMovingToPoint = false; // Flag to check if character is moving to a point
    public LayerMask floorLayerMask;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        //test event
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    DataManager.Instance.UpdateProgress(1);
        //}
            
        //// Pointer input
        //if (Input.GetMouseButtonDown(0) && !isColliding)
        //{
        //    Debug.Log("ButtonDown");
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorLayerMask))
        //    {
        //        //Debug.Log("Hit point: " + hit.point);
        //        targetPosition = hit.point;
        //        isMovingToPoint = true;
        //    }

        //}

        //// Move towards the target position
        //if (isMovingToPoint)
        //{
        //    //MoveToPoint(targetPosition);
        //    return;
        //}

        bool isWalking = anim.GetBool("isWalking");

        // Check if up arrow key is being held down
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W) && !isColliding)
        {
            //Debug.Log("UpArrow");
            if (!isWalking)
            {
                anim.SetBool("isWalking", true);
                animationDuration = anim.GetCurrentAnimatorStateInfo(0).length;
                elapsedTime = 0f;
            }

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= animationDuration * 0.6)
            {
                anim.SetBool("isWalking", false);
                elapsedTime = 0f;
            }
        }
        else if (isWalking)
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && !isWalking && !isRotating)
        {
            StartCoroutine(SmoothRotate(180f)); // rotate 180 degrees on DownArrow
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("LeftArrow");
            transform.Rotate(0, -incrementalRotationAngle * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Debug.Log("RightArrow");
            transform.Rotate(0, incrementalRotationAngle * Time.deltaTime, 0);
        }
    }

    private IEnumerator SmoothRotate(float angle)
    {

        if (isRotating) // If already rotating, just exit
            yield break;

        isRotating = true;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, angle, 0);
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / rotationDuration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        isRotating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
     
        // Assuming that the objects we care about colliding with have a specific tag, e.g., "Obstacle"
        if (other.CompareTag("Obstacle"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isColliding = false;
        }
    }
    //void MoveToPoint(Vector3 target)
    //{
    //    Vector3 direction = (target - transform.position).normalized;

    //    // Check if we're close enough to stop moving
    //    if (Vector3.Distance(transform.position, target) < 0.5f)
    //    {
    //        isMovingToPoint = false;
    //        anim.SetBool("isWalking", false);
    //        return;
    //    }

    //    // Calculate angle difference
    //    float angleDifference = Vector3.Angle(transform.forward, direction);

    //    // If angleDifference is small, just stop adjusting rotation
    //    if (angleDifference > 5f) // Adjust this threshold as necessary
    //    {
    //        float rotationSpeed = 5f;
    //        float adjustedRotationSpeed = Mathf.Lerp(rotationSpeed, 0.5f, 1f - angleDifference / 180f);
    //        Quaternion lookRotation = Quaternion.LookRotation(direction);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * adjustedRotationSpeed);
    //    }

    //    // Move forward
    //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    //    if (!anim.GetBool("isWalking"))
    //    {
    //        anim.SetBool("isWalking", true);
    //    }
    //}



}
