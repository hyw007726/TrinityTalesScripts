using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    //public GameObject audioSource;
    // Start is called before the first frame update
    public Button buttonPlay;
    public Sprite buttonPlayAfterClick;
    public Button buttonInfo;
    public Sprite buttonInfoAfterClick;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
   //public void enterSelectCountry()
   // {
   //     //DontDestroyOnLoad(audioSource);
   //     SceneManager.LoadScene("SelectLocation");
   // }

    public void enterCreatedBy()
    {
        Image buttonImage = buttonInfo.GetComponentInChildren<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = buttonInfoAfterClick;
        }
        SceneManager.LoadScene("CreatedByScene");
    }

    public void enterSelectCharacter()
    {
        //persist the button color sprite
        Image buttonImage = buttonPlay.GetComponentInChildren<Image>();
        if (buttonImage != null)
        {
            buttonImage.sprite = buttonPlayAfterClick;
        }

        SceneManager.LoadScene("SelectCharacter");
    }


    public void enterLandingScene()
    {
        SceneManager.LoadScene("LandingScene"); 
    }

}
