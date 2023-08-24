using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Escape : MonoBehaviour
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
        // Attempt to unload the scene from PlayerPrefs
        try
        {
                SceneManager.UnloadSceneAsync("Shop");
            
            
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error unloading scene: " + PlayerPrefs.GetString("StoreName") + ". " + e.Message);
        }
        try
        {
            SceneManager.UnloadSceneAsync("Shop 2");


        }
        catch (System.Exception e)
        {
            Debug.LogError("Error unloading scene: " + PlayerPrefs.GetString("StoreName") + ". " + e.Message);
        }

        // Attempt to unload scenes from 26 to 29
        for (int sceneIndex = 26; sceneIndex < 31; sceneIndex++)
        {
            try
            {
                SceneManager.UnloadSceneAsync(sceneIndex);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error unloading scene index: " + sceneIndex + ". " + e.Message);
            }
        }

        SceneManager.UnloadSceneAsync("Escape");
        //if (DataManager.Instance != null)
        //{
        //    DataManager.Instance.UpdateProgress(5);
        //}
        //else
        //{
        //    Debug.Log("Can't find data manager");
        //}
        TCDDialogueController.Current.ActivateDialogue();
    }
}
