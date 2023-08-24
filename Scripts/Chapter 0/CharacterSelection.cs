using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public int selectedCharacter = 0;
	public Button confirmButton;
	public TMP_InputField nameInput;
	public void NextCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % characters.Length;
		characters[selectedCharacter].SetActive(true);
        if (selectedCharacter != 0)
        {
			confirmButton.interactable = false;
			nameInput.interactable = false;

        }
        else
        {
			confirmButton.interactable = true;
			nameInput.interactable = true;
		}
	}

	public void PreviousCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
		}
		characters[selectedCharacter].SetActive(true);
		if (selectedCharacter != 0)
		{
			confirmButton.interactable = false;
			nameInput.interactable = false;

		}
		else
		{
			confirmButton.interactable = true;
			nameInput.interactable = true;
		}
	}

//// LoadScene
//	public void StartGame()
//	{
//		PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
//		SceneManager.LoadScene(1, LoadSceneMode.Single);
//	}
}
