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

        int min = Mathf.FloorToInt(elapsedTime / 60);
        int sec = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00} PM", min, sec);
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
