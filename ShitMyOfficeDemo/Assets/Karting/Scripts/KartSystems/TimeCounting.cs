using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounting : MonoBehaviour
{
    public TextMeshProUGUI lapTimeText; // Reference to a TextMeshProUGUI component on the Canvas
    private bool raceStarted = false;
    private float lapStartTime;
    private float totalRaceTime;

    void Start()
    {
        // Check if the TextMeshProUGUI component is assigned
        if (lapTimeText == null)
        {
            Debug.LogError("LapTimeText not assigned! Please assign a TextMeshProUGUI component to the LapTimeText field.");
        }

        lapTimeText.text = "00:00:00";

    }

    void Update()
    {
        if (raceStarted)
        {
            // Calculate the lap time
            float lapTime = Time.time - lapStartTime;

            // Format the lap time as a string in the "00:00:00" format
            string lapTimeString = FormatTime(lapTime);

            // Update the TextMeshProUGUI component with the lap time
            if (lapTimeText != null)
            {
                lapTimeText.text = "Lap Time: " + lapTimeString;
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
        // Start the race
        raceStarted = true;

        // Record the lap start time
        lapStartTime = Time.time;
    }

    void StopRace()
    {
        // Stop the race
        raceStarted = false;

        // Calculate the total race time
        totalRaceTime += Time.time - lapStartTime;

        // Reset lap start time for the next lap
        lapStartTime = Time.time;

        // Format the total race time as a string in the "00:00:00" format
        string totalRaceTimeString = FormatTime(totalRaceTime);

        // Display the total race time (you can customize this part based on your requirements)
        Debug.Log("Total Race Time: " + totalRaceTimeString);
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
