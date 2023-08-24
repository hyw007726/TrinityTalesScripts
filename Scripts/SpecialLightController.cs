using UnityEngine;

public class SpecialLightController : MonoBehaviour
{
    private Light specialLight;

    void Start()
    {
        specialLight = GetComponent<Light>();
        if (specialLight == null)
        {
            Debug.LogError("No light component attached to this object!");
        }
    }

    void Update()
    {
        CheckOtherLights();
    }

    void CheckOtherLights()
    {
        Light[] allLightsInScene = FindObjectsOfType<Light>();
        
        foreach (Light light in allLightsInScene)
        {
            // If any light other than the special light is active
            if (light.enabled && light != specialLight)
            {
                specialLight.enabled = false;
                return; // No need to check other lights since one is already found active
            }
        }

        // If no other light is active
        specialLight.enabled = true;
    }
}
