using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TFIYA : MonoBehaviour
{
    public Button yourButton3;

    void Start()
    {

        yourButton3.onClick.AddListener(LoadScene);

    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync("TFI_YOUNGADULT", LoadSceneMode.Additive);
    }

}
