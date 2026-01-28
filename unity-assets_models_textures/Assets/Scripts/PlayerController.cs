using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public LayerMask groundMask;
    public float groundCheckDistance = 0.1f;

    public Vector3 startPosition; // Player respawn position
    public float fallThreshold = -10f; // Y level where player respawns

    private Vector3 velocity;
    private bool isGrounded;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform;
        startPosition = playerTransform.position; // Save initial position
    }

    void Update()
    {
        // Respawn if player falls below threshold
        if (playerTransform.position.y < fallThreshold)
        {
            Respawn();
        }

        // Ground check
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
        playerTransform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        playerTransform.Translate(velocity * Time.deltaTime, Space.World);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(playerTransform.position, Vector3.down, groundCheckDistance, groundMask);
    }

    private void Respawn()
    {
        // Reset player to top of screen + start position
        playerTransform.position = startPosition + Vector3.up * 10f; // 10 units above start
        velocity = Vector3.zero; // Reset vertical velocity
    }
}
