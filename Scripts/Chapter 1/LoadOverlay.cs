using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadOverlay : MonoBehaviour
{

   void Awake()
    {
        SceneManager.LoadScene("OverlayScene", LoadSceneMode.Additive);

    }
    private void Start()
    {

    }

}
