using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using Cinemachine;
using UnityEngine.UI;
public class DesktopController : MonoBehaviour
{
    public static DesktopController Current;
    public GameObject DialogueBox;
    private Camera mainCamera;
    public int pageIndex = 0;
    public Button proceedButton;
    public Button insuranceLink;
    public TextMeshProUGUI content;
    public TextMeshProUGUI buttonText;
    

    private string[] pages =
    {
        "Before sorting out insurance, please read the                                 for international students. When you finish reading you can click Play to begin.",
        "Congratulations! You've got insurance! Now let's apply for your visa.",
        "In this task, you need to upload some files to immigration bureau's website. Click Play to start.",
        "Congratulations! Getting a visa is what can take the longest, so now good job for putting in your application! Let's move to the next task when you are ready!",
        "There is a housing crisis in Ireland so it’s best to look for accommodation early. Me? I'm living on campus. You can too if you’re early enough.",
        "You should apply between 28th March and 22nd May to secure housing from Trinity College. But don’t worry, there are lots of other options. Let’s look. Click Play to begin.",
        "Congratulations! You finished all the tasks before departure. Now, Dublin bound!",
        "Awwwwwwwww~"
};
    public Button skipButton;
    private string[] buttonTextString =
    {
        "Play",
        "Next",
        "Play",
        "Next",
        "Next",
        "Play",
        "Okay",
        "Grand"
    };

    public void initializeGameScenes()
    {

        EventSystem[] ess = FindObjectsOfType<EventSystem>();
        if (ess.Length == 0)
        {
            GameObject eventSystemObj = new GameObject("Preview EventSystem");
            EventSystem previewEventSystem = eventSystemObj.AddComponent<EventSystem>();
            eventSystemObj.AddComponent<StandaloneInputModule>();

        }

        Camera[] cameras = FindObjectsOfType<Camera>();
        if (cameras.Length == 0)
        {
            //GameObject previewCamera = new GameObject("Preview Camera");
            //Camera preview = previewCamera.AddComponent<Camera>();
            //preview.enabled = true;
            //preview.tag = "MainCamera";
        }
        else if (cameras.Length > 1)
        {
            foreach (Camera c in cameras)
            {
                if (Camera.main.name != "Main Camera"&&Camera.main.name != "Preview Camera")
                {
                    c.gameObject.SetActive(false);
                }
            }

        }
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas c in canvases)
        {
            if (Camera.main != null)
            {
                c.worldCamera = Camera.main;

            }
        }
      
    }
  
    // Start is called before the first frame update
    void Start()
    {
        Current = this;
        Canvas c = GetComponent<Canvas>();
         if (Camera.main != null)
            {
                c.worldCamera = Camera.main;

            }

        //GameObject DialogueBox = GameObject.Find("DialogueBox");
        content.text = pages[pageIndex];
        buttonText.text = buttonTextString[pageIndex];
       

        if (!proceedButton.interactable)
        {
            proceedButton.GetComponent<CursorChanger>().DisableCursorChange();
        }

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
        switch (pageIndex){
            case 1:

                // test area
                //to3D();
                //return;
                //


                //real game begins:
                AsyncOperation asyncLoad1=SceneManager.LoadSceneAsync("InsuranceGameScene", LoadSceneMode.Additive);
                SceneManager.LoadSceneAsync("EscapeGame", LoadSceneMode.Additive);
                asyncLoad1.completed += OnSceneLoaded;
                insuranceLink.gameObject.SetActive(false);
                skipButton.gameObject.SetActive(false);
                break;
            case 2:
                //Congratulations! You finished the Insurance game! Now let's go to the Visa game.
                skipButton.gameObject.SetActive(true);
                break;
            case 3:
                AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync("VisaGameScene", LoadSceneMode.Additive);
                SceneManager.LoadSceneAsync("EscapeGame", LoadSceneMode.Additive);
                asyncLoad2.completed += OnSceneLoaded;
                skipButton.gameObject.SetActive(false);
                break;
            case 4:
                //Congratulations! Getting a visa is what can take the longest
                break;
            case 5:
                //It’s time to look for accommodation.
                skipButton.gameObject.SetActive(true);

                //wait for Athi's game
                //proceedButton.interactable = false;
                break;
            case 6:
                //You should apply between 28th March and 22nd May.
                //playTestGame("Under development");
                AsyncOperation asyncLoad3 = SceneManager.LoadSceneAsync("DAFT Mini game", LoadSceneMode.Additive);
                SceneManager.LoadSceneAsync("EscapeGame", LoadSceneMode.Additive);
                asyncLoad3.completed += OnSceneLoaded;
                skipButton.gameObject.SetActive(false);
                DataManager.Instance.UpdateProgress(3);
                break;
            case 7:
                //Congratulations! You finished all the
                to3D();
                break;
            case 8:
                break;
            default:
                break;
        }
    }
    public void playTestGame(string prompt)
    {
        PlayerPrefs.SetString("DummySceneText", prompt);
        SceneManager.LoadSceneAsync("DummyScene", LoadSceneMode.Additive);

        DeactivateDialogue();
    }
    public void ActivateDialogue()
    {
        //turn off escape button
        if (SceneManager.GetSceneByName("EscapeGame").IsValid())
        {
            SceneManager.UnloadSceneAsync("EscapeGame");
        }
   

        Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
        overLayCanvas.enabled = true;
        DialogueBox.SetActive(true);
        proceedButton.GetComponent<CursorChanger>().EnableCursorChange();

    }

    public void DeactivateDialogue()
    {
        Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
        overLayCanvas.enabled = false;
        DialogueBox.SetActive(false);
        proceedButton.GetComponent<CursorChanger>().DisableCursorChange();
    }

    public void skipGame()
    {
        if (pageIndex == 0)
        {
            insuranceLink.gameObject.SetActive(false);
            DataManager.Instance.UpdateProgress(1);
        }
        if (pageIndex == 2)
        {
            //Debug.Log("skip game 2");
            DataManager.Instance.UpdateProgress(2);
        }
        if (pageIndex == 5)
        {
            //Debug.Log("skip game 3");
            DataManager.Instance.UpdateProgress(3);
        }
        skipButton.gameObject.SetActive(false);
        proceedButton.interactable = true;
        proceedButton.GetComponent<CursorChanger>().DisableCursorChange();
        proceedButton.GetComponent<CursorChanger>().EnableCursorChange();
        pageIndex ++;
        content.text = pages[pageIndex];
        buttonText.text = buttonTextString[pageIndex];
    }

    public void to3D()
    {
        mainCamera = Camera.main;

        DataManager instance = FindObjectOfType<DataManager>();
        mainCamera.transform.position = instance.defaultCameraPos;
        mainCamera.transform.rotation = instance.defaultCameraRot;
        mainCamera.farClipPlane = instance.defaultFarClipPlane;
        mainCamera.nearClipPlane = instance.defaultNearClipPlane;
        mainCamera.orthographic = false;
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;
        SceneManager.UnloadSceneAsync("DesktopScene");
        //Resume overlay
        Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
        overLayCanvas.enabled = true;
        //GameObject[] rootObjects = SceneManager.GetSceneByName("OverlayScene").GetRootGameObjects();
        //foreach (GameObject obj in rootObjects)
        //{
        //    if (obj.name == "Overlays")
        //    {
        //        //Debug.Log(obj);
        //        obj.SetActive(true);
        //    }
        //}
        //Resume cursor changers
        instance.EnableCursorChangersInScene("Chapter 1");

        Transform roomTransform = GameObject.Find("Room Container").gameObject.transform;
        if (roomTransform != null)
        {

            //Enable door click
            GameObject doorCover = roomTransform.Find("DoorCover").gameObject;
            doorCover.SetActive(true);
            //Disable PC click
             GameObject.Find("PC 1").GetComponent<BoxCollider>().enabled=false;
        }

    }

    public void ClickInsuranceInfo()
    {
//        if (Application.platform == RuntimePlatform.WebGLPlayer)
//        {
//#pragma warning disable CS0618 // Type or member is obsolete
//            Application.ExternalEval("window.open('https://www.tcd.ie/study/international/arriving-in-ireland/health-insurance/','_blank');");
//#pragma warning restore CS0618 // Type or member is obsolete

//        }
//        else
//        {
//            Application.OpenURL("https://www.tcd.ie/study/international/arriving-in-ireland/health-insurance/");
//        }
        Application.OpenURL("https://www.tcd.ie/study/international/arriving-in-ireland/health-insurance/");
        proceedButton.interactable = true;

            proceedButton.GetComponent<CursorChanger>().EnableCursorChange();


    }
    void OnSceneLoaded(AsyncOperation operation)
    {
        //Debug.Log("new scene loaded");
        initializeGameScenes();
        DeactivateDialogue();
    }
}
