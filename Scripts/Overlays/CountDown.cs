using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Definition of DayCountdown class that extends MonoBehaviour
public class DayCountdown : MonoBehaviour
{
    public TextMeshProUGUI dayCounter; // Public variable to hold reference to Text UI element
    private int currentDay = 30;  // Private variable to keep count of current day, initialized to 0

    // Start method is a Unity-specific method called when the script instance is being loaded
    void Start()
    {
        // Setting the initial text of the dayCounter UI element
        dayCounter.text = "Days: " + currentDay.ToString();

        // Starting the Coroutine named CountdownDay
        StartCoroutine(CountdownDay());
    }

    // Definition of Coroutine CountdownDay
    IEnumerator CountdownDay()
    {
        // Loop that will continue indefinitely until the object is destroyed or the Coroutine is stopped
        while (true)
        {
            // Pause the execution of the Coroutine for 60 seconds
            yield return new WaitForSeconds(60);

            // Increase the value of currentDay by 1
            currentDay -= 1;

            // Update the text of the dayCounter UI element with the new day count
            dayCounter.text = "Days: " + currentDay.ToString();
        }
    }
}