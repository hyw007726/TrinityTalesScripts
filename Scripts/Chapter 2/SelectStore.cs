using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class SelectStore : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.UnloadSceneAsync("ChooseStore");
        string storeName = Random.Range(0, 2) == 0 ? "Shop" : "Shop 2";
        PlayerPrefs.SetString("StoreName", storeName);
        SceneManager.LoadSceneAsync(storeName, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Escape", LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openMS()
    {
        SceneManager.UnloadSceneAsync("ChooseStore");
        SceneManager.LoadSceneAsync("Shop 2", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Escape", LoadSceneMode.Additive);
    }
    public void openAldi()
    {
        SceneManager.UnloadSceneAsync("ChooseStore");
        SceneManager.LoadSceneAsync("Shop", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("Escape", LoadSceneMode.Additive);
    }
}
