using UnityEngine;
using TMPro;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    public float timeMultiplier = 0.001f;

    // Update is called once per frame
    void Update()
    {
        //normal time
        //elapsedTime += Time.deltaTime;

        //stardew valley time
        Time.timeScale = timeMultiplier;
        elapsedTime += Time.timeScale;

        int hours = Mathf.FloorToInt(elapsedTime % 3600) / 60; // Convert elapsed time to hours and loop around after 24 hours
        //int min = Mathf.FloorToInt((elapsedTime % 3600) / 60); // Get remaining minutes after the hours
        int sec = Mathf.FloorToInt(elapsedTime % 60); // Get the remaining seconds after minutes

        // Determine AM or PM
        string period = hours >= 12 ? "AM" : "PM";

        // Convert to 12-hour format
        int displayHour = hours % 12;
        if (displayHour == 0) displayHour = 12; // Display 12 instead of 0 for 12-hour clock format


        timerText.text = string.Format("{00:00}:{1:00} {2}",displayHour, sec, period);
    }

    /*
     * public float timeIncrement = 10; // Time in seconds between each minute increment

    private float currentTime = 0; // Current time in minutes



    void Update()

    {

        currentTime += Time.deltaTime;



        if (currentTime >= timeIncrement)

        {

            currentTime -= timeIncrement; // Reset the counter

            currentTime += 1; // Add one minute

            UpdateDisplay(); // Update the displayed time

        }

    }



    void UpdateDisplay()

    {

        int minutes = Mathf.FloorToInt(currentTime);

        int seconds = Mathf.FloorToInt((currentTime - minutes) * 60); 

        timeDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds); 

    }
    */
}
