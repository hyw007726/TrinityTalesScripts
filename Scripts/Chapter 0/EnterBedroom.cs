using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBedroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enterBedroom()
    {
        //DontDestroyOnLoad(audioSource);

        SceneManager.LoadScene("Chapter 1");
    }
}
