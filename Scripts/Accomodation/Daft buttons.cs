using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daftbuttons : MonoBehaviour
{
    public CanvasGroup Daft1;
    public CanvasGroup Daft2;
    public CanvasGroup Daft3;
    public CanvasGroup Daft4;
    public CanvasGroup Proceed;
    public CanvasGroup Prompt;  // The new prompt

    private bool isAnyDaftButtonClicked = false;

    void Start()
    {
        HideCanvasGroup(Daft1);
        HideCanvasGroup(Daft2);
        HideCanvasGroup(Daft3);
        HideCanvasGroup(Daft4);
        HideCanvasGroup(Proceed);
        ShowCanvasGroup(Prompt);  // Show the prompt at the start
    }

    public void OnDaft1Click()
    {
        HandleDaftButtonClick(Daft1);
    }

    public void OnDaft2Click()
    {
        HandleDaftButtonClick(Daft2);
    }

    public void OnDaft3Click()
    {
        HandleDaftButtonClick(Daft3);
    }

    public void OnDaft4Click()
    {
        HandleDaftButtonClick(Daft4);
    }

    private void HandleDaftButtonClick(CanvasGroup clickedButton)
    {
        if (isAnyDaftButtonClicked) return; // Ignore if any daft button was already clicked.

        HideCanvasGroup(Prompt);  // Hide the prompt when a button is clicked
        ShowCanvasGroup(clickedButton);
        HideOtherDaftButtons(clickedButton);
        ShowCanvasGroup(Proceed);

        isAnyDaftButtonClicked = true;
    }

    private void HideOtherDaftButtons(CanvasGroup clickedButton)
    {
        if (clickedButton != Daft1) HideCanvasGroup(Daft1);
        if (clickedButton != Daft2) HideCanvasGroup(Daft2);
        if (clickedButton != Daft3) HideCanvasGroup(Daft3);
        if (clickedButton != Daft4) HideCanvasGroup(Daft4);
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