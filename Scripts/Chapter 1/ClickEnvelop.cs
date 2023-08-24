using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvelopController : MonoBehaviour
{
    private string LetterScene = "LetterScene";
    private string DialogueScene = "DialogueScene";

    //private string Page1 = "Hello! I’m Sam, Trinity’s resident fox, congratulations on getting admitted there’s quite a bit of preparation you’ll need to do before your big move to Dublin, But don’t worry! I’m going to guide you along the way. You should start by applying for a visa, as this part usually takes the longest!";
    List<string> pages = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //pages.Add(Page1);
        SceneManager.sceneLoaded += OnDialogueSceneLoaded;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        SceneManager.LoadSceneAsync(LetterScene, LoadSceneMode.Additive);
        Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
        overLayCanvas.enabled = false;

    }
    public void closeLetter()
    {
        
        SceneManager.UnloadSceneAsync(LetterScene);
      
        //Debug.Log(PlayerPrefs.HasKey("FirstTimeOpenLetter"));
        if (!PlayerPrefs.HasKey("FirstTimeOpenLetter"))
        {
            SceneManager.LoadSceneAsync(DialogueScene, LoadSceneMode.Additive);
            PlayerPrefs.SetInt("FirstTimeOpenLetter", 1);
            return;
        }
        

        //Canvas overLayCanvas = GameObject.Find("Overlays").GetComponent<Canvas>();
        //overLayCanvas.enabled = true;
        ////Debug.Log(GameObject.Find("Overlays"));
        //GameObject[] rootObjects = SceneManager.GetSceneByName("OverlayScene").GetRootGameObjects();
        //foreach (GameObject obj in rootObjects)
        //{
        //    if (obj.name == "Overlays")
        //    {
        //        //Debug.Log(obj);
        //        obj.SetActive(true);
        //    }
        //}
    }


    private void OnDialogueSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is the one we are interested in
        if (scene.name == DialogueScene)
        {

            //Debug.Log("Open Dialogue Scene");

        }
    }
}
