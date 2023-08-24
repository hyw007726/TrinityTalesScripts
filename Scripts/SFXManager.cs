using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    private AudioSource audioSource;
    public AudioClip buttonClickSound;
    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void buttonClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
    //Play sfx in other scripts
    //SFXManager.Instance.buttonClick();

}
