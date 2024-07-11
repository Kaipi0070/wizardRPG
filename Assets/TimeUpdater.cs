using System;
using UnityEngine;
using TMPro;

public class TimeUpdater : MonoBehaviour
{
    // References to the TextMeshPro components
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI amPmText;

    void Start()
    {
        UpdateTime();
    }

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        // Get the current time
        DateTime currentTime = DateTime.Now;

        // Format the time as "hh:mm"
        string formattedTime = currentTime.ToString("hh:mm");

        // Get the AM/PM part
        string amPm = currentTime.ToString("tt");

        // Update the TextMeshPro components with the formatted time and AM/PM
        timeText.text = formattedTime;
        amPmText.text = amPm;
    }
}
