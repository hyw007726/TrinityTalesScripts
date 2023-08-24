using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private Queue<AudioClip> recentlyPlayed = new Queue<AudioClip>();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips attached to RandomAudioPlayer.");
            return;
        }

        if (audioClips.Length < 5)
        {
            Debug.LogError("Need at least 5 audio clips to meet the play requirement.");
            return;
        }

        StartCoroutine(PlayRandomAudio());
    }

    private AudioClip GetRandomClip()
    {
        List<AudioClip> possibleClips = new List<AudioClip>(audioClips);
        foreach (AudioClip clip in recentlyPlayed)
        {
            possibleClips.Remove(clip);
        }

        return possibleClips[Random.Range(0, possibleClips.Count)];
    }

    private bool OtherAudiosPlaying()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in sources)
        {
            if (source != audioSource && source.isPlaying)
                return true;
        }
        return false;
    }

   private IEnumerator PlayRandomAudio()
{
    while (true)
    {
        yield return new WaitWhile(OtherAudiosPlaying);

        AudioClip clipToPlay = GetRandomClip();

        if (clipToPlay != null)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();

            recentlyPlayed.Enqueue(clipToPlay);

            if (recentlyPlayed.Count > 4)
            {
                recentlyPlayed.Dequeue();
            }

            // This line ensures we move to the next iteration only after the clip finishes.
            yield return new WaitWhile(() => audioSource.isPlaying);
        }
        else
        {
            Debug.LogWarning("One of the audio clips in RandomAudioPlayer is null.");
            yield return null;
        }
    }
}

}
