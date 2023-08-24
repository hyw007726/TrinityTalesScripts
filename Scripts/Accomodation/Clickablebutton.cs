using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Clickablebutton : MonoBehaviour
{
    public CanvasGroup Accept;
    public CanvasGroup Decline;
    public CanvasGroup Proceed;
    public CanvasGroup Prompt;
    public CanvasGroup AcceptPanel;
    public CanvasGroup DeclinePanel;
   


    private bool isAnyButtonClicked = false;

    // Start is called before the first frame update

    
    void Start()
    {
        HideCanvasGroup(Accept);
        HideCanvasGroup(Decline);
        HideCanvasGroup(Proceed);
        ShowCanvasGroup(Prompt);
        ShowCanvasGroup(AcceptPanel);
        ShowCanvasGroup(DeclinePanel);
        
        ;
    }

    public void OnAcceptClick()
    {
        HandleButtonClick(Accept, Decline, AcceptPanel, DeclinePanel);
    }

    public void OnDeclineClick()
    {
        HandleButtonClick(Decline, Accept, DeclinePanel, AcceptPanel);
    }

    private void HandleButtonClick(CanvasGroup clickedButton, CanvasGroup otherButton, CanvasGroup clickedPanel, CanvasGroup otherPanel)
    {
        if (isAnyButtonClicked) return;

        HideCanvasGroup(Prompt);
        ShowCanvasGroup(clickedButton);  // Keep the clicked button visible
        HideCanvasGroup(otherButton);
        ShowCanvasGroup(Proceed);
        HideCanvasGroup(clickedPanel);
        HideCanvasGroup(otherPanel);
     

        isAnyButtonClicked = true;
    }

    private void ShowCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1f;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    private void HideCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }


}





