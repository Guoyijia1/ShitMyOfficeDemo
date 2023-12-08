using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounting : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to a TextMeshProUGUI component where you want to display the race time
    private bool raceStarted = false;
    private float startTime;

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("TimerText not assigned!");
        }
    }

    void Update()
    {
        if (raceStarted)
        {
            // Calculate the elapsed time since the race started
            float elapsedTime = Time.time - startTime;

            // Format the time as a string in the "00:00:00" format
            string timeString = FormatTime(elapsedTime);

            // Update the TextMeshProUGUI component with the formatted time
            if (timerText != null)
            {
                timerText.text = "Race Time: " + timeString;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the car crossed the starting line
        if (other.CompareTag("StartingLine"))
        {
            StartRace();
        }

        // Check if the car crossed the finishing line
        if (other.CompareTag("FinishingLine") && raceStarted)
        {
            StopRace();
        }
    }

    void StartRace()
    {
        // Start the race timer
        raceStarted = true;
        startTime = Time.time;
    }

    void StopRace()
    {
        // Stop the race timer
        raceStarted = false;
    }

    string FormatTime(float time)
    {
        // Calculate hours, minutes, and seconds
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        // Format the time as a string in the "00:00:00" format
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        return timeString;
    }
}