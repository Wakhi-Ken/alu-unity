using UnityEngine;
using UnityEngine.UI; // Include this for UI components
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text component
    private float elapsedTime = 0f; // Track elapsed time

    void Start()
    {
        // Initialize the timer text
        timerText.text = FormatTime(elapsedTime);
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (true) // Infinite loop until the object is destroyed
        {
            yield return new WaitForSeconds(0.1f); // Update every 0.1 seconds
            elapsedTime += 0.1f; // Increase the elapsed time by 0.1 seconds
            timerText.text = FormatTime(elapsedTime); // Update timer text
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        float seconds = time % 60;
        return string.Format("{0:00}:{1:00.00}", minutes, seconds); // Format to "MM:SS.SS"
    }
}