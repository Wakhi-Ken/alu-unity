using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;      // Movement speed
    public float jumpForce = 5f;      // Upward velocity for jump
    public float gravity = -9.81f;    // Gravity force
    public LayerMask groundMask;      // Layer that counts as ground
    public float groundCheckDistance = 0.1f; // How far to check for ground

    private Vector3 velocity;         // Vertical velocity
    private bool isGrounded;          // Ground check
    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        // Check if the player is grounded
        GroundCheck();

        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Move player
        MovePlayer(direction);

        // Jump
        HandleJump();
    }

    private void MovePlayer(Vector3 direction)
    {
        // Horizontal movement
        playerTransform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        // Vertical movement
        playerTransform.Translate(velocity * Time.deltaTime, Space.World);
    }

    private void HandleJump()
    {
        // Jump anytime Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Optional: clamp player to ground
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
    }

    private void GroundCheck()
    {
        // Raycast down to check ground
        isGrounded = Physics.Raycast(playerTransform.position, Vector3.down, groundCheckDistance, groundMask);
    }
}
