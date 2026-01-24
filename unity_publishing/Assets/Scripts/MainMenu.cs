using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public void PlayMaze()
    {
        // Load the Maze scene. Replace "MazeSceneName" with the actual name of your scene.
        SceneManager.LoadScene("Maze");
    }
    public void QuitMaze()
    {
        Debug.Log("Quit Game"); // Log message for the editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#else
            Application.Quit(); // Quit the application
#endif
    }
}
