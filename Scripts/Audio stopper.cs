using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExclusiveAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure there's a clip to play.
        if (audioSource.clip == null)
        {
            Debug.LogWarning("No audio clip attached to ExclusiveAudioPlayer.");
            return;
        }

        StopAllOtherAudios();
        audioSource.Play();
    }

    private void StopAllOtherAudios()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            if (source != audioSource)
            {
                source.Stop();
            }
        }
    }
}
