using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public int winFontSize = 60;       // Font size after winning
    public Color winColor = Color.green; // Text color after winning

    private Timer timer;       // Reference to the Timer script
    private Text timerText;    // Reference to the timer's Text
    private bool hasWon = false;

    void Start()
    {
        // Find the player by tag
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Get the Timer script attached to the player
            timer = player.GetComponent<Timer>();
            if (timer != null)
            {
                timerText = timer.timerText; // Get the Text component from Timer
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasWon) return;

        // Check if the Player touched the WinFlag
        if (other.CompareTag("Player"))
        {
            hasWon = true;
            Win();
        }
    }

    private void Win()
    {
        // Stop the timer
        if (timer != null)
        {
            timer.StopTimer();
        }

        // Change timer appearance
        if (timerText != null)
        {
            timerText.fontSize = winFontSize;
            timerText.color = winColor;
        }

        Debug.Log("Player Wins!");
    }
}
