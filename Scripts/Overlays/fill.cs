using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillAnimator : MonoBehaviour
{
    public Image imageToAnimate;
    private float fillSpeed;

    private void Start()
    {
        fillSpeed = 1.0f / 60.0f;  // Changes fill amount from 1 to 0 in 60 seconds
        StartCoroutine(AnimateFill());
    }


    IEnumerator AnimateFill()
    {
        while (true)  // Loop forever
        {
            while (imageToAnimate.fillAmount > 0)
            {
                imageToAnimate.fillAmount -= fillSpeed * Time.deltaTime;
                yield return null;
            }

            imageToAnimate.fillAmount = 1;  // Reset fill amount to start the next cycle
        }
    }
}