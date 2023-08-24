using UnityEngine;
using UnityEngine.UI;

public class ProgressSlider : MonoBehaviour
{
    [SerializeField] private Slider progressSlider; // Reference to the Slider component

    private const float challengeProgress = 0.2f; // 20%

    private void Awake()
    {
        if (progressSlider == null)
            progressSlider = GetComponent<Slider>();

        DataManager.Instance.OnProgressUpdate+= CompleteChallenge;
    }

    public void CompleteChallenge(int progress)
    {

        progressSlider.value = progress*challengeProgress;

        // Ensure the slider value stays within the valid range
        progressSlider.value = Mathf.Clamp(progressSlider.value, 0f, 1f);
    }
}
