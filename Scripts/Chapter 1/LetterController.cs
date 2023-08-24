using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LetterController : MonoBehaviour
{
    private string Page0 = $"{System.Environment.NewLine+ System.Environment.NewLine}We are delighted to inform you that you have been offered a place to study at Trinity College Dublin. {System.Environment.NewLine+System.Environment.NewLine}We look forward to welcoming you to study with us. {System.Environment.NewLine+System.Environment.NewLine}Your sincerely,{System.Environment.NewLine}Sam";
    //private string Page1 = "Hello! I’m Sam, Trinity’s resident fox, congratulations on getting admitted there’s quite a bit of preparation you’ll need to do before your big move to Dublin, But don’t worry! I’m going to guide you along the way. You should start by applying for a visa, as this part usually takes the longest!";
    List<string> pages = new List<string>();
    public TextMeshProUGUI letterContent;
    public int fontSize = 12;
    // Start is called before the first frame update
    void Start()
    {
        DataManager instance = FindObjectOfType<DataManager>();
        if (instance!=null)
        {
            pages.Add($"Dear {instance.ReadData().playerName}," + Page0);

        }
        else
        {
            pages.Add($"Dear Default PlayerName," + Page0);
        }

        letterContent.fontSize = fontSize;
        letterContent.color = Color.black;
        letterContent.text = pages[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ////add event methods for the button to listen to
    //public void closeLetter()
    //{
    //    GameObject letter = GameObject.Find("Letter");
    //    letter.SetActive(false);
    //    Debug.Log("closeLetter");
    //}
}
