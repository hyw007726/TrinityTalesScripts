using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ToStudent : MonoBehaviour
{
    public Button yourButton;


    void Start()
    {

        yourButton.onClick.AddListener(LoadScene);

    }

    public void LoadScene()
    {

        SceneManager.UnloadSceneAsync(gameObject.scene.name);
        SceneManager.LoadSceneAsync("TFI_STUDENT", LoadSceneMode.Additive);
    }
}

