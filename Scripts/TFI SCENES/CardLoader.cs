using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CardLoader : MonoBehaviour
{
    public Button yourButton3;
    
    void Start()
    {

        yourButton3.onClick.AddListener(LoadScene);
       
    }

    public void LoadScene()
    {
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
        SceneManager.LoadSceneAsync("TFI3", LoadSceneMode.Additive);
    }

}
