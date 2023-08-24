using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FB3Proceed : MonoBehaviour
{
    public Button yourButton;


    void Start()
    {

        yourButton.onClick.AddListener(LoadScene);
    }

    public void LoadScene()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.UpdateProgress(1);
            DataManager.Instance.UpdateProgress(2);
            DataManager.Instance.UpdateProgress(3);
        }
        else
        {
            Debug.Log("Can't find data manager");
        }
        SceneManager.UnloadSceneAsync("EscapeGame");
        DesktopController.Current.ActivateDialogue();
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
        
    }
}
