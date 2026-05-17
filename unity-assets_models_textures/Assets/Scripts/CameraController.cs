using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;                   // Assign Player in Inspector
    public Vector3 offset = new Vector3(0, 2.5f, -6.25f);  // Base offset from player
    public float followSpeed = 10f;            // Smooth follow speed
    public float rotationSpeed = 5f;           // Mouse rotation speed

    private float yaw = 0f;                     // Horizontal rotation
    private float pitch = 9f;                   // Vertical rotation

    void Start()
    {
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    void LateUpdate()
    {
        if (player == null) return;

        HandleRotation();
        HandleFollow();
    }

    void HandleFollow()
    {
        // Calculate rotated offset based on yaw and pitch
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 rotatedOffset = rotation * offset;

        // Smoothly move camera to follow player
        Vector3 targetPosition = player.position + rotatedOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    void HandleRotation()
    {
        // Right-click drag to rotate camera
        if (Input.GetMouseButton(1))  // or remove this check to always rotate
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;
            pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
            pitch = Mathf.Clamp(pitch, 5f, 80f); // Prevent flipping
        }

        // Apply rotation
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}



