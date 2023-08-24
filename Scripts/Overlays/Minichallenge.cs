using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MinigameProgress : MonoBehaviour
{
    [SerializeField]
    private Slider progressBar; // Drag your UI Slider here in the inspector

    private float progressIncrement = 0.2f; // 20%

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Daft minigame")
        {
            UpdateProgress();
        }
    }

    void UpdateProgress()
    {
        progressBar.value += progressIncrement;
    }
}