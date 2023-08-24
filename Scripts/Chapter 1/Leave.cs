using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Leave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        leaveRoom();
    }
    public void leaveRoom()
    {
        AsyncOperation flightScene= SceneManager.LoadSceneAsync("Flight");
        flightScene.completed += OnFlightSceneLoaded;
       


    }


   void OnFlightSceneLoaded(AsyncOperation operation)
    {

        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
        {
            if(SceneManager.GetSceneAt(sceneIndex).name!="Flight")
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(sceneIndex));
        }
    }
}
