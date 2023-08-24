using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // This will close the game if it's a built executable
#endif
    }
}
