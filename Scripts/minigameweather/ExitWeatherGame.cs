using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitWeatherGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void exit()
    {
        SceneManager.UnloadSceneAsync("weather");
        if (DataManager.Instance != null)
        {
            DataManager.Instance.UpdateProgress(4);
        }
        else
        {
            Debug.Log("Can't find data manager");
        }
        TCDDialogueController.Current.ActivateDialogue();
    }
}
