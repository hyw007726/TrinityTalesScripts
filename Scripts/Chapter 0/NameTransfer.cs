using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreName()

    {
        theName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + theName + "!";

    }

}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class TMPNameTransfer : MonoBehaviour
// {
//     public string theName;
//     public TMP_InputField tmpInputField;
//     public TMP_Text tmpTextDisplay;

//     public void StoreName()
//     {
//         theName = tmpInputField.text;
//         tmpTextDisplay.text = "Welcome " + theName + " !";
//     }
// }
