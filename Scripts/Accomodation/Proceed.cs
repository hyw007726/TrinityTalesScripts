using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Proceed : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {

        yourButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        //Debug.Log(gameObject.scene.name);
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
        SceneManager.LoadSceneAsync("FBCanvas1",LoadSceneMode.Additive);
    }
}