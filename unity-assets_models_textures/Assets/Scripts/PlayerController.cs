using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public LayerMask groundMask;
    public float groundCheckDistance = 0.2f;

    public Vector3 startPosition;
    public float fallThreshold = -10f;

    private Vector3 velocity;
    private bool isGrounded;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }

        GroundCheck();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);

        // Move player (collisions handled automatically)
        controller.Move(move * moveSpeed * Time.deltaTime);

        HandleJump();

        // Apply gravity
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleJump()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // keeps player grounded
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity * Time.deltaTime;
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
    }

    private void Respawn()
    {
        transform.position = startPosition + Vector3.up * 10f;
        velocity = Vector3.zero;
    }
}
