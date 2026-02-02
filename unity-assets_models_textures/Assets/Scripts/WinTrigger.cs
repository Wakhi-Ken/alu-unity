using UnityEngine;
using UnityEngine.UI; // Include this for UI components

public class WinTrigger : MonoBehaviour
{
    private Timer timer; // Reference to the Timer script on Player
    public Text timerText; // Reference to the Timer's Text UI component

    void Start()
    {
        // Find the Timer script attached to the Player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            timer = player.GetComponent<Timer>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering is the Player
        if (other.CompareTag("Player"))
        {
            // Stop the timer
            if (timer != null)
            {
                timer.enabled = false; // Disable the Timer script
            }

            // Change timer text style
            if (timerText != null)
            {
                timerText.fontSize = 60; // Increase font size
                timerText.color = Color.green; // Change text color to green
            }
        }
    }
}