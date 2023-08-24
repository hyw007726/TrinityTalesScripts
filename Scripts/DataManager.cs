using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public Vector3 defaultCameraPos;
    public Quaternion defaultCameraRot;
    public float defaultFarClipPlane;
    public float defaultNearClipPlane;
    public GameData gameData;
    private string path;

    public delegate void GameProgressHandler(int progess);
    public event GameProgressHandler OnProgressUpdate;
    //Subscribe: DataManager.Instance.OnProgressUpdate += HandleProgresssUpdate; define HandleProgresssUpdate(int progress)
    //Call: DataManager.Instance.UpdateProgress(int); int stands for minigame index, e.g. 1 for Insurance game

    public void UpdateProgress(int progress)
    {
        OnProgressUpdate?.Invoke(progress);
    }
    void Awake()
    {
        if (Instance == null)
        {
            // If running this for the first time, 
            // set the instance and do not destroy this object when changing scenes.
            Instance = this;
            DontDestroyOnLoad(this.gameObject);


#if UNITY_EDITOR
            path = "Assets/Scripts/gameData.json";
            //Debug.Log("Running in Editor");
#elif UNITY_WEBGL
            Debug.Log("Running in WebGL");
            if (!PlayerPrefs.HasKey("GameData"))
            {
                GameData data = new GameData();
                WriteData(data);
            }
#else
            path = Application.persistentDataPath + "/gameData.json";
            Debug.Log("Running in Build");
            if (!File.Exists(path))
            {
                GameData data = new GameData();
                WriteData(data);
            }
#endif
            //override the data
            WriteData(new GameData());
            PlayerPrefs.DeleteAll();
        }
        else
        {
            // If an instance already exists, destroy this object and return.
            Destroy(this.gameObject);
        }
    }
    public GameData ReadData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string json = PlayerPrefs.GetString("GameData", "");
        if (string.IsNullOrEmpty(json))
        {
            return new GameData(); // Or return default data, or however you want to handle it
        }
        else
        {
            return JsonUtility.FromJson<GameData>(json);
        }
#else
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<GameData>(json);
#endif
    }
    public void WriteData(GameData newData)
    {


        string json = JsonUtility.ToJson(newData);


#if UNITY_WEBGL && !UNITY_EDITOR
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.Save();
#else
        File.WriteAllText(path, json);
#endif

    }

    void Start()
    {


        //Debug.Log(ReadData().playerName);

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DisablePreViewCameras();
    }
    private void DisablePreViewCameras()
    {
        Camera[] cameras = Camera.allCameras;
        foreach (Camera camera in cameras)
        {
            if (camera.gameObject.name == "Preview Camera")
            {
                camera.gameObject.SetActive(false);
            }
        }
    }
    public void EnableCursorChangersInScene(string targetSceneName)
    { //Objects with cursor changers needs to be root objects to be found
        foreach (GameObject obj in SceneManager.GetSceneByName(targetSceneName).GetRootGameObjects())
        {
            CursorChanger cursorChanger = obj.GetComponent<CursorChanger>();
            if (cursorChanger != null)
            {
                cursorChanger.EnableCursorChange();
            }
        }
    }

    public void DisableCursorChangersInScene(string targetSceneName)
    {
        //Objects with cursor changers needs to be root objects to be found
        foreach (GameObject obj in SceneManager.GetSceneByName(targetSceneName).GetRootGameObjects())
        {
            //Debug.Log(obj.name);
            CursorChanger cursorChanger = obj.GetComponent<CursorChanger>();
            if (cursorChanger != null)
            {
                
                cursorChanger.DisableCursorChange();
                //Debug.Log("cursor change disabled in "+obj.name);
            }
        }
    }
}


[System.Serializable]
public class GameData
{
    public string playerName;
    public string country;
    public int daysLeft;
    //0-no games played; 1-insurance finished; 2-visa; 3-house choosing; 4-scam avoiding
    public int gamesPlayed;

}


//Call methods from other scripts:
//DataManager.Instance.ReadData();
//DataManager.Instance.WriteData(new data);