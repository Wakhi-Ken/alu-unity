using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public MonoBehaviour playerController;
    public GameObject timerCanvas;
    public GameObject cutcscenecamera;

    void Start()
    {
        // Disable gameplay at start
        cutcscenecamera.SetActive(true);
        mainCamera.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);
        
    }

    // This function will be called at the end of the animation
    public void EndCutscene()
    {
        // Enable gameplay
        
        mainCamera.SetActive(true);
        playerController.enabled = true;
        timerCanvas.SetActive(true);
        cutcscenecamera.SetActive(false);
    }
}