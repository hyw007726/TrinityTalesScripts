using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ReadData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataManager instance = FindObjectOfType<DataManager>();
        if (instance != null)
        {
            TextMeshProUGUI name = gameObject.GetComponent<TextMeshProUGUI>();
            name.text = instance.ReadData().playerName;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
