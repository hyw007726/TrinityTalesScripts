using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TCDDialogueController : MonoBehaviour
{
    public static TCDDialogueController Current;
    public GameObject DialogueBox;
    public int pageIndex = 0;
    public Button proceedButton;
    public TextMeshProUGUI content;
    public TextMeshProUGUI buttonText;
    public Button skipButton;
    public Camera secondCamera;
    private Camera mainCamera;
    public float transitionSpeed = 1.0f; // Speed of the transition
    private string[] pages = {
        //0
        "Welcome to Ireland! You are in Dublin now. On average, the temperatures here are cool. Let's go shopping and get some <b><color=red>winter</color></b> clothes first. You must always prepare for rain as well!",
        //1
        "You are now wearing right clothes! Now let's go get some groceries. We can check the PC for the locations of stores.",
        //2
        "Please click on a store to play a game!",
        //3
        "You're a good shopper! It's wise to have a personal public transport card to commuting. Let's find out how to get it!",

        //4
        "Congratulations! You've passed all our games! We appreciate your participation. Please share your thoughts on our game.",

        //5 default
        "Thank you for playing this game!"
    };
    private string[] buttonTextString =
  {
        "Play",
        "Next",
        "Okay",
        "Sure",
        "Okay",
        //default
        "Done"
    };
    // Start is called before the first frame update
    void Start()
    {
        Current = this;
        content.text = pages[pageIndex];
        buttonText.text = buttonTextString[pageIndex];
        mainCamera = Camera.main;
        //GetComponent<Canvas>().worldCamera = Camera.main;

        //GameObject overLayCanvas = GameObject.Find("Overlays");
        //if (overLayCanvas != null)
        //{
        //    overLayCanvas.GetComponent<Canvas>().enabled = false;

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void proceed()
    {
        pageIndex++;
        content.text = pages[pageIndex];

        buttonText.text = buttonTextString[pageIndex];
        switch (pageIndex)
        {
            case 1:
                DeactivateDialogue();
                SceneManager.LoadSceneAsync("weather",LoadSceneMode.Additive);
                skipButton.gameObject.SetActive(false);
                break;
            case 2:
                //You are now wearing right clothes!
                //PC transition and load choose grocery
                //Debug.Log("transition required");
                DeactivateDialogue();
                StartCoroutine(TransitionToSecondCamera());
                skipButton.gameObject.SetActive(true);
                break;
            case 3:
                GameObject.Find("StorePicker").GetComponent<GraphicRaycaster>().enabled = true;
                DeactivateDialogue();
                //temporarily disable Athi's game
                //proceedButton.interactable = false;
                if (DataManager.Instance != null)
                {
                    DataManager.Instance.UpdateProgress(5);
                }
                break;
            case 4:
                //"It's always wise
                SceneManager.LoadSceneAsync("TFI1", LoadSceneMode.Additive);
                SceneManager.LoadSceneAsync("Escape", LoadSceneMode.Additive);
                DeactivateDialogue();
                skipButton.gameObject.SetActive(false);
                if (DataManager.Instance != null)
                {
                    DataManager.Instance.UpdateProgress(6);
                }
                break;
            case 5:
                if (DataManager.Instance != null)
                {
                    DataManager.Instance.UpdateProgress(6);
                }
                SceneManager.LoadSceneAsync("Feedback");
                
               
                break;
        }
    }
    public void ActivateDialogue()
    {
        //turn off escape button
        if (SceneManager.GetSceneByName("Escape").IsValid())
        {
            SceneManager.UnloadSceneAsync("Escape");
        }
        GameObject overLayCanvas = GameObject.Find("Overlays");
        if (overLayCanvas != null)
        {
            overLayCanvas.GetComponent<Canvas>().enabled = true;

        }
        DialogueBox.SetActive(true);
        proceedButton.GetComponent<CursorChanger>().EnableCursorChange();

    }

    public void DeactivateDialogue()
    {
        GameObject overLayCanvas = GameObject.Find("Overlays");
        if (overLayCanvas != null)
        {
            overLayCanvas.GetComponent<Canvas>().enabled = false;

        }
        DialogueBox.SetActive(false);
        proceedButton.GetComponent<CursorChanger>().DisableCursorChange();
    }

    public void skipGame()
    {
        if (pageIndex == 0)
        {
            if (DataManager.Instance != null)
            {
                DataManager.Instance.UpdateProgress(4);
            }
        }

            skipButton.gameObject.SetActive(false);

        proceedButton.GetComponent<CursorChanger>().DisableCursorChange();
        proceedButton.GetComponent<CursorChanger>().EnableCursorChange();
        pageIndex++;
        content.text = pages[pageIndex];
        buttonText.text = buttonTextString[pageIndex];
        if (pageIndex == 3)
        {
            skipButton.gameObject.SetActive(true);
            SceneManager.UnloadSceneAsync("ChooseStore");
            //proceedButton.interactable = false;
            DataManager.Instance.UpdateProgress(5);
        }
        else
        {
            proceedButton.interactable = true;
        }
        
    }
    private IEnumerator TransitionToSecondCamera()
    {
        //Debug.Log(mainCamera.name);
        //Debug.Log(secondCamera.name);
        float t = 0;
        Vector3 startPos = mainCamera.transform.position;
        Quaternion startRot = mainCamera.transform.rotation;
        float farClip = mainCamera.farClipPlane;
        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            mainCamera.transform.position = Vector3.Lerp(startPos, secondCamera.transform.position, t);
            mainCamera.transform.rotation = Quaternion.Lerp(startRot, secondCamera.transform.rotation, t);
            yield return null;
        }
        
        mainCamera.farClipPlane = secondCamera.farClipPlane;
        mainCamera.nearClipPlane = secondCamera.nearClipPlane;
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = secondCamera.orthographicSize;
        
        AsyncOperation loadScene = SceneManager.LoadSceneAsync("ChooseStore", LoadSceneMode.Additive);
        while (!loadScene.isDone)
        {
            yield return null;  // wait until Chapter 2 is loaded
        }
        ActivateDialogue();
    }

}
