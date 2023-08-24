using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class ClickLinks : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        string url = gameObject.GetComponentInChildren<TextMeshProUGUI>().textInfo.linkInfo[0].GetLinkID();
        Application.OpenURL(url);

        //Debug.Log(gameObject.GetComponentInChildren<TextMeshProUGUI>().textInfo.linkInfo[0].GetLinkID());
        //if (Application.platform == RuntimePlatform.WebGLPlayer)
        //{
        //    Application.ExternalEval($"window.open('{url}','_blank');");

        //}
        //else
        //{
        //    Application.OpenURL(url);
        //}

        
    }
    //public void clicklink()
    //{
        
    //    string url = gameObject.GetComponent<TextMeshPro>().textInfo.linkInfo[0].GetLinkText();
    //    Application.OpenURL(url);
    //}
}
