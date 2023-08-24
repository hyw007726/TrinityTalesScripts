using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure you add this line to use the Text component
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public InsuranceDraggable[] characters;
    public TextMeshProUGUI messageBox; // Drag and drop your Text component (from the UI) here through the Unity inspector

    private Dictionary<string, string> correctAssignments = new Dictionary<string, string>
    {
        { "A", "iv" },
        { "B", "iii" },
        { "C", "ii" },
        { "D", "i" },
        { "E", "ii" }
    };
    void Start()
    {
        if (PlayerPrefs.HasKey("CharactersDone"))
        {
            PlayerPrefs.DeleteKey("CharactersDone");
        }
        else
        {
            PlayerPrefs.SetInt("CharactersDone", 0);
        }

 

    }
    public void ClearMessageBox()
{
    messageBox.text = "";  // Clearing the message box
}

    public void CheckAssignments(InsuranceDraggable character)
{
    if (character.assignedCompanyId == null || character.assignedCompanyId != correctAssignments[character.characterId])
    {
        //Debug.Log("Incorrect assignment!");
        messageBox.text = "That's not right, try again!"; // Display the message
    }
    else
    {
        //Debug.Log(character.characterId + " correctly assigned!");
        messageBox.text = "That's correct!"; // Display the message
        character.gameObject.SetActive(false); // Make the character card disappear if it's correctly assigned
            int charactersCount = PlayerPrefs.GetInt("CharactersDone");
            //Debug.Log(charactersCount);
            if(++charactersCount == correctAssignments.Count)
            {
                messageBox.text = "You finished the game! Congratulations!"; // Display the message
                SceneManager.UnloadSceneAsync("InsuranceGameScene");
                //Trigger progress update; 1 stands for minigame1
                if (DataManager.Instance != null)
                {
                    DataManager.Instance.UpdateProgress(1);
                }
          
                DesktopController.Current.ActivateDialogue();
            }
            else
            {
                PlayerPrefs.SetInt("CharactersDone", charactersCount);
            }
    }
}
}