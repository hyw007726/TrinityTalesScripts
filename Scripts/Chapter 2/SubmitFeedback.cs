using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
public class SubmitFeedback : MonoBehaviour
{
    public TMP_InputField feedback;
    public TextMeshProUGUI thanks;
    public Button restart;
    public Button quit;
    private string path;
    void Awake()
    {
  
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            feedback.gameObject.SetActive(false);
            gameObject.SetActive(false);
            thanks.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
            return;
        }

#if UNITY_EDITOR
            path = "Assets/Scripts/Feedback.txt";
        Debug.Log("Running in Editor");
#else
            path = Application.persistentDataPath+"/Feedback.txt";
            Debug.Log("Running in Build");
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveFeedback()
    {
        // Using StreamWriter to write data to a file
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(feedback.text);
            sw.WriteLine();
        }
        feedback.gameObject.SetActive(false);
        gameObject.GetComponent<CursorChanger>().DisableCursorChange();
        gameObject.SetActive(false);
        thanks.text = "Thanks for your feedback!";
        thanks.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }
    public void restartGame()
    {
        //override the data
        if (DataManager.Instance != null)
        {
            DataManager.Instance.WriteData(new GameData());
        }
     
        PlayerPrefs.DeleteAll();

        GameObject overLayCanvas = GameObject.Find("Overlays");
        DataManager.Instance.OnProgressUpdate -= overLayCanvas.GetComponentInChildren<ToDoListUpdater>().CompleteChallenge;

        if (overLayCanvas != null)
        {
            Destroy(overLayCanvas);

        }
        SceneManager.LoadScene("LandingScene");
    }
    public void Quit()
    {

#if UNITY_EDITOR||UNITY_WEBGL

#else
            Application.Quit();
#endif
    }
}

