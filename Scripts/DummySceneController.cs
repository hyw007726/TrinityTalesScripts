using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DummySceneController : MonoBehaviour
{
    public TextMeshProUGUI content;
    // Start is called before the first frame update
    void Start()
    {
        content.text = PlayerPrefs.GetString("DummySceneText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        SceneManager.UnloadSceneAsync("DummyScene");
        DesktopController dc = FindObjectOfType<DesktopController>();
        dc.ActivateDialogue();
    }
}
