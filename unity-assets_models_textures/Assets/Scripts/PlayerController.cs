using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;   // Movement speed
    public float jumpForce = 5f;   // Jump height

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 startPosition; // Start position for falling reset

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Record starting position
    }

    void Update()
    {
        MovePlayer();
        Jump();

        // Check if player fell off platforms
        if (transform.position.y < -10f) // Adjust -10f based on your level height
        {
            ResetPlayer();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Keep Y velocity for jumping/falling
        Vector3 velocity = new Vector3(moveX * moveSpeed, rb.linearVelocity.y, moveZ * moveSpeed);
        rb.linearVelocity = velocity;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Basic grounded check
        isGrounded = true;
    }

    void ResetPlayer()
    {
        // Reset player to starting position
        transform.position = startPosition;

        // Reset velocity so it doesn’t keep falling
        rb.linearVelocity = Vector3.zero;
    }
}



