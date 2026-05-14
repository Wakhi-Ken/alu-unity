using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 5f;
    public float gravity = -20f;

    public LayerMask groundMask;

    public float fallThreshold = -10f;
    public float respawnHeight = 15f;

    private Vector3 velocity;
    private bool isGrounded;

    private CharacterController controller;

    public Vector3 startPosition;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        startPosition = transform.position;
    }

    void Update()
    {
        // Check if grounded
        GroundCheck();

        // Keep player grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal +
                       transform.forward * vertical;

        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Respawn if fallen
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    private void GroundCheck()
    {
        // Ray starts slightly above feet
        Vector3 rayStart = transform.position + Vector3.up * 0.1f;

        // Longer ray for your controller size
        float rayLength = 1.2f;

        isGrounded = Physics.Raycast(
            rayStart,
            Vector3.down,
            rayLength,
            groundMask
        );

        Debug.DrawRay(rayStart, Vector3.down * rayLength, Color.red);
    }

    private void Respawn()
    {
        Vector3 respawnPosition = startPosition + Vector3.up * respawnHeight;

        controller.enabled = false;

        transform.position = respawnPosition;

        controller.enabled = true;

        velocity = Vector3.zero;
    }
}