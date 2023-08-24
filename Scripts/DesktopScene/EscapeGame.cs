using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class EscapeGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ESC()
    {

        SceneManager.UnloadSceneAsync("EscapeGame");
        DesktopController.Current.ActivateDialogue();
   
        if (SceneManager.GetSceneByName("InsuranceGameScene").IsValid())
        {
            SceneManager.UnloadSceneAsync("InsuranceGameScene");
            if (DataManager.Instance != null)
            {
                DataManager.Instance.UpdateProgress(1);
            }
            else
            {
                Debug.Log("Can't find data manager");
            }
            return;
        }

        if (SceneManager.GetSceneByName("VisaGameScene").IsValid())
        {
            SceneManager.UnloadSceneAsync("VisaGameScene");
            if (DataManager.Instance != null)
            {
                DataManager.Instance.UpdateProgress(2);
            }
            else
            {
                Debug.Log("Can't find data manager");
            }
            return;
        }


        try
        {
            for(int sceneIndex=22; sceneIndex<26; sceneIndex++)
            {
                SceneManager.UnloadSceneAsync(sceneIndex);
            }
           
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }

        if (DataManager.Instance != null)
        {
            DataManager.Instance.UpdateProgress(3);
        }
        else
        {
            Debug.Log("Can't find data manager");
        }

    }
   
}
