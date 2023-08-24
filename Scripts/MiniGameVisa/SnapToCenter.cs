using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SnapToCenter : MonoBehaviour
{
    public GameObject targetObject;
    public float snapDistance = 300.0f;

    public Dictionary<string, string> fileToCheckmarkTag = new Dictionary<string, string>
    {
        { "acceptance", "acceptancecheck" },
        { "passport", "passportcheck" },
        { "payment", "paymentcheck" },
        { "funds", "fundscheck" },
        { "insurance", "insurancecheck" }
    };

    public GameObject[] checkmarks;

    private Draggable draggable;

    // Using a GameObject for the error message sprite
    public GameObject errorMessageSprite; 

    private void Awake()
    {
        draggable = GetComponent<Draggable>();
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("VisaDraggings"))
        {
            PlayerPrefs.DeleteKey("VisaDraggings");

        }
    }

    public bool IsCloseEnough()
{
    float distance = Vector3.Distance(transform.position, targetObject.transform.position);
    Debug.Log("Distance: " + distance); // This will print the distance to the Unity console
    return distance <= snapDistance;
}


    public void SnapToTarget()
    {
        if (targetObject != null && draggable.isCorrectFile)
        {
            transform.position = targetObject.transform.position;
            gameObject.SetActive(false);

            string checkTag;
            if (fileToCheckmarkTag.TryGetValue(gameObject.tag, out checkTag))
            {
                foreach (GameObject checkmark in checkmarks)
                {
                    if (checkmark.tag == checkTag)
                    {
                        checkmark.SetActive(true);
                        Debug.Log(PlayerPrefs.GetInt("VisaDraggings"));
                        if (PlayerPrefs.HasKey("VisaDraggings"))
                        {
                            int correctDrags = PlayerPrefs.GetInt("VisaDraggings") + 1;
                            PlayerPrefs.SetInt("VisaDraggings", correctDrags);
                            if(correctDrags== checkmarks.Length)
                            {
                                Debug.Log("visa game done");
                                SceneManager.UnloadSceneAsync("VisaGameScene");
                                //Trigger progress update; 1 stands for minigame1
                                if (DataManager.Instance != null)
                                {
                                    DataManager.Instance.UpdateProgress(1);
                                    DataManager.Instance.UpdateProgress(2);
                                }
                                
                                DesktopController.Current.ActivateDialogue();
                            }

                        }
                        else
                        {
                            PlayerPrefs.SetInt("VisaDraggings", 1);
                        }

                        break;
                    }
                }
            }
        }
        else
        {
            draggable.ResetPosition();
            DisplayErrorMessage();
        }
    }

    private void DisplayErrorMessage()
    {
        if (errorMessageSprite != null)
        {
            errorMessageSprite.SetActive(true);
            StartCoroutine(HideErrorMessageAfterDelay(2f));
        }
    }

    private IEnumerator HideErrorMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorMessageSprite.gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        if (targetObject != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(targetObject.transform.position, snapDistance);
        }
    }

    
}
