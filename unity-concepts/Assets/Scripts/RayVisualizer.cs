using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxDistance = 50f;
    public float moveSpeed = 5f;

    void Update()
    {
        MoveCube();
        DrawRay();
    }

    // 1️⃣ Method to move the cube using keyboard input
    void MoveCube()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    // 2️⃣ Method to draw ray and detect hits
    void DrawRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        lineRenderer.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            lineRenderer.SetPosition(1, hit.point);

            // 3️⃣ Print the name of the duplicate cube if hit
            Debug.Log("Ray hit: " + hit.collider.gameObject.name);
        }
        else
        {
            lineRenderer.SetPosition(1, ray.origin + ray.direction * maxDistance);
        }
    }
}

