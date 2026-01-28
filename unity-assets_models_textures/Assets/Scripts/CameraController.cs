using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector
    public float distance = 5f; // Distance from the player
    public float height = 2f; // Height above the player
    public float mouseSensitivity = 2f; // Sensitivity of mouse rotation

    private float currentAngleY = 0f; // Current Y angle for camera rotation
    private float currentAngleX = 0f; // Current X angle for camera rotation

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Handle mouse input
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            currentAngleY += mouseX; // Rotate around Y-axis (left/right)
            currentAngleX -= mouseY; // Rotate around X-axis (up/down)

            // Clamp the vertical angle to prevent flipping
            currentAngleX = Mathf.Clamp(currentAngleX, -20f, 80f);
        }

        // Update camera position and rotation
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        // Calculate the camera position
        Vector3 offset = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(currentAngleX, currentAngleY, 0);

        // Set the camera's position
        transform.position = player.position + rotation * offset;

        // Make the camera look at the player
        transform.LookAt(player.position);
    }
}