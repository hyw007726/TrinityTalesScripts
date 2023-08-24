using UnityEngine;
using TMPro;

public class TextModifier : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Drag your TextMeshProUGUI component here in the Unity Inspector

    void Start()
    {
        // Ensure there's a reference set
        if (textComponent == null)
        {
            Debug.LogError("No TextMeshProUGUI component assigned!");
            return;
        }

        // Get the current text
        string currentText = textComponent.text;

        // Get the player's name
        string playerName = "Default Player"; // Default value
        DataManager instance = FindObjectOfType<DataManager>();
        if (instance != null)
        {
            playerName = instance.ReadData().playerName;
        }

        // Replace "Default Player" with the actual player's name
        currentText = currentText.Replace("Default Player", playerName);

        // Update the text
        textComponent.text = currentText;
    }
}
