using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Camera cameraA;
    public Camera cameraB;
    public float transitionSpeed = 2.0f;

    private bool transitioning = false;
    private float transitionProgress = 0.0f;

    void Update()
    {
        if (transitioning)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;

            if (transitionProgress >= 1.0f)
            {
                transitioning = false;
                cameraA.gameObject.SetActive(false);
                cameraB.gameObject.SetActive(true);
                cameraB.rect = new Rect(0, 0, 1, 1); // Reset the rect to full screen
            }
            else
            {
                cameraA.rect = new Rect(0, 0, 1, 1 - transitionProgress);
                cameraB.rect = new Rect(0, 1 - transitionProgress, 1, transitionProgress);
            }
        }
    }

    public void StartTransition()
    {
        if (!transitioning)
        {
            transitioning = true;
            transitionProgress = 0.0f;
            cameraB.gameObject.SetActive(true);
        }
    }
}
