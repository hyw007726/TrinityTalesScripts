using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour
{
    private TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = gameObject.GetComponentInChildren<TMP_InputField>();
       // TextMeshProUGUI placeholderTMP = inputField.placeholder.GetComponent<TextMeshProUGUI>();

        DataManager instance = FindObjectOfType<DataManager>();
        inputField.text = instance.ReadData().playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enterSelectCountry()
    {
        //play sfx
        SFXManager.Instance.buttonClick();
        DataManager instance = FindObjectOfType<DataManager>();
        GameData gameDataNew = instance.ReadData();
        gameDataNew.playerName = inputField.text;
        gameDataNew.country = "China";
        instance.WriteData(gameDataNew);
        SceneManager.LoadScene("SelectLocation");
    }
}
