using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableToDo : MonoBehaviour
{
    public CanvasGroup toDo;
    //public CanvasGroup ReceiptDo2;
    private bool isToDoVisible = false;
    private bool isReceiptVisible = false;


    // Start is called before the first frame update
    void Start()
    {
        toDo.alpha = 0;
        toDo.interactable = false;
        toDo.blocksRaycasts = false;
        //ReceiptDo2.alpha = 0;
        //ReceiptDo2.interactable = false;
        //ReceiptDo2.blocksRaycasts = false;
    }

    // Method to be called when the ToDo Button is clicked
    public void OnMouseOver()
    {
        isToDoVisible = true;
        toDo.alpha = 1;
        toDo.interactable = true;
        toDo.blocksRaycasts = true;
    }
    public void OnMouseExit()
    {
        isToDoVisible = false;
        toDo.alpha = 0;
        toDo.interactable = false;
        toDo.blocksRaycasts = false;
    }
    public void OnInfoClick()
    {
        isToDoVisible = !isToDoVisible;
        toDo.alpha = isToDoVisible?1f:0;
        toDo.interactable = isToDoVisible;
        toDo.blocksRaycasts = isToDoVisible;
    }
    // Method to be called when the Receipt Button is clicked
    public void OnReceiptButtonClick()
    {
        isReceiptVisible = !isReceiptVisible;
        //ReceiptDo2.alpha = isReceiptVisible ? 1f : 0f;
        //ReceiptDo2.interactable = isReceiptVisible;
        //ReceiptDo2.blocksRaycasts = isReceiptVisible;
    }
}








