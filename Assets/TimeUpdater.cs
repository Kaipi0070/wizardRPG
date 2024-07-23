using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeUpdater : MonoBehaviour
{
    // References to the TextMeshPro components
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI amPmText;
    public TextMeshProUGUI dayNumText;
    public TextMeshProUGUI countdownText;

    // Reference to the Image component for the season icon
    public Image seasonIcon;
    public Sprite springIcon; // Assign these in the Unity Inspector
    public Sprite summerIcon;
    public Sprite fallIcon;
    public Sprite winterIcon;

    private int countdownTime = 10; // 30 seconds countdown
    private int dayNum = 1; // Starting from day 1
    private int seasonCycle = 1; // 1 for Spring, 2 for Summer, 3 for Fall, 4 for Winter

    void Start()
    {
        UpdateTime();
        StartCoroutine(CountdownAndUpdateDay());
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

    System.Collections.IEnumerator CountdownAndUpdateDay()
    {
        while (true)
        {
            // Update the countdown text
            countdownText.text = "Countdown: " + countdownTime.ToString();

            // Wait for 1 second
            yield return new WaitForSeconds(1);

            // Decrement the countdown time
            countdownTime--;

            // If the countdown reaches zero
            if (countdownTime <= 0)
            {
                // Increment the day number
                dayNum++;
                if (dayNum > 3)
                {
                    dayNum = 1; // Reset to day 1 after reaching day 3

                    // Increment the season cycle
                    seasonCycle++;
                    if (seasonCycle > 4)
                    {
                        seasonCycle = 1; // Reset to Spring after Winter
                    }

                    // Update the season icon based on the current season cycle
                    UpdateSeasonIcon();
                }

                // Update the dayNumText with "Day X" format
                dayNumText.text = "Day " + dayNum.ToString();
                Debug.Log("Day Number: " + dayNum);

                // Reset the countdown time for the next cycle
                countdownTime = 10;
            }
        }
    }

    void UpdateSeasonIcon()
    {
        switch (seasonCycle)
        {
            case 1:
                seasonIcon.sprite = springIcon;
                break;
            case 2:
                seasonIcon.sprite = summerIcon;
                break;
            case 3:
                seasonIcon.sprite = fallIcon;
                break;
            case 4:
                seasonIcon.sprite = winterIcon;
                break;
            default:
                seasonIcon.sprite = springIcon; // Default to spring if seasonCycle is out of range
                break;
        }
    }
}
