using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounting : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to a TextMeshProUGUI component on the Canvas
    private float elapsedTime;
    private bool countingStarted = false;

    void Start()
    {
        // Check if the TextMeshProUGUI component is assigned
        if (timerText == null)
        {
            Debug.LogError("TimerText not assigned! Please assign a TextMeshProUGUI component to the TimerText field.");
        }
    }

    void Update()
    {
        // Check if counting has started
        if (!countingStarted)
        {
            // Start counting after 3 seconds
            if (Time.time >= 3f)
            {
                countingStarted = true;
            }
        }
        else
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Format the elapsed time as a string in the "00:00:000" format
            string elapsedTimeString = FormatTime(elapsedTime);

            // Update the TextMeshProUGUI component with the elapsed time
            if (timerText != null)
            {
                //timerText.text = "Time: " + elapsedTimeString;
                timerText.text = elapsedTimeString;
            }
        }
    }

    string FormatTime(float time)
    {
        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        // Format the time as a string in the "00:00:000" format
        string timeString = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        return timeString;
    }
}