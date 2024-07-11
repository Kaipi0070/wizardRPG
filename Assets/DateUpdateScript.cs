using System;
using UnityEngine;
using TMPro;

public class DateUpdater : MonoBehaviour
{
    public TextMeshProUGUI dayText;

    void Start()
    {
        UpdateDay();
    }

    void UpdateDay()
    {
        // Get the current date
        DateTime currentDate = DateTime.Now;

        // Abbreviations for the days of the week
        string[] dayOfWeekAbbr = { "Sun", "Mon", "Tue", "Wed", "Thurs", "Fri", "Sat" };

        // Get the abbreviated day of the week
        string dayOfWeek = dayOfWeekAbbr[(int)currentDate.DayOfWeek];

        // Update the TextMeshPro components with the day and date
        dayText.text = dayOfWeek;
      
    }
}
