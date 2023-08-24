using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ClickPC : MonoBehaviour
{

    public Camera secondCamera;
    private Camera mainCamera; // Reference to the main camera
  
    public float transitionSpeed = 1.0f; // Speed of the transition
    //public CursorChanger cursorChanger;
    private void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
        //Save the camera on DataManager singlton
        DataManager instance = FindObjectOfType<DataManager>();
        instance.defaultCameraPos= mainCamera.transform.position;
        instance.defaultCameraRot= mainCamera.transform.rotation;
        instance.defaultFarClipPlane = mainCamera.farClipPlane;
        instance.defaultNearClipPlane = mainCamera.nearClipPlane;
        gameObject.GetComponent<CursorChanger>().DisableCursorChange();

        if (PlayerPrefs.HasKey("FirstTimeOpenLetter"))
        {
            PlayerPrefs.DeleteKey("FirstTimeOpenLetter");
        }

    }
    void OnMouseDown()
    {
        if (!PlayerPrefs.HasKey("FirstTimeOpenLetter"))
        {
            return;
        }
        if (!PlayerPrefs.HasKey("FinishedDialogue"))
        {
            return;
        }
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene currentScene = SceneManager.GetSceneAt(i);
            if (currentScene.name == "DesktopScene")
            {
                gameObject.GetComponent<CursorChanger>().DisableCursorChange();
                return;
            }
        }


        //Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
        //overLayCanvas.enabled = false;

        //Disable cursor changers
        DataManager instance = FindObjectOfType<DataManager>();
        //Debug.Log("get instance " + instance.name);
        if (instance != null)
        {
            instance.DisableCursorChangersInScene("Chapter 1");
        }
  
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        
        StartCoroutine(TransitionToSecondCamera());
    }
    private IEnumerator TransitionToSecondCamera()
    {
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
        //GetComponent<Renderer>().enabled = false;
        SceneManager.LoadSceneAsync("DesktopScene", LoadSceneMode.Additive);
       
     
    }
}
